using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prostye
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int a;
            for (int i = 0; i<array.Length; i++)
            {
                a = int.Parse(array[i]);
                int cnt = 0;
                for (int j = 2; j < a; j++)
                {
                    if (a % j == 0)
                        cnt++;
                }
                if (cnt < 1)
                    Console.WriteLine(a);
            }
            Console.ReadKey();
            
        }
    }
}
