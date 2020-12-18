﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace TestCore
{
    public abstract class Packet
    {
        private static readonly List<Type> Packets;
        /// <summary>
        /// 写泛型流
        /// </summary>
        private static readonly Dictionary<Type, Action<object, BinaryWriter>> TypeWrite;
        /// <summary>
        /// 读泛型流
        /// </summary>
        private static readonly Dictionary<Type, Func<BinaryReader, object>> TypeRead;
        /// <summary>
        /// 是否是客户端
        /// </summary>
        public static bool IsClient { get; set; }

        public Type PacketType;

        public int Length;

        public bool ObserverPacket = true;
        static Packet()
        {
            Packets = new List<Type>();

            Type[] list= Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in list)
            {
                if (type.BaseType != typeof(Packet)) continue;
                Packets.Add(type);
            }
            //排序
            Packets.Sort((x1, x2) =>
            {
                if (String.Compare(x1.Namespace, x2.Namespace, StringComparison.Ordinal) == 0)
                    return String.Compare(x1.Name, x2.Name, StringComparison.Ordinal);

                if (string.Compare(x1.Namespace, @"Library.Network.GeneralPackets", StringComparison.Ordinal) == 0) //We want General Packets shifted To the top.
                    return -1;

                if (string.Compare(x2.Namespace, @"Library.Network.GeneralPackets", StringComparison.Ordinal) == 0) //We want General Packets shifted To the top.
                    return 1;

                return String.Compare(x1.Name, x2.Name, StringComparison.Ordinal);
            });
            #region Writes发送字典
            TypeWrite = new Dictionary<Type, Action<object, BinaryWriter>>
            {
                [typeof(Boolean)] = (v, w) => w.Write((bool)v),
                [typeof(Byte)] = (v, w) => w.Write((Byte)v),
                [typeof(Byte[])] = (v, w) =>
                {
                    w.Write(((Byte[])v).Length);
                    w.Write((Byte[])v);
                },
                [typeof(Char)] = (v, w) => w.Write((Char)v),
                [typeof(Color)] = (v, w) => w.Write(((Color)v).ToArgb()),
                [typeof(DateTime)] = (v, w) => w.Write(((DateTime)v).ToBinary()),
                [typeof(Decimal)] = (v, w) => w.Write((Decimal)v),
                [typeof(Double)] = (v, w) => w.Write((Double)v),
                [typeof(Int16)] = (v, w) => w.Write((Int16)v),
                [typeof(Int32)] = (v, w) => w.Write((Int32)v),
                [typeof(Int64)] = (v, w) => w.Write((Int64)v),
                [typeof(Point)] = (v, w) =>
                {
                    w.Write(((Point)v).X);
                    w.Write(((Point)v).Y);
                },
                [typeof(SByte)] = (v, w) => w.Write((SByte)v),
                [typeof(Single)] = (v, w) => w.Write((Single)v),
                [typeof(Size)] = (v, w) =>
                {
                    w.Write(((Size)v).Width);
                    w.Write(((Size)v).Height);
                },
                [typeof(String)] = (v, w) => w.Write((String)v ?? string.Empty),
                [typeof(TimeSpan)] = (v, w) => w.Write(((TimeSpan)v).Ticks),
                [typeof(UInt16)] = (v, w) => w.Write((UInt16)v),
                [typeof(UInt32)] = (v, w) => w.Write((UInt32)v),
                [typeof(UInt64)] = (v, w) => w.Write((UInt64)v)
            };
            #endregion

            #region Reads读取字典
            TypeRead = new Dictionary<Type, Func<BinaryReader, object>> {
                [typeof(Boolean)] = (r) => r.ReadBoolean(),
                [typeof(Byte)] = (r) => r.ReadByte(),
                [typeof(Byte[])] = (r) => r.ReadBytes(r.ReadInt32()),
                [typeof(Char)] = (r) => r.ReadChar(),
                [typeof(Color)] = (r) => Color.FromArgb(r.ReadInt32()),
                [typeof(DateTime)] = (r) => DateTime.FromBinary(r.ReadInt64()),
                [typeof(Decimal)] = (r) => r.ReadDecimal(),
                [typeof(Double)] = (r) => r.ReadDouble(),
                [typeof(Enum)] = (r) => r.ReadInt32(),
                [typeof(Int16)] = (r) => r.ReadInt16(),
                [typeof(Int32)] = (r) => r.ReadInt32(),
                [typeof(Int64)] = (r) => r.ReadInt64(),
                [typeof(Point)] = (r) => new Point(r.ReadInt32(), r.ReadInt32()),
                [typeof(SByte)] = (r) => r.ReadSByte(),
                [typeof(Single)] = (r) => r.ReadSingle(),
                [typeof(Size)] = (r) => new Size(r.ReadInt32(), r.ReadInt32()),
                [typeof(String)] = (r) => r.ReadString(),
                [typeof(TimeSpan)] = (r) => TimeSpan.FromTicks(r.ReadInt64()),
                [typeof(UInt16)] = (r) => r.ReadUInt16(),
                [typeof(UInt32)] = (r) => r.ReadUInt32(),
                [typeof(UInt64)] = (r) => r.ReadUInt64()

            };
            #endregion
        }

        /// <summary>
        ///     
        /// 返回上下文解析
        /// 
        /// </summary>
        /// <param name="rawBytes"></param>
        /// <param name="extra"></param>
        /// <returns></returns>
        public static Packet ReceivePacket(byte[] rawBytes, out byte[] extra)
        {
            extra = rawBytes;
            Packet p = null;

            if (rawBytes.Length < 4) return null; //4Bytes: Packet Size | 数据长度小于4Byes 返回null

            int length = rawBytes[3] << 24 | rawBytes[2] << 16 | rawBytes[1] << 8 | rawBytes[0];

            if (length > rawBytes.Length) return null;

            extra = new byte[rawBytes.Length - length];
            Buffer.BlockCopy(rawBytes, length, extra, 0, rawBytes.Length - length);
            using (MemoryStream stream = new MemoryStream(rawBytes))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                stream.Seek(4, SeekOrigin.Begin);

                short id = reader.ReadInt16();
                if (id >= 0 && id < Packets.Count)
                {
                    p = (Packet)Activator.CreateInstance(Packets[id]);
                    p.PacketType = Packets[id];
                    ReadObject(reader, p);
                }
            }

            p.Length = length;

            return p;
        }


        public byte[] GetPacketBytes()
        {
            byte[] packet;

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write((short)Packets.IndexOf(GetType()));
                WriteObject(writer, this);
                packet = stream.ToArray();
            }

            Length = packet.Length;

            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(packet.Length + 4); //| 4Bytes: Packet Size | Data... |
                writer.Write(packet);

                return stream.ToArray();
            }
        }

        private void WriteObject(BinaryWriter writer, object packet)
        {
           
        }

        /// <summary>
        /// 读取继承Packet 的公共属性
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="ob"></param>
        private static void ReadObject(BinaryReader reader,object ob)
        {
            Type type = ob.GetType();
            PropertyInfo[] properties = type.GetProperties();

            //判断读到的类型集合
            foreach (PropertyInfo item in properties)
            {
                if (item.GetCustomAttribute<IgnorePropertyPacket>() != null) return;
                Func<BinaryReader, object> readAction;
                if(!TypeRead.TryGetValue(item.PropertyType, out readAction))
                {
                    //判断类或者委托
                    if (item.PropertyType.IsClass)
                    {
                        if (!reader.ReadBoolean()) continue;
                        item.SetValue(ob, Activator.CreateInstance(item.PropertyType));
                    }

                    //判断枚举
                    if (item.PropertyType.IsEnum)
                        item.SetValue(ob, TypeRead[item.PropertyType.GetEnumUnderlyingType()](reader));
                    //判断是否是泛型
                    else if (item.PropertyType.IsGenericType)
                    {
                        ///判断是否为集合
                        if (item.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {

                            IList list = (IList)item.GetValue(ob);
                            int count = reader.ReadInt32();
                            Type genType = item.PropertyType.GetGenericArguments()[0];
                            //判断值相等
                            if (!TypeRead.TryGetValue(genType, out readAction))
                            {
                                if (genType.IsEnum)
                                {
                                    ///读取枚举基础类
                                    genType = genType.GetEnumUnderlyingType();

                                    for (int i = 0; i < count; i++)
                                        list.Add(TypeRead[genType](reader));
                                }
                                else
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        ///读取Bool值流
                                        if (!reader.ReadBoolean()) continue;
                                        ///创建流的实例
                                        object value = Activator.CreateInstance(genType);
                                        list.Add(value);
                                        ReadObject(reader, value);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < count; i++)
                                    list.Add(readAction(reader));
                            }

                        }
                        else if (item.PropertyType.GetGenericTypeDefinition() == typeof(SortedDictionary<,>))
                        {
                            IDictionary dictionary = (IDictionary)item.GetValue(ob);

                            int count = reader.ReadInt32();

                            Type genKey = item.PropertyType.GetGenericArguments()[0];
                            Type genValue = item.PropertyType.GetGenericArguments()[1];

                            Func<BinaryReader, object> keyAction = null;
                            Func<BinaryReader, object> valueAction = null;

                            if (!TypeRead.TryGetValue(genKey, out keyAction))
                            {
                                if (genKey.IsEnum)
                                    keyAction = TypeRead[genKey.GetEnumUnderlyingType()];
                            }

                            if (!TypeRead.TryGetValue(genValue, out valueAction))
                            {
                                if (genValue.IsEnum)
                                    valueAction = TypeRead[genValue.GetEnumUnderlyingType()];
                            }
                        }



                    }


                }

            }

        }


    }

    [AttributeUsage(AttributeTargets.Property)]
    internal class IgnorePropertyPacket : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    internal class CompleteObject : Attribute
    {

    }
}