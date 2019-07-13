using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace 스레드_프로그래밍
{
    class Program
    {
        static void Func()
        {
            Console.WriteLine("스레드에서 호출");
        }

        static void paramerizedFunc2(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
                Console.WriteLine("Parameterized 스레드에서 호출: {0}",i);
        }
        static void Main(string[] args)
        {
            //Thread th = new Thread(new ThreadStart(Func));
            //th.Start();

            int i = 5;
            Thread th2 = new Thread(new ParameterizedThreadStart(paramerizedFunc2));
            th2.Start(i);
        }
    }
}
