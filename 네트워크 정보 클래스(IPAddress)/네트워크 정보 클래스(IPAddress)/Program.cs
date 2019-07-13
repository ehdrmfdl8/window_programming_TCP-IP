using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //IP address 사용하기 위한 네임스페이스

namespace 네트워크_정보_클래스_IPAddress_
{
    class Program
    {
        static void Main(string[] args)
        {
            string Address = Console.ReadLine();
            IPAddress IP = IPAddress.Parse(Address);
            Console.WriteLine("ip : {0}", IP.ToString());
        }
    }
}
