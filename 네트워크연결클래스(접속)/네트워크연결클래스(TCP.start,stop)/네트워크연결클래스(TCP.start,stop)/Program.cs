using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace 네트워크연결클래스_TCP.start_stop_
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("10.20.18.83"), 7);//현재 ip 넣기 생략해도 됨
            tcpListener.Start();
            Console.WriteLine("대기 상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();//연결요청 수락
            Console.WriteLine("대기 상태 종료");
            tcpListener.Stop();
        }
    }
}
