using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace 네트워크_정보_클래스_IPEndPoint_
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress IPinfo = IPAddress.Parse("127.0.0.1");
            int Port = 13;
            IPEndPoint EndPointInfo = new IPEndPoint(IPinfo, Port);
            Console.WriteLine("ip: {0} Port: {1}", EndPointInfo.Address, EndPointInfo.Port);
            Console.WriteLine(EndPointInfo.ToString());
            Console.ReadKey();
        }
    }
}
