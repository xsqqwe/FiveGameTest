using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;


namespace FiveGameTest.Network
{
    public class GameServer
    {
        public TcpListener server = null;
        public NetworkStream stream = null;
        public TcpClient client = null;
        public StreamReader reader = null;
        public StreamWriter writer = null;
        public Thread thread = null;

        public event Action<string> Transmit;

        private int port = 13000;
        //开启服务器监听
        public void StartListen()
        {
            if (thread == null)
            {
                thread = new Thread(Listen);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        //监听
        private void Listen()
        {
            try
            {
                //监听端口
                Int32 port = 13000;

                //在指定的商品监听所有客户端请求
                server = new TcpListener(IPAddress.Any, port);

                //开始监听客户端请求
                server.Start();

                // 
                Byte[] bytes = new Byte[256];

                //接受客户端连接
                TcpClient client = server.AcceptTcpClient();
                stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
                while (true)
                {
                    String data = null;
                    while ((data = reader.ReadLine()) != null)
                    {
                        if (Transmit != null)
                            Transmit(data);
                    }
                }
            }
            catch (SocketException e)
            {
                throw e;
            }
        }

        //停止监听
        public void Stop()
        {
            if (reader != null) reader.Close();
            if (writer != null) writer.Close();
            if (stream != null) stream.Close();
            if (server != null) server.Stop();
            if (client != null) client.Close();
            if (thread != null && thread.IsAlive)
            {
                thread.Abort(); thread = null;
            }
        }

        //连接
        public bool Connect(string hostName)
        {
            try
            {
                IPAddress ip;

                if (IPAddress.TryParse(hostName, out ip))
                {
                    client = new TcpClient(new IPEndPoint(ip, port));
                }
                else
                {
                    client = new TcpClient(hostName, port);
                }
                stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        //发数据
        public void Send(string msg)
        {
            if (writer != null)
            {
                writer.WriteLine(msg);
                writer.Flush();
            }
        }

        //收数据
        public void Recive()
        {
            if (thread == null)
            {
                thread = new Thread(
                    delegate()
                    {
                        while (true)
                        {
                            String data = null;
                            while ((data = reader.ReadLine()) != null)
                            {
                                if (Transmit != null)
                                    Transmit(data);
                            }
                        }
                    });
                thread.IsBackground = true;
                thread.Start();
            }
        }

    }
}
