using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display
{
    class ClientControl
    {
        private Socket clientSocket;
        public bool connState;
        string currentIp = string.Empty;
        int currentPort;

        //public ClientControl()
        //{
        //    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //}

        public void Connect(string ip, int port)
        {
            currentIp = ip;
            currentPort = port;

            ///创建终结点EndPoint
            IPAddress ip1 = IPAddress.Parse(ip);
            //IPAddress ipp = new IPAddress("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(ip1, port);//把ip和端口转化为IPEndpoint实例

            ///创建socket并连接到服务器
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
            clientSocket.Connect(ipe);//连接到服务器
                                      //clientSocket.setKeepAlive(true);

            if (clientSocket.Connected == true)
            {
                connState = true;
                MessageBox.Show("服务器连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                connState = false;
                MessageBox.Show("服务器连接失败！请检查后重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public  void ReadAndSend(string msg/*1,string msg2,string msg3,string msg4,string msg5*//*,string ip,int port*/)
        {
            try
            {
                if (clientSocket.Connected == true)
                {
                    //byte[] txt = Encoding.Unicode.GetBytes(msg);
                    //clientSocket.Send(txt);
                    clientSocket.Send(Encoding.Default.GetBytes(msg));
                    MessageBox.Show("发送成功！");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                }
                else
                {
                    ///创建终结点EndPoint
                    IPAddress ip1 = IPAddress.Parse(currentIp);
                    //IPAddress ipp = new IPAddress("127.0.0.1");
                    IPEndPoint ipe = new IPEndPoint(ip1, currentPort);//把ip和端口转化为IPEndpoint实例

                    ///创建socket并连接到服务器
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
                    clientSocket.Connect(ipe);//连接到服务器
                    //clientSocket.setKeepAlive(true);
                    clientSocket.Send(Encoding.Default.GetBytes(msg));
                    MessageBox.Show("发送成功！");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Thread.Sleep(1);
            }
        }
    }
}
