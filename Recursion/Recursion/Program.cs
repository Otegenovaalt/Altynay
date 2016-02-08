using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree(@"C:\Users\admin\Desktop\Доки 2");

        }
        static void Tree(string path)
        {
            Stack<string> st = new Stack<string>();
            Console.WriteLine(path + ":" + Directory.GetFiles(path).Length);
            st.Push(path);

            while (st.Count > 0)
            {
                string[] dir = Directory.GetDirectories(st.Pop());
                foreach (string s in dir)
                {
                    Console.WriteLine(s + ":" + Directory.GetFiles(s).Length);
                    st.Push(s);
                    Console.ReadKey();
                }


            }
        }

    }
}
