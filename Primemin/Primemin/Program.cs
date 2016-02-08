using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Primemin
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fs2 = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs2);

            string[] token = sr.ReadLine().Split();

            List<int> primes = new List<int>();
            for (int i = 0; i < token.Length; i++)
            {
                int a = int.Parse(token[i]);
                int cnt = 0;
                for (int j = 2; j < a; j++)
                {
                    if (a % j == 0)
                        cnt++;
                }
                if (cnt < 1)
                    primes.Add(a);
            }
            int min = primes[0];
            for (int i = 0; i < primes.Count; i++)
            {
                if (primes[i] < min)
                    min = primes[i];
            }
            Console.WriteLine(min);
            sw.WriteLine(min);

            sr.Close();
            sw.Close();
            fs.Close();
            fs2.Close();
            Console.ReadKey();
        }
    }
}
