using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace 네트워크전송클래스_BinaryWrite__Client
{
    class Program
    {
        static void Main(string[] args)
        {
            bool YesNo;
            int Number;
            float Pi;
            string Message;

            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryReader br = new BinaryReader(ns))
            {
                YesNo = br.ReadBoolean();
                Number = br.ReadInt32();
                Pi = br.ReadSingle();
                Message = br.ReadString();
            }
            ns.Close();
            tcpClient.Close();

            Console.WriteLine(YesNo);
            Console.WriteLine(Number);
            Console.WriteLine(Pi);
            Console.WriteLine(Message);
        }
    }
}
