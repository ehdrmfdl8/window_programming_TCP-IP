using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace 네트워크전송클래스_BinaryWrite__server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryWriter bw = new BinaryWriter(ns))
            {
                bool YesNO = true;
                int Number = 12;
                float Pi = 3.14f;
                string Message = "Hello World";

                bw.Write(YesNO);
                bw.Write(Number);
                bw.Write(Pi);
                bw.Write(Message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
