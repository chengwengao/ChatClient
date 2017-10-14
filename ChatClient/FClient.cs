using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace ChatClient
{
    public partial class FClient : Form
    {
        public FClient()
        {
            InitializeComponent();
            //关闭对文本框的非法线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        //创建 1个客户端套接字 和1个负责监听服务端请求的线程  
        Socket socketClient = null; 
        Thread threadClient = null;

        //测试
        List<Socket> socketClientList = new List<Socket>();
        List<Thread> threadClientList= new List<Thread>();

        private void btnBeginListen_Click(object sender, EventArgs e)
        {
            createSingleSocketListen();
        }

        //客户端连接服务端时创建单个套接字监听
        public void createSingleSocketListen()
        {
            //定义一个套接字监听  包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //需要获取文本框中的IP地址
            IPAddress ipaddress = IPAddress.Parse(txtIP.Text.Trim());
            //将获取的ip地址和端口号绑定到网络节点endpoint上
            IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(txtPort.Text.Trim()));
            //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
            socketClient.Connect(endpoint);
            //创建一个线程 用于监听服务端发来的消息
            threadClient = new Thread(RecMsg);
            //将窗体线程设置为与后台同步
            threadClient.IsBackground = true;
            //启动线程
            threadClient.Start();
        }

        int totalSum = 0;
        //客户端连接服务端时模拟多线程创建多个套接字监听
        public void createMultiSocketListen()
        {
            for (int i=0;i< int.Parse(msgSize.Text.Trim()); i++)
            {
                //定义一个套接字监听  包含3个参数(IP4寻址协议,流式连接,TCP协议)
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //需要获取文本框中的IP地址
                IPAddress ipaddress = IPAddress.Parse(txtIP.Text.Trim());
                //将获取的ip地址和端口号绑定到网络节点endpoint上
                IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(txtPort.Text.Trim()));
                //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
                socketClient.Connect(endpoint);
                //创建一个线程 用于监听服务端发来的消息
                threadClient = new Thread(new ParameterizedThreadStart(multiRecMsg));
                //将窗体线程设置为与后台同步
                threadClient.IsBackground = true;

                socketClientList.Add(socketClient);
                threadClientList.Add(threadClient);
                //启动线程
                threadClient.Start(i);
            }
            totalSum += int.Parse(msgSize.Text.Trim());
            MessageBox.Show(msgSize + "个连接创建成功！");
            txtMsg.AppendText("总连接数：" + totalSum);
        }

        /// <summary>
        /// 接收服务端发来信息的方法,单个套接字监听
        /// </summary>
        private void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                //定义一个1K的内存缓冲区 用于临时性存储接收到的信息
                byte[] arrRecMsg = new byte[1 * 1024];
                //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                int length = socketClient.Receive(arrRecMsg);
                //将套接字获取到的字节数组转换为人可以看懂的字符串
                string strRecMsg = ExplainUtils.convertStrMsg(arrRecMsg);
                //将发送的信息追加到聊天内容文本框中
                //txtMsg.AppendText("So-flash:" + GetCurrentTime() + "\r\n" + strRecMsg + "\r\n");
                LogHelper.WriteLog("So-flash:" + GetCurrentTime() + "\r\n" + strRecMsg + "\r\n");
            }
        }

        /// <summary>
        /// 接收服务端发来信息的方法,多个套接字监听
        /// </summary>
        private void multiRecMsg(object obj)
        {
            while (true) //持续监听服务端发来的消息
            {
                //定义一个1K的内存缓冲区 用于临时性存储接收到的信息
                byte[] arrRecMsg = new byte[1 * 1024];
                //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                int length = socketClientList[int.Parse(obj.ToString())].Receive(arrRecMsg);
                //将套接字获取到的字节数组转换为人可以看懂的字符串
                string strRecMsg = ExplainUtils.convertStrMsg(arrRecMsg);
                //将发送的信息追加到聊天内容文本框中
                //txtMsg.AppendText("So-flash:" + GetCurrentTime() + "\r\n" + strRecMsg + "\r\n");
                LogHelper.WriteLog("So-flash:" + GetCurrentTime() + "\r\n" + strRecMsg + "\r\n");
            }
        }

        /// <summary>
        /// 发送字符串信息到服务端的方法，单个客户端发送消息
        /// </summary>
        /// <param name="sendMsg">发送的字符串信息</param>
        private void ClientSendMsg(string sendMsg)
        {
            //将输入的内容字符串转换为机器可以识别的字节数组
            byte[] arrClientSendMsg = ExplainUtils.HexSpaceStringToByteArray(sendMsg);
            //调用客户端套接字发送字节数组
            socketClient.Send(arrClientSendMsg);
            //将发送的信息追加到聊天内容文本框中
            //txtMsg.AppendText("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
            LogHelper.WriteLog("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
        }

        int count = 0;
        byte[] arrClientSendMsg = new byte[1024];
        /// <summary>
        /// 发送字符串信息到服务端的方法，多个客户端发送同一条消息
        /// </summary>
        /// <param name="sendMsg">发送的字符串信息</param>
        private void multiClientSendMsg(string sendMsg)
        {
            if(socketClientList.Count > 0)
            {
                for(int i = 0; i < socketClientList.Count; i++)
                {
                    //将输入的内容字符串转换为机器可以识别的字节数组
                    arrClientSendMsg = ExplainUtils.HexSpaceStringToByteArray(sendMsg);
                    //调用客户端套接字发送字节数组
                    socketClientList[i].Send(arrClientSendMsg);
                    count++;
                    //将发送的信息追加到聊天内容文本框中
                    //txtMsg.AppendText("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
                    LogHelper.WriteLog("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
                    LogHelper.WriteLog("发送消息条数:" +count + "\r\n");
                }
            }
            
        }

        //点击按钮btnSend 向服务端发送信息
        private void btnSend_Click(object sender, EventArgs e)
        {
            //调用ClientSendMsg方法 将文本框中输入的信息发送给服务端
            ClientSendMsg(txtCMsg.Text.Trim());
        }

        //快捷键 Enter发送信息
        private void txtCMsg_KeyDown(object sender, KeyEventArgs e) 
        {  
            //当光标位于文本框时 如果用户按下了键盘上的Enter键 
            if (e.KeyCode == Keys.Enter)
            {
                //则调用客户端向服务端发送信息的方法
                ClientSendMsg(txtCMsg.Text.Trim());
            }
        }

        /// <summary>
        /// 获取当前系统时间的方法
        /// </summary>
        /// <returns>当前时间</returns>
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMsg.Text = "";
            //LogHelper.WriteLog("普通日志");
            //LogHelper.ErrorLog("错误日志",new Exception());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCMsg.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtMsg.Text == "") return;
            Clipboard.SetDataObject(txtMsg.Text);
            MessageBox.Show("文本内容已复制到剪切板！");
        }

        private void ClientSendMsg(object obj)
        {
            string sendMsg = obj.ToString();
            //将输入的内容字符串转换为机器可以识别的字节数组
            byte[] arrClientSendMsg = ExplainUtils.HexSpaceStringToByteArray(sendMsg);
            //调用客户端套接字发送字节数组
            socketClient.Send(arrClientSendMsg);
            //将发送的信息追加到聊天内容文本框中
            //txtMsg.AppendText("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
            LogHelper.WriteLog("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            /*
            //该方法会粘包，弃用
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(ClientSendMsg));
                t.Start(txtCMsg.Text.Trim());
                //Thread.Sleep(2000);
            }
            */
            while (true)
            {
                multiClientSendMsg(txtCMsg.Text.Trim());
                Thread.Sleep(3 * 1000);  //模拟终端设备每隔3s发送一次
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            msgSize.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            createMultiSocketListen();
            Thread.Sleep(500);
        }

    }
}
