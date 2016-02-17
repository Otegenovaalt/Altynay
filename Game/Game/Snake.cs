using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game.Models
{
    public class Snake : Drawer
    {
        public Snake()
        {
            color = ConsoleColor.Magenta ;
            sign = 'o';
            int x, y;
            x = (new Random().Next()) % 49;
            y = (new Random().Next()) % 24;

            body.Add(new Point(x, y));
        }
        public void Move(int dx, int dy)
        {
            for(int i = body.Count - 1; i >= 1; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            int k = body.Count;
            body[0].x += dx;
            body[0].y += dy; 

            if(body[0].x == Game.food.body[0].x && body[0].y == Game.food.body[0].y)
            {
                Game.food.NewRandom();
                body.Add(new Point(body[0].x, body[0].y));
            }
            for(int i = 0; i< Game.wall.body.Count - 1; i++)
            {
                if (body[0].x == Game.wall.body[i].x && body[0].y == Game.wall.body[i].y)
                    Game.GameOver = true;
            }
            for(int i = 0; i<= 50; i++)
            {
                if (body[0].x == i && body[0].y == 0 || body[0].x == i && body[0].y == 25)
                    Game.GameOver = true; 
            }
            for (int i = 0; i <= 25; i++)
            {
                if (body[0].x == 0 && body[0].y == i || body[0].x == 50 && body[0].y == i)
                    Game.GameOver = true;
            }

        }

    }
}
