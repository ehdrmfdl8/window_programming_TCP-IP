using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace 배경_스레드와_포그라운드_스레드
{
    class Program
    {
        static void Func()
        {
            int i = 0;
            while(true)
            {
                Console.Write("{0} ", i++);
                Thread.Sleep(300);
            }
        }
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func));
            th.Start();
            Console.WriteLine("Main 종료");
        }
    }
}
