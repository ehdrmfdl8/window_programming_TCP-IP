using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
// CurrentThread 속성에 있는 GetHashCode()를 통해 스레드의 아이디를 알아내기 위한 코드
namespace CurrentThread_속성다루기
{
    class Program
    {
        static void ThreadProc()
        {
            Console.WriteLine("스레드 id: {0}", Thread.CurrentThread.GetHashCode());
        }
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc));
            th.Start();
            Console.WriteLine("Main 스레드 id: {0}", Thread.CurrentThread.GetHashCode());
            
        }
    }
}
