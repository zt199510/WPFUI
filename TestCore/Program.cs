using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("begin");
            //Thread thread = new(()=> TeadMehod(2));
            //thread.IsBackground = true;
            //thread.Start();
            //Thread thread1 = new Thread(() => TeadMehod1());
            ////设置thread1优先级为最高，系统尽可能单位时间内调度该线程，默认为Normal
            //thread1.Priority = ThreadPriority.Highest;
            //thread1.Start();

            //Thread thread2 = new Thread((state) => TeadMehod2(state));
            //thread2.Start("data");
            //thread2.Join();//等待thread2执行完成
            //Console.WriteLine("end");
            //await Task.Run(() => {
            //     var threadId = Thread.CurrentThread.ManagedThreadId;
            //     var isBackgound = Thread.CurrentThread.IsBackground;
            //     var isThreadPool = Thread.CurrentThread.IsThreadPoolThread;
            //     Thread.Sleep(3000);//模拟耗时操作
            //     Console.WriteLine($"task1 work on thread:{threadId},isBackgound:{isBackgound},isThreadPool:{isThreadPool}");
            //          new Task(() =>
            // {
            //     var threadId = Thread.CurrentThread.ManagedThreadId;
            //     var isBackgound = Thread.CurrentThread.IsBackground;
            //     var isThreadPool = Thread.CurrentThread.IsThreadPoolThread;
            //     Thread.Sleep(3000);//模拟耗时操作
            //     Console.WriteLine($"task1 work on thread:{threadId},isBackgound:{isBackgound},isThreadPool:{isThreadPool}");
            // }).Start();

            //    Thread.Sleep(3000);//模拟耗时操作
            //});

            if(12%6==0)
                Console.WriteLine("1");
            Console.WriteLine("NO");

        }

        private static T RequestApi<T>(string origin, string origin_region, string destination, string destination_region, string mode)
        {
            string apiUrl = "http://api.map.baidu.com/direction/v1";
            //string ak = "E4805d16520de693a3fe707cdc962045";
            string apiKey = "KpgCpbyIUfKE7h2fTO9E4LwLr0N7fWE7"; //
            string output = "json";
            //string origin_region = "北京";
            //string origin = "清华大学";
            //string destination = "北京大学";
            //string destination_region = "北京";
            //string mode = "driving";
            IDictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ak", apiKey);
            param.Add("output", output);
            if (mode == "driving")
            {
                param.Add("origin_region", origin_region);
                param.Add("destination_region", destination_region);
            }
            else
            {
                param.Add("region", origin_region);
            }

            param.Add("origin", origin);
            param.Add("destination", destination);
            param.Add("mode", mode);

            string result = string.Empty;

            //初始化方案信息实体类。
            T info = default(T);
            try
            {
                //以 Get 形式请求 Api 地址
                result = HttpUtils.DoGet(apiUrl, param);
              
            }
            catch (Exception)
            {
                info = default(T);
                throw;
            }

            return info;
        }
        static void TeadMehod2(object status)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"TestMethod2 :run on Thread id :{Thread.CurrentThread.ManagedThreadId},is threadPool:{Thread.CurrentThread.IsThreadPoolThread}" +
               $",is Backgound:{Thread.CurrentThread.IsBackground},result:{status}");
        }
        static void TeadMehod(int a)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"TestMethod: run on Thread id :{Thread.CurrentThread.ManagedThreadId},is threadPool:{Thread.CurrentThread.IsThreadPoolThread}" +
                $",is Backgound:{Thread.CurrentThread.IsBackground}, result:{a}");
        }
        static void TeadMehod1()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"TestMethod1: run on Thread id :{Thread.CurrentThread.ManagedThreadId},is threadPool:{Thread.CurrentThread.IsThreadPoolThread}" +
                $",is Backgound:{Thread.CurrentThread.IsBackground},no result ");
        }
    }

    public class HttpUtils
    {

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public static string DoGet(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildPostData(parameters);
                }
                else
                {
                    url = url + "?" + BuildPostData(parameters);
                }
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = "GET";
            req.KeepAlive = true;
            req.UserAgent = "Test";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            HttpWebResponse rsp = null;
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    rsp = null;
                }
            }

            if (rsp != null)
            {
                if (rsp.CharacterSet != null)
                {
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        private static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            StringBuilder result = new StringBuilder();
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);

                // 每次读取不大于256个字符，并写入字符串
                char[] buffer = new char[256];
                int readBytes = 0;
                while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(buffer, 0, readBytes);
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    result = new StringBuilder();
                }
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }

            return result.ToString();
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典。</param>
        /// <returns>URL编码后的请求数据。</returns>
        private static string BuildPostData(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(Uri.EscapeDataString(value));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }

    }
}
