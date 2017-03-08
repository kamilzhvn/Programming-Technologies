using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSnake.Models
{
    [Serializable]
    public class Food : Drawer
    {
        public Food(ConsoleColor color, char sign, List<Point> body) : base (color, sign, body)
        {
            Create();
        }

        public void Create()
        {
            Delete();

            int y;
            int x;
            Boolean ok;

            do
            {
                ok = true;
                x = new Random().Next(1, 69);
                y = new Random().Next(1, 34);

                body[0] = new Point(x, y);

                if (ItISNot(body[0], Game.wall.body) || ItISNot(body[0], Game.snake.body))
                {
                    ok = false;
                }

            } while (!ok);           
        }

        public void SetRandomPosition()
        {
            Delete();

            Boolean ok = false;

            while (!ok)
            {
                ok = true;

                int x = new Random().Next(1, 69);
                int y = new Random().Next(1, 34);

                if (ItISNot(body[0], Game.wall.body) || ItISNot(body[0], Game.snake.body))
                {
                    ok = false;
                }
                body[0] = new Point(x, y);
            }
        }

        public void Delete()
        {
            Console.SetCursorPosition(body[0].X, body[0].Y);
            Console.Write(' ');
        }

        public Boolean ItISNot(Point food, List<Point> body)
        {
            foreach(Point p in body)
            {
                if(food.X == p.X && food.Y == p.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
