using System;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        private static bool flag = false;
        private static int limit = 0;


        static void Main(string[] args)
        {
            var a = MainMethodAsync();
            Task.WaitAll(a);
            Console.ReadKey();
        }

        private static async Task MainMethodAsync()
        {
            await GetLimitAsync();
            var result = await GetSumAsync();
            GetLimit();
            Console.WriteLine(result);
        }

        private static void GetLimit()
        {
            var limitString = Console.ReadLine();
        }

        private async static Task GetLimitAsync()
        {
            var limitString = Console.ReadLine();
            if (int.TryParse(limitString, out limit))
            {
                if (!flag) flag = true;
            }
        }

        private static async Task<int> GetSumAsync()
        {
            flag = false;
            var sum = 0;
            do
            {
                sum = 0;
                for (int i = 0; i < limit; i++)
                {
                    sum += i;
                    if (flag) break;
                }

            } while (flag);

            if (!flag) flag = true;

            return sum;
        }
    }






}
