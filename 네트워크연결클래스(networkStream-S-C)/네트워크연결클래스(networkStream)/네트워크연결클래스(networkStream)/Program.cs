using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace 네트워크연결클래스_networkStream_
{
    class Program
    {
        static void Main(string[] args)
        {
            //서버부분
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("10.20.18.83"), 7);
            tcpListener.Start();
            Console.WriteLine("대기상태");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();//연결 수락
            NetworkStream dg = tcpClient.GetStream();//데이터 전송 스트림
            byte[] ReceiveMessage = new byte[100];
            dg.Read(ReceiveMessage, 0, 100);//클라이언트로부터 받을 데이터
            string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
            Console.WriteLine(strMessage);

            string EchoMessage = "HI~~";//클라이언트로 보낼 데이터
            byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
            dg.Write(SendMessage, 0, SendMessage.Length);
            dg.Close();
            tcpClient.Close();
            tcpListener.Stop();
            Console.ReadKey();

        }
    }
}
