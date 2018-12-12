using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Task06_SyncCollection
{
    class Program
    {
        static List<int> collection = new List<int>();
        static object obj = new object();

        private const int COUNT = 10;
        static void Main(string[] args)
        {
            Task.Run(() => Addition());

            Console.ReadKey();
        }

        static void Addition()
        {
            for (int i = 1; i <= COUNT; i++)
            {
                lock (obj)
                {
                    collection.Add(i);
                }
                Task.Run(() => PrintCollection());
                Task.WaitAny();
            }
        }

        static void PrintCollection()
        {
            lock (obj)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }
    }
}
