using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

using System.Collections.Concurrent;
using System.Reflection;
using G = DotServer.GeneralPackets;
namespace DotServer
{
   public abstract class BaseConnection
    {
        public static Dictionary<string, DiagnosticValue> Diagnostics = new Dictionary<string, DiagnosticValue>();
        public static Dictionary<Type, MethodInfo> PacketMethods = new Dictionary<Type, MethodInfo>();
        public static bool Monitor;

        /// <summary>
        /// 是否连接
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// 发送
        /// </summary>
        protected bool Sending { get; set; }
        /// <summary>
        ///  发送数据大小
        /// </summary>
        public int TotalBytesSent { get; set; }
        /// <summary>
        /// 收到数据大小
        /// </summary>
        public int TotalBytesReceived { get; set; }

        public bool AdditionalLogging;

        /// <summary>
        /// 客户端
        /// </summary>
        protected TcpClient TcpClient;

        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime TimeConnected { get; set; }
        public TimeSpan Duration => Time.Now - TimeConnected;


  
        /// <summary>
        /// 发送时间间隔
        /// </summary>
        protected abstract TimeSpan TimeOutDelay { get; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime TimeOutTime { get; set; }
        private bool _disconnecting;

        public bool Disconnecting
        {
            get { return _disconnecting; }
            set {
                if (_disconnecting == value) return;
                _disconnecting = value;
                TimeOutTime = Time.Now.AddSeconds(2);
            }
        }
        public ConcurrentQueue<Packet> ReceiveList = new ConcurrentQueue<Packet>(); 
        public ConcurrentQueue<Packet> SendList = new ConcurrentQueue<Packet>();

        private byte[] _rawData = new byte[0];

        public EventHandler<Exception> OnException;

        public BaseConnection(TcpClient client)
        {
            this.TcpClient = client;
            client.NoDelay = true;

            Connected = true;
            TimeConnected = Time.Now;
        }

        /// <summary>
        /// 开始接受数据
        /// </summary>
       protected void BeginReceive()
        {
            try
            {
                if (TcpClient == null || !TcpClient.Connected) return;

                byte[] rawBytes = new byte[8 * 1024];

                TcpClient.Client.BeginReceive(rawBytes, 0, rawBytes.Length, SocketFlags.None, ReceiveData, rawBytes);
            }
            catch (Exception ex)
            {

                if (AdditionalLogging)
                    OnException(this, ex);
                Disconnecting = true;
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="result"></param>
        private void ReceiveData(IAsyncResult result)
        {
            try
            {
                if (!Connected) return;

                int dataRead = TcpClient.Client.EndReceive(result);

                if (dataRead == 0)
                {
                    Disconnecting = true;
                    return;
                }

                TotalBytesReceived += dataRead;

                UpdateTimeOut();

                byte[] rawBytes = result.AsyncState as byte[];

                byte[] temp = _rawData;
                _rawData = new byte[dataRead + temp.Length];
                Buffer.BlockCopy(temp, 0, _rawData, 0, temp.Length);
                Buffer.BlockCopy(rawBytes, 0, _rawData, temp.Length, dataRead);
                Packet p;
                while ((p = Packet.ReceivePacket(_rawData, out _rawData)) != null)
                    ReceiveList.Enqueue(p);

                BeginReceive();


            }
            catch (Exception ex)
            {
                if (AdditionalLogging)
                    OnException(this, ex);
                Disconnecting = true;

            }
           
        }

        /// <summary>
        /// 开始发送数据
        /// </summary>
        /// <param name="data"></param>
        private void BeginSend(List<byte> data)
        {
            if (!Connected || data.Count == 0) return;

            try
            {
                Sending = true;
                TotalBytesSent += data.Count;
                TcpClient.Client.BeginSend(data.ToArray(), 0, data.Count, SocketFlags.None, SendData, null);
                UpdateTimeOut();
            }
            catch (Exception ex)
            {
                if (AdditionalLogging)
                    OnException(this, ex);
                Disconnecting = true;
                Sending = false;
            }
        }
        /// <summary>
        ///  //发送数据
        /// </summary>
        /// <param name="result"></param>
        private void SendData(IAsyncResult result)
        {
            try
            {
                Sending = false;
                TcpClient.Client.EndSend(result);
                UpdateTimeOut();
            }
            catch (Exception ex)
            {
                if (AdditionalLogging)
                    OnException(this, ex);
                Disconnecting = true;
            }
        }

        /// <summary>
        /// 将数据添加到任务队列
        /// </summary>
        /// <param name="p"></param>
        public virtual void Enqueue(Packet p)
        {
            if (!Connected || p == null) return;

            SendList.Enqueue(p);
        }

        public abstract void TryDisconnect();

        public virtual void Disconnect()
        {
            if (!Connected) return;

            Connected = false;

            SendList = null;
            ReceiveList = null;
            _rawData = null;

            TcpClient.Client.Dispose();
            TcpClient = null;
        }

        public abstract void TrySendDisconnect(Packet p);
       
        /// <summary>
        /// 将发送数据转化为byte[]
        /// </summary>
        /// <param name="p"></param>
        public virtual void SendDisconnect(Packet p)
        {
            if (!Connected || Disconnecting)
            {
                Disconnecting = true;
                return;
            }

            List<byte> data = new List<byte>();

            data.AddRange(p.GetPacketBytes());

            BeginSendDisconnect(data);
        }
        /// <summary>
        /// 发送字段
        /// </summary>
        /// <param name="data"></param>
        private void BeginSendDisconnect(List<byte> data)
        {
            if (!Connected || data.Count == 0) return;

            if (Disconnecting) return;

            try
            {
                Disconnecting = true;

                TotalBytesSent += data.Count;
                TcpClient.Client.BeginSend(data.ToArray(), 0, data.Count, SocketFlags.None, SendDataDisconnect, null);
            }
            catch (Exception ex)
            {
                if (AdditionalLogging)
                    OnException(this, ex);
            }
        }
        /// <summary>
        /// 发送结束
        /// </summary>
        /// <param name="result"></param>
        private void SendDataDisconnect(IAsyncResult result)
        {
            try
            {
                TcpClient.Client.EndSend(result);
            }
            catch (Exception ex)
            {
                if (AdditionalLogging)
                    OnException(this, ex);
            }
        }

        public virtual void Process()
        {
            if (TcpClient == null || !TcpClient.Connected)
            {
                TryDisconnect();
                return;
            }

            while (!ReceiveList.IsEmpty && !Disconnecting)
            {
                try
                {
                    Packet p;
                    if (!ReceiveList.TryDequeue(out p)) continue;
                    ProcessPacket(p);
                }
                catch (NotImplementedException ex)
                {
                    OnException(this, ex);
                }
                catch (Exception ex)
                {
                    OnException(this, ex);
                    throw ;
                }
            }

            if(Time.Now >= TimeOutTime)
            {
                if (!Disconnecting)
                    TrySendDisconnect(new G.Disconnect { Reason = DisconnectReason.TimedOut });
                else
                    TryDisconnect();

                return;
            }

            if (!Disconnecting && Sending)
                UpdateTimeOut();

            if (SendList.IsEmpty || Sending) return;

            List<byte> data = new List<byte>();
            while (!SendList.IsEmpty)
            {
                Packet p;

                if (!SendList.TryDequeue(out p)) continue;
                if (p == null) continue;

                try
                {
                    byte[] bytes = p.GetPacketBytes();

                    data.AddRange(bytes);
                }
                catch (Exception ex)
                {
                    OnException?.Invoke(this, ex);
                    Disconnecting = true;
                    return;
                }

                if (!Monitor) continue;

                DiagnosticValue value;
                Type type = p.GetType();

                if (!Diagnostics.TryGetValue(type.FullName, out value))
                    Diagnostics[type.FullName] = value = new DiagnosticValue { Name = type.FullName };

                value.Count++;
                value.TotalSize += p.Length;

                if (p.Length > value.LargestSize)
                    value.LargestSize = p.Length;
            }

            BeginSend(data);
        }

        private void ProcessPacket(Packet p)
        {
            if (p == null) return;
            DateTime start = Time.Now;
            MethodInfo info;
            if (!PacketMethods.TryGetValue(p.PacketType, out info))
                PacketMethods[p.PacketType] = info = GetType().GetMethod("Process", new[] { p.PacketType });
            if (info == null)
                throw new NotImplementedException($"未执行异常: 方式过程({p.PacketType}).");

            info.Invoke(this, new object[] { p });

            if (!Monitor) return;

            TimeSpan execution = Time.Now - start;
            DiagnosticValue value;


            if (!Diagnostics.TryGetValue(p.PacketType.FullName, out value))
                Diagnostics[p.PacketType.FullName] = value = new DiagnosticValue { Name = p.PacketType.FullName };

            value.Count++;
            value.TotalTime += execution;
            value.TotalSize += p.Length;


            if (execution > value.LargestTime)
                value.LargestTime = execution;

            if (p.Length > value.LargestSize)
                value.LargestSize = p.Length;

        }

        private void UpdateTimeOut()
        {
            if (Disconnecting) return;

            TimeOutTime = Time.Now + TimeOutDelay;
        }
    }

    public class DiagnosticValue
    {
        public string Name { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan LargestTime { get; set; }
        public int Count { get; set; }
        public long TotalSize { get; set; }
        public long LargestSize { get; set; }

        public long TotalTicks => TotalTime.Ticks;
        public long TotalMilliseconds => TotalTicks / TimeSpan.TicksPerMillisecond;

        public long LargestTicks => LargestTime.Ticks;
        public long LargestMilliseconds => LargestTicks / TimeSpan.TicksPerMillisecond;
    }
}
