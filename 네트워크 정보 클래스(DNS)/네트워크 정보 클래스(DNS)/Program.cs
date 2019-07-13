using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace 네트워크_정보_클래스_DNS_
{
    class Program
    {
        static void Main(string[] args)
        {
            //지역에 따라 IP가 바뀜
            IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            foreach(IPAddress HostIP in IP)
            {
                Console.WriteLine("{0} ", HostIP);
            }
        }
    }
}
