using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace 네트워크전송클래스_netstream_
{
    class Program
    {
        //서버
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
            tcpListener.Start();
            byte[] Buffer = new byte[1024];
            int TotalByteCount = 0, ReadByteCount = 0;

            Console.WriteLine("서버");

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream dg = tcpClient.GetStream();

            while(true)
            {
                ReadByteCount = dg.Read(Buffer, 0, Buffer.Length);
                if (ReadByteCount == 0)
                    break;

                TotalByteCount += ReadByteCount;
                dg.Write(Buffer, 0, ReadByteCount);
                Console.Write(Encoding.ASCII.GetString(Buffer));
                
            }

            dg.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
