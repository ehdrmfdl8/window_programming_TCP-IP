using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
//스레드를 이용해서 1대 다 통신을 하기 위한 코드

namespace 스레드를_이용한_네트워크_프로그래밍
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;

        public Form1()
        {
            InitializeComponent();
        }
        private void AcceptClient()
        {
            while(true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                if(tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    listBox1.Items.Add(str);
                }
                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));
                th.IsBackground = true;
                th.Start();
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //클라이언트의 요청을 계속 받기위한 코드
            Thread th = new Thread(new ThreadStart(AcceptClient));
            th.IsBackground = true;
            th.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for(int i = 0; i< host.AddressList.Length; i++)
            {
                if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox1.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
    }
    class EchoServer
    {
        TcpClient RefClient;
        private BinaryReader br = null;
        private BinaryWriter bw = null;
        int intValue;
        float floatValue;
        string strValue;

        public EchoServer(TcpClient Client)
        {
            RefClient = Client;
        }

        public void Process()
        {
            NetworkStream ns = RefClient.GetStream();
            try
            {
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);

                while (true)
                {
                    intValue = br.ReadInt32();
                    floatValue = br.ReadSingle();
                    strValue = br.ReadString();

                    bw.Write(intValue);
                    bw.Write(floatValue);
                    bw.Write(strValue);
                }
            }
            catch (SocketException se)
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                MessageBox.Show(se.Message);
                Thread.CurrentThread.Abort();
            }
            catch (IOException ex)
            {
                //연결이 끊어져서 읽을수가 없을때 처리
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                MessageBox.Show(ex.Message);
                Thread.CurrentThread.Abort();

            }
        }
    }
}
