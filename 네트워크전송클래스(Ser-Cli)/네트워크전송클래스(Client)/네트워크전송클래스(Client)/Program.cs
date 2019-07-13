using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace 네트워크전송클래스_Client_
{
    class Program
    {
        //클라이언트
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream dg = tcpClient.GetStream();
            Console.WriteLine("클라이언트");
            byte[] Buffer = new byte[1024];
            byte[] SendMessage = Encoding.ASCII.GetBytes("Hello World");
            dg.Write(SendMessage, 0, SendMessage.Length);
            int TotalCount = 0, ReadCount = 0;

            while( TotalCount < SendMessage.Length)
            {
                ReadCount = dg.Read(Buffer, 0, Buffer.Length);
                TotalCount += ReadCount;

                string ReceiveMessage = Encoding.ASCII.GetString(Buffer);
                Console.Write(ReceiveMessage);
            }

            Console.WriteLine("받은 문자열 바이트 수 : {0}", TotalCount);
            dg.Close();
            tcpClient.Close();
        }
    }
}
