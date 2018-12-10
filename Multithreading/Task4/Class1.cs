using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Task4
{
    public class Task4
    {
        const int NUM_THREADS = 1;
        static Thread[] array;
        static int j;

        static void CreateThread(int n)
        {
            if (n > 0)
            {
                var num = (NUM_THREADS - n) + 1;
                Console.WriteLine("Creating thread #" + num);
                array[num - 1] = new Thread(() => Decrement(ref j));
                //array[num - 1].Start(j);
            }
            n--;
            CreateThread(n);
        }


        static void Main(string[] args)
        {
            Int32.TryParse(Console.ReadLine(), out j);
            var stopwatch = Stopwatch.StartNew();

            array = new Thread[NUM_THREADS];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    // Start the thread with a ThreadStart.
            //    array[i] = new Thread(Decrement);
            //    array[i].Start();
            //}

            CreateThread(NUM_THREADS);

            return;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Start();
            }


            for (int i = 0; i < array.Length; i++)
            {
                array[i].Join();
            }

            Console.WriteLine("DONE: {0}", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static void Decrement(ref int state)
        {
            state--;
            Console.WriteLine(state);
        }
    }
}
