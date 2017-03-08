using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSnake.Models;

namespace MSnake
{
    public class EndOfGame
    {
        public static void CheckBorder(List<Point> body)
        {
            if (body[0].X > 69 || body[0].X < 1 || body[0].Y > 34 || body[0].Y < 1)
            {
                End();
            }
        }

        public static void BangIntoWall(Point head, List<Point> body)
        {
            foreach(Point p in body)
            {
                if(head.X == p.X && head.Y == p.Y)
                {
                    End();
                    break;
                }
            }
        }

        public static void EatItself(List<Point> body)
        {
            for (int i = 3; i < body.Count; i++)
            {
                if (body[i].X == body[0].X && body[i].Y == body[0].Y)
                {
                    End();
                    break;
                }
            }
        }

        public static void RemoveWall()
        {
            if (Game.snake.body.Count == Game.size)
            {
                Game.size += 1;
                Game.level++;
                Wall.Delete(Game.wall.body);
                Game.wall.LoadLevel(Game.level);
                if (Game.level == 3)
                {
                    Game.size = -1;
                }
            }
        }

        public static void End()
        {
            Console.Clear();
            Game.game = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(27, 16);
            Console.Write("Your score:  ");
            Console.SetCursorPosition(28, 17);
            Console.Write("GAME OVER ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(40, 16);
            Console.Write(Game.cnt);
            Console.SetCursorPosition(39,17);
            Console.Write(":(");
            Console.ReadKey();
        }
    }
}
