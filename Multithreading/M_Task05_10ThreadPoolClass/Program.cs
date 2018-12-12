using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M_Task05_10ThreadPoolClass
{
    class Program
    {
        static Semaphore sync = new Semaphore(0, 4);
        const int NUM_THREADS = 10;
        static int state = 20;

        static void CreateThread(int n)
        {
            if (n > 0)
            {
                var num = (NUM_THREADS - n) + 1;
                Console.WriteLine("Creating thread #" + num);
                ThreadPool.QueueUserWorkItem(Callback, state);
                n--;
                CreateThread(n);
            }
        }

        static void Main(string[] args)
        {
            CreateThread(10);

            Thread.Sleep(1000);
            Console.ReadKey();
        }

        static void Callback(object state)
        {
            sync.WaitOne();
            var value = (int)state;
            value--;
            Console.WriteLine(value);
            state = value;
            sync.Release();
        }
    }
}
