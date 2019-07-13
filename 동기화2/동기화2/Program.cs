using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 동기화2
{
    //lock(object 객체명)을 사용하여 처리하는 예 1
    class Test
    {
        static object obj = new object();
        static int Count;

        public void ThreadProc()
        {
            //다른 스레드가 쓸려고 할때 대기하라는 의미
            lock(obj)
            {
                for(int i=0; i<10; i++)
                {
                    Count++;
                    Console.WriteLine("Thread ID: {0} result: {1}",
                        Thread.CurrentThread.GetHashCode(), Count);
                }
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
