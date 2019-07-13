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

namespace 서버IP알아내기_윈도우_
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private BinaryReader br = null;
        private BinaryWriter bw = null;
        private NetworkStream ns;

        int intValue;
        float floatValue;
        string strValue;

        private void AllClose()
        {
            if(bw != null)
            { bw.Close(); bw = null; }
            if(br != null)
            { br.Close(); br = null; }
            if(ns != null)
            { ns.Close(); ns = null; }
            if(tcpClient != null)
            { tcpClient.Close(); tcpClient = null; }
        }

        private int DataReceive()
        {
            intValue = br.ReadInt32();
            if (intValue == -1)
                return -1;
            floatValue = br.ReadSingle();
            strValue = br.ReadString();
            string str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);
            return 0;
        }

        private void DataSend()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);

            MessageBox.Show("보냈습니다.");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            //호스트의 이름을 알아낸뒤 호스트의 정보를 알아냄ㅏ
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for(int i = 0; i < host.AddressList.Length; i++)
            {
                if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox1.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }
        // 접속 시작 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            tcpClient = tcpListener.AcceptTcpClient();
            if(tcpClient.Connected)
            {
                textBox2.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            }

            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while(true)
            {
                if(tcpClient.Connected)
                {
                    if (DataReceive() == -1)
                        break;
                    DataSend();
                }
                else
                {
                    AllClose();
                    break;
                }
            }
            AllClose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            tcpListener.Stop();
        }
    }
}
