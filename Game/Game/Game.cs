using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game.Models
{
    public class Game
    {
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
            Console.SetWindowSize(50, 25);
            while (!GameOver)
            {
                Draw();
                if (Game.snake.body.Count() == 5 + level)
                {
                    level += 1;
                    wall = new Wall(level);
                    int a = Game.snake.body[0].x;
                    int b = Game.snake.body[0].y;
                    Game.snake.body.Clear();
                    Game.food.body.Clear();
                    Init();

                    Game.snake.body.Add(new Point(a, b));
                }
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Food: {0}, level: {1}", Game.snake.body.Count(), level);

                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    if (Game.snake.body.Count > 1 && Game.snake.body[0].x - 1 != Game.snake.body[1].x)
                        snake.Move(-1, 0);

                    if (Game.snake.body.Count == 1)
                        snake.Move(-1, 0);
                }
                if (button.Key == ConsoleKey.RightArrow)
                {
                    if ((Game.snake.body.Count > 1 && Game.snake.body[0].x + 1 != Game.snake.body[1].x))
                        snake.Move(1, 0);
                    if (Game.snake.body.Count == 1)
                        snake.Move(1, 0);
                }

                if (button.Key == ConsoleKey.UpArrow)
                {
                    if (Game.snake.body.Count > 1 && Game.snake.body[0].y - 1 != Game.snake.body[1].y)
                        snake.Move(0, -1);

                    if (Game.snake.body.Count == 1)
                        snake.Move(0, -1);
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    if (Game.snake.body.Count > 1 && Game.snake.body[0].y + 1 != Game.snake.body[1].y)
                        snake.Move(0, 1);
                    if (Game.snake.body.Count == 1)
                        snake.Move(0, 1);
                }
                if (button.Key == ConsoleKey.F2)
                    Save();
                if (button.Key == ConsoleKey.F3)
                    Resume();
            }

            Console.SetCursorPosition(18, 12);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }
        public void Init()
        {
            food.NewRandom();
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
            Console.Clear();
            food.Draw();
            snake.Draw();
            wall.Draw();
        }

    }
}