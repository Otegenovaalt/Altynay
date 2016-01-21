using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Complex
    {
        public double a, b;

        public Complex (double c, double d)
        {
            a = c;
            b = d;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3 = new Complex(c1.a + c2.a, c1.b + c2.b);
            return c3;
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
            double d1 = Int32.Parse(Console.ReadLine());
            double d2 = Int32.Parse(Console.ReadLine());
            double v1 = Int32.Parse(Console.ReadLine());
            double v2 = Int32.Parse(Console.ReadLine());

            Complex d = new Complex(d1, d2);
            Complex v = new Complex(v1, v2);

            Complex w = d + v;

            Console.WriteLine(w);
            Console.ReadKey();
        }
    }
}
