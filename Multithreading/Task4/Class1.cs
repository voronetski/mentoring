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
        static void Main(string[] args)
        {

            var j = 0;
            Int32.TryParse(Console.ReadLine(), out j);
            var stopwatch = Stopwatch.StartNew();

            Thread[] array = new Thread[4];
            for (int i = 0; i < array.Length; i++)
            {
                // Start the thread with a ThreadStart.
                array[i] = new Thread(Decrement);
                array[i].Start();
            }

            for (int i = 0; i < array.Length; i++)
            {
            }

            Console.WriteLine("DONE: {0}", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static void Decrement(object state)
        {
            var value = (int) state;

            value--;
            state = value;

        }
    }
}
