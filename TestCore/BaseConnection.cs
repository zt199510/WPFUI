using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections.Concurrent;

namespace TestCore
{
   public abstract class BaseConnection
    {

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


    }
}
