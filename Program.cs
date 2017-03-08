using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MSnake.Models;

namespace MSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.lala();

            Thread myThread = new Thread(AutoMoveSnake);
            myThread.Start();
            
          
            while (Game.game) //true
            {
                do
                {
                    Game.btn = Console.ReadKey();
                } while (Convert.ToString(Game.btn.Key) == Game.last);
                
                switch (Game.btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.i = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Game.i = 3;
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.i = 4;
                        break;
                    case ConsoleKey.RightArrow:
                        Game.i = 2;
                        break;
                    case ConsoleKey.Escape:
                        Game.game = false;
                        break;
                    case ConsoleKey.F1:
                        Game.Serialize();
                        break;
                    case ConsoleKey.F2:
                        Game.Deserialize();
                        break;
                }
            }
        }

        public static void AutoMoveSnake()
        {
            while (Game.game)
            {
                Game.Draw();
                Thread.Sleep(400);
                switch (Game.i)
                {
                    case 1:
                        Game.snake.Move(0, -1);
                        Game.last = Convert.ToString(ConsoleKey.DownArrow);
                        break;
                    case 2:
                        Game.snake.Move(1, 0);
                        Game.last = Convert.ToString(ConsoleKey.LeftArrow);
                        break;
                    case 3:
                        Game.snake.Move(0, 1);
                        Game.last = Convert.ToString(ConsoleKey.UpArrow);
                        break;
                    case 4:
                        Game.snake.Move(-1, 0);
                        Game.last = Convert.ToString(ConsoleKey.RightArrow);
                        break;
                }
            }
        }
    }
}