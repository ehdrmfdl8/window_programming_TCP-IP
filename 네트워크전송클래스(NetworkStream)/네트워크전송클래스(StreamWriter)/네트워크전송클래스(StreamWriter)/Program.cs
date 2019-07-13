using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace 네트워크전송클래스_StreamWriter_
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            bool YesNO = false;
            int Val1 = 12;
            float Pi = 3.14f;
            string Message = "Hello World";

            NetworkStream ns = tcpClient.GetStream();
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.AutoFlush = true;
                sw.WriteLine(YesNO);
                sw.WriteLine(Val1);
                sw.WriteLine(Pi);
                sw.WriteLine(Message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();

        }
    }
}
