using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Snake.Models
{
    public class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();

        public Drawer() { }

        public virtual void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }

        }

        public void Save()
        {
            string FileName = "";
            if (sign == 'o')
                FileName = "snake.xml";
            if (sign == '*')
                FileName = "food.xml";
            if (sign == '=')
                FileName = "wall.xml";

            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(GetType());
            //BinaryFormatter bf = new BinaryFormatter();
            xs.Serialize(fs, this);
            //bf.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            string FileName = "";
            if (sign == 'o')
                FileName = "snake.xml";
            if (sign == '*')
                FileName = "food.xml";
            if (sign == '=')
                FileName = "wall.xml";

            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(GetType());
            //BinaryFormatter bf = new BinaryFormatter();

            if (sign == '*')
                Game.food = xs.Deserialize(fs) as Food;
            if (sign == '=')
                Game.wall = xs.Deserialize(fs) as Wall;

            if (sign == 'o')
                Game.snake = xs.Deserialize(fs) as Snake;

            fs.Close();

        }


    }
}