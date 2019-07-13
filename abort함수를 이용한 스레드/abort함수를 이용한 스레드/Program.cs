using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace abort함수를_이용한_스레드
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc1));
            th.Start();
            Console.WriteLine("Main 스레드 {0}", Thread.CurrentThread.GetHashCode());
            th.Join();
            Console.WriteLine("Main 종료");
        }

        private static void ThreadProc1()
        {
            Console.WriteLine("ThreadProc1 스레드 {0}", Thread.CurrentThread.GetHashCode());
            Thread th = new Thread(new ThreadStart(ThreadProc2));
            th.Start();

            for(int i = 0; i<10; i++)
            {
                Console.Write("{0} ", i * 10);
                Thread.Sleep(200);

                if( i == 3)
                {
                    Console.WriteLine("ThreadProc1 종료");
                    Thread.CurrentThread.Abort();
                }
            }
        }

        static void ThreadProc2()
        {
            Console.WriteLine("ThreadProc2 스레드 {0}",
                Thread.CurrentThread.GetHashCode());
            for(int i=0; i<10; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(200);
            }
            Console.WriteLine("ThreadProc2 종료");
        }
    }
}
