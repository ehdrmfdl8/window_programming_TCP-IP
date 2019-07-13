using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace 동기화_Mutex_객체__
{
    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }
    class Test
    {
        ThisLock lockObject = new ThisLock();
        Mutex mut = new Mutex();
        public int Count;

        public void ThreadProc()
        {
            mut.WaitOne();//enter
            for (int i = 0; i < 3; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0} Count: {1} ", Thread.CurrentThread.GetHashCode(), Count);
            }
            mut.ReleaseMutex(); //Exit
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }
        }
    }
}
