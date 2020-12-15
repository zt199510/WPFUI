using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Test
{
    public class CommonFunTool
    {
   
        public CommonFunTool()
        {
           
        }
        /// <summary>
        /// 生成唯一uuId方法
        /// </summary>
        /// <returns>生成后的GUid</returns>
        public static string GetUUId()
        {
            return Guid.NewGuid().ToString();
        }


        ///<summary> 随机生成字符
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
         ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
         ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
         ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRnd(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName
            );

        [DllImport("kernel32.dll")]
        public static extern int WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFileName
            );

        /// <summary>
        /// 将自定义对象序列化为XML文件保存
        /// </summary>
        /// <param name="myObject">自定义对象实体</param>
        /// <param name="FilePath">地址</param>
        public static bool SerializeToXmlFile<T>(T myObject, string FilePath)
        {
            TextWriter writer = null;
            try
            {
                if (myObject == null)
                    throw new ArgumentNullException("XMLObjet is null");
                using (writer = new StreamWriter(FilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(myObject.GetType());
                    XmlWriterSettings settings = new XmlWriterSettings();
                    serializer.Serialize(writer, myObject);
                    writer.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("将实体对象转换成XML异常，详细信息：" + ex.Message);
                return false;
            }
            finally
            {
                if (writer != null)
                {

                    writer.Dispose();
                }

            }
        }
      
        /// <summary>
        /// 将XML转换成实体对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="strXML">XML</param>
        public static T SerializerXMLToObject<T>(string strXML) where T : class
        {
            StreamReader sr = null;

            if (!File.Exists(strXML))
            {
                throw new ArgumentNullException("path is null");
            }
            try
            {
                using (sr = new StreamReader(strXML))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    T obj = xs.Deserialize(sr) as T;
                    sr.Close();
                    return obj;
                }
            }
            catch (Exception ex)
            {
              
                return null;
            }
            finally
            {
                if (sr != null)
                {

                    sr.Dispose();
                }
            }
        }

        /// <summary>
        /// 判断bin目录下文件夹是否存在
        /// </summary>
        /// <param name="FilePath">bin目录下的文件名</param>
        /// <param name="isCreate">不存在是否创建</param>
        /// <returns></returns>
        public static bool GetExistsDirectoryPath(string FilePath, bool isCreate)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    if (isCreate)
                    {
                        Directory.CreateDirectory(FilePath);
                        return true;
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("将实体对象转换成XML异常，详细信息：" + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 判断bin目录下文件夹是否存在
        /// </summary>
        /// <param name="FilePath">文件名</param>
        /// <returns></returns>
        public static bool GetExistsFilePath(string FilePath)
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("将实体对象转换成XML异常，详细信息：" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 读取ini文件
        /// </summary>        
        public static string ReadString(string section, string name, string def, string iniFile)
        {
            StringBuilder vRetSb = new StringBuilder(512);
            GetPrivateProfileString(section, name, def, vRetSb, 2048, iniFile);
            return vRetSb.ToString();
        }
   

    }
}
