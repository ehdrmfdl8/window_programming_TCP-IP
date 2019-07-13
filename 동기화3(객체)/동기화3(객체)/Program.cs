using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace 동기화3_객체_
{
    //객체를
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
        int Count = 0;

        public void ThreadProc()
        {
            lock(lockObject)// <-- object형으로 처리해도 결과는 동일하다.
            {
                for (int i = 0; i < 3; i++)
                {
                    lockObject.IncreaseCount(ref Count);
                    Console.WriteLine("thread ID: {0} Count: {1}", Thread.CurrentThread.GetHashCode(), Count);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[10];
            for(int i =0; i<10; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }

            for(int i=0;i<10;i++)
            {
                threads[i].Start();
            }
        }
    }
}
