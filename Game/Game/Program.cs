using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Snake.Models.Game snake = new Snake.Models.Game();
            Console.ReadKey();

        }
    }
}
