using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets; // TCPLISTENER 네임스페이스
namespace 네트워크연결클래스_TCPListener_
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 13);
            Console.WriteLine("{0}", tcpListener.LocalEndpoint.ToString());
            Console.ReadKey();
        }
    }
}
