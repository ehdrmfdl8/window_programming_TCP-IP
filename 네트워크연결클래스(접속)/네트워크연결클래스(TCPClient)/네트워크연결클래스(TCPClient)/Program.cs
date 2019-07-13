using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace 네트워크연결클래스_TCPClient_
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("10.20.18.83", 7);
            if (tcpClient.Connected)
                Console.WriteLine("서버 연결 성공");
            else
                Console.WriteLine("서버 연결 실패");

            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
