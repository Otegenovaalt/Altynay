using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Snake.Models
{
    public class Game
    {

        public enum Direction { right, up, left, down };
        public static Direction dir;

        public static int speed = 200;
        public static int level = 1;
        public static bool GameOver = false;

        public static Food food = new Food();
        public static Snake snake = new Snake();
        public static Wall wall = new Wall(level);


        public Game()
        {
            Init();
            Play();
        }

        public void Play()
        {            
            Thread t = new Thread(MoveSnake);
            t.Start();


            while (!GameOver)
            {              
                if (Game.snake.body.Count() == 3 + level)
                {
                    level += 1;
                    speed -= 40;
                    wall = new Wall(level);
                    int a = Game.snake.body[0].x;
                    int b = Game.snake.body[0].y;
                    Game.snake.body.Clear();
                    Game.food.body.Clear();
                    Console.Clear();
                    Game.wall.Draw();
                    Init();
                    Game.snake.body.Add(new Point(a, b));
                }

                ConsoleKeyInfo button = Console.ReadKey();

                if (button.Key == ConsoleKey.LeftArrow)
                {
                    if ((Game.snake.body.Count > 1 && Game.snake.body[0].x - 1 != Game.snake.body[1].x)
                            || Game.snake.body.Count == 1)
                        dir = Direction.left;
                }
                if (button.Key == ConsoleKey.RightArrow)
                {
                    if ((Game.snake.body.Count > 1 && Game.snake.body[0].x + 1 != Game.snake.body[1].x)
                            || Game.snake.body.Count == 1)
                        dir = Direction.right;
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    if ((Game.snake.body.Count > 1 && Game.snake.body[0].y - 1 != Game.snake.body[1].y)
                            || Game.snake.body.Count == 1)
                        dir = Direction.up;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    if ((Game.snake.body.Count > 1 && Game.snake.body[0].y + 1 != Game.snake.body[1].y)
                            || Game.snake.body.Count == 1)
                        dir = Direction.down;
                }
                if (button.Key == ConsoleKey.Escape)
                    break;
                if (button.Key == ConsoleKey.F2)
                    Save();
                if (button.Key == ConsoleKey.F3)
                    Resume();
            }

            if (GameOver == true)
            {
                Console.SetCursorPosition(30, 15);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("GAME OVER");
                ConsoleKeyInfo newgame = Console.ReadKey();
                if (newgame.Key == ConsoleKey.F10)
                {
                    GameOver = false;
                    Console.Clear();
                    
                    Draw();
                    Game.wall.Draw();
                    Play();
                }

            }
            else
            {
            }
        }

        public void MoveSnake(object state)
        {
            while (!GameOver)
            {
                if (dir == Direction.left)
                    snake.move(-1, 0);
                if (dir == Direction.right)
                    snake.move(1, 0);
                if (dir == Direction.up)
                    snake.move(0, -1);
                if (dir == Direction.down)
                    snake.move(0, 1);
                Draw();
                Thread.Sleep(speed);
            }

        }

        public void Init()
        {
            food.NewRandomPosition();
        }
        public void Save()
        {
            snake.Save();
            wall.Save();
            food.Save();
        }
        public void Resume()
        {
            snake.Resume();
            wall.Resume();
            food.Resume();
        }
        public void Draw()
        {
            food.Draw();
            snake.Draw();
            Console.SetCursorPosition(22, 31);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Food: {0}, level: {1}", Game.snake.body.Count(), level);
            if (level == 1)
                wall.Draw();

        }

    }
}