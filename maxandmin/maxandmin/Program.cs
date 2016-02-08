using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace maxandmin
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

            int min = int.Parse(token[0]);
            int max = int.Parse(token[0]);
            /*
            foreach (string s in token)
            {
                int a = int.Parse(s);
                if (a < min)
                    min = a;
                if (a > max)
                    max = a;
            }
            */ 
            for(int i = 0; i<token.Length; i++)
            {
                int a = int.Parse(token[i]);
                if (a < min) 
                min = a;
                if (a > max) 
                max = a;
            }
            
            Console.WriteLine(max + " " + min);
            sw.WriteLine(max + " " + min);

            sw.Close();
            sr.Close();
            fs.Close();
            fs2.Close();
            Console.ReadKey();

        }
    }
}
