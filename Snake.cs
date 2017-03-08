using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSnake.Models
{
    [Serializable]
    public class Snake : Drawer
    {
        public Snake(ConsoleColor color, char sign, List<Point> body) : base(color,sign,body) {  }

        public void Move (int dx, int dy)
        {
            Delete();

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += dx;
            body[0].Y += dy;

            EndOfGame.CheckBorder(body);

            EndOfGame.EatItself(body);

            if (Game.snake.CanEat(Game.food))
            {
                Game.cnt++;
                Game.food.SetRandomPosition();
                Console.Beep();
            }

            EndOfGame.BangIntoWall(body[0], Game.wall.body);

            EndOfGame.RemoveWall();
        }
        
        public Boolean CanEat(Food f)
        {
            if (body[0].X == f.body[0].X && body[0].Y == f.body[0].Y)
            {
                body.Add(new Models.Point(body[1].X, body[1].Y));
                return true;
            }
            else return false;
        }

        public void Delete()
        {
            Console.SetCursorPosition(body[body.Count - 1].X, body[body.Count - 1].Y);
            Console.Write(' ');
        }
    }
}
