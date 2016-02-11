using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Complex
    {
        public int a, b;

        public Complex(int c, int d)
        {
            a = c;
            b = d;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            if (c1.b > c2.b)
            {
                int cnt = 0;
                int i = c1.b;
                while (true)
                {
                    if (i % c1.b == 0 && i % c2.b == 0)
                    {
                        cnt = i;
                        break;
                    }
                    i++;
                }
                int m = (cnt / c1.b * c1.a + cnt / c2.b * c2.a);
                 
                
                for (int x = cnt; x > 2; x--)
                {
                    if (m % x == 0 && cnt % x == 0)
                    {
                        cnt = cnt / x;
                        m = m / x;
                    }

                }
                Complex c3 = new Complex(m, cnt);
                return c3;
            }
            else
            {
                int cnt = 0;
                int i = c2.b;
                while (true)
                {
                    if (i % c1.b == 0 && i % c2.b == 0)
                    {
                        cnt = i;
                        break;
                    }
                    i++;
                }
                Complex c3 = new Complex((cnt / c1.b * c1.a + cnt / c2.b * c2.a), cnt);
                return c3;


            }
        }

        public override string ToString()
        {
            return a + "/" + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int d1 = Int32.Parse(Console.ReadLine());
            int d2 = Int32.Parse(Console.ReadLine());
            int v1 = Int32.Parse(Console.ReadLine());
            int v2 = Int32.Parse(Console.ReadLine());

            Complex d = new Complex(d1, d2);
            Complex v = new Complex(v1, v2);

            Complex w = d + v;

            Console.WriteLine(w);
            Console.ReadKey();
        }
    }
}
