using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 동기화_모니터_객체__
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
        public int Count = 0;

        public void ThreadProc()
        {
            Monitor.Enter(lockObject);

            for(int i = 0; i< 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID: {0} Count: {1}",
                    Thread.CurrentThread.GetHashCode(), Count);
            }

            Monitor.Exit(lockObject);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for(int i = 0; i< 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }

            for(int i=0; i < 3; i++)
            {
                threads[i].Start();
            }
        }
    }
}
