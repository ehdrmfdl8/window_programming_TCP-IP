using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace 네트워크연결클래스_Netstream_Client_
{
    class Program
    {
        static void Main(string[] args)
        {
            //클라이언트 부분
            TcpClient tcpClient = new TcpClient("10.20.18.83", 7);
            if(tcpClient.Connected)
            {
                Console.WriteLine("서버 연결 성공");
                NetworkStream dg = tcpClient.GetStream();
                string Message = "Hello World";//서버에 보낼 문자
                byte[] SendByteMessage = Encoding.ASCII.GetBytes(Message);
                dg.Write(SendByteMessage, 0, SendByteMessage.Length);

                byte[] ReceiveByteMessage = new byte[32];
                dg.Read(ReceiveByteMessage, 0, 32);//서버로부터 받을 데이터
                string ReceiveMessage = Encoding.ASCII.GetString(ReceiveByteMessage);
                Console.WriteLine(ReceiveMessage);
                dg.Close();
            }
            else
            {
                Console.WriteLine("서버 연결 실패!");
            }

            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
