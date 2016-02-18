using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Doplab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\";

            DirectoryInfo dir = new DirectoryInfo(path);

            List<FileSystemInfo> items = new List<FileSystemInfo>();
            items.AddRange(dir.GetDirectories());
            items.AddRange(dir.GetFiles());

            int index = 0;

            while (true)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    //if (items[i].GetType() == typeof(FileInfo))

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;


                    }

                    Console.WriteLine(items[i].Name);
                    Console.BackgroundColor = ConsoleColor.Black;

                }


                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < items.Count - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        if (items[index].GetType() == typeof(DirectoryInfo))
                        {
                            path = items[index].FullName;
                            dir = new DirectoryInfo(path);
                            items.Clear();
                            items.AddRange(dir.GetDirectories());
                            items.AddRange(dir.GetFiles());
                            index = 0;
                        }
                        if (items[index].GetType() == typeof(FileInfo))
                        {
                            FileStream stream = new FileStream(items[index].FullName, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(stream);

                            string line = reader.ReadToEnd();
                            Console.Clear();
                            Console.WriteLine(line);
                            reader.Close();
                            stream.Close();
                        }
                        break;
                    case ConsoleKey.Escape:
                        int cnt = 0;
                        int count = 0;
                        for (int i = path.Length - 2; i >= 0; i--)
                        {
                            if (Convert.ToInt32(path[i]) == 92)
                                break;
                            else
                            {

                                count++;
                            }
                        }

                        path = path.Remove(path.Length - count - 1);
                        dir = new DirectoryInfo(path);
                        items.Clear();
                        items.AddRange(dir.GetDirectories());
                        items.AddRange(dir.GetFiles());
                        index = 0;
                        break;

                }
                Console.Clear();

            }
        }
    }
}
