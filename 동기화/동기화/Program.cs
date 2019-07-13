using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 동기화
{
    class Test
    {
        //Count 는 공유자원
        static int Count;

        public void ThreadProc()
        {
            for (int i = 0; i <100; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0} result: {1}",
                    Thread.CurrentThread.GetHashCode(), Count);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
