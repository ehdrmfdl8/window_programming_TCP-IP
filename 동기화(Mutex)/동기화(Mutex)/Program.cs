using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 동기화_Mutex_
{
    //mutex를 메서드에 적용한 예
    class Program
    {
        static Mutex mut = new Mutex();
        static int Count;

        static void ThreadProc()
        {
            mut.WaitOne();//enter
            for(int i=0;i<5;i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0} Count: {1} ", Thread.CurrentThread.GetHashCode(), Count);
            }
            mut.ReleaseMutex(); //Exit
        }
        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(ThreadProc));
            Thread th2 = new Thread(new ThreadStart(ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
