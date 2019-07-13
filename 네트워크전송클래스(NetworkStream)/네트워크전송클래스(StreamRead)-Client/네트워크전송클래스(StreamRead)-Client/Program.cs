using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace 네트워크전송클래스_StreamRead__Client
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] buffer = new char[100];
            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (StreamReader sr = new StreamReader(ns))
            {
                //StreamReader로 부터 읽은 데이터를 str로 저장
                string str = sr.ReadLine();
                //str을 클라이언트로 출력
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
            }
            ns.Close();
            tcpClient.Close();
        }
    }
}
