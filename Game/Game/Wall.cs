﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game.Models
{
    public class Wall : Drawer
    {
        public Wall(int level)
        {
            color = ConsoleColor.Red;
            sign = '#';
            Init(level);
        }
        public Wall()
        {

        }
        public void Init(int level)
        {
            body.Clear();
            FileStream fs = new FileStream(string.Format(@"level{0}.txt", level), FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string[] arr = sr.ReadToEnd().Split('\n');
            int col = -1;
            foreach(string s in arr)
            {
                col++;
                int row = -1;
                foreach(char ch in s)
                {
                    row++;
                    if (ch == '#')
                        body.Add(new Point(row, col));
                }
            }
        }

    }
}
