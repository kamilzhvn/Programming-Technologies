using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MSnake.Models
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public List<Point> body = new List<Point>();
        public char sign;

        public Drawer(ConsoleColor _color, char _sign, List<Point> _body)
        {
            body = _body;
            color = _color;
            sign = _sign;
        }

        public void Draw()
        {
            Type t = this.GetType();
            if (t.Name == "Snake")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(body[0].X, body[0].Y);
                Console.Write(sign);
                Console.ForegroundColor = color;
                for(int i = 1; i < body.Count; i++)
                {
                    Console.SetCursorPosition(body[i].X, body[i].Y);
                    Console.Write(sign);
                }
            }
            else
            {
                Console.ForegroundColor = color;
                foreach (Point p in body)
                {
                    Console.SetCursorPosition(p.X, p.Y);
                    Console.Write(sign);
                }
            }
        }

        public void Serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Type t = this.GetType();
            FileStream fs = new FileStream(String.Format(@"f{0}.cer",t.Name),FileMode.OpenOrCreate,FileAccess.Write);
            try
            {
                bf.Serialize(fs,this);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write(e.Message);
                Console.ReadKey();
            }
            finally
            {
                fs.Close();
            }
        }

        public void Deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Type t = this.GetType();
            FileStream fs = new FileStream(String.Format(@"f{0}.cer", t.Name), FileMode.Open, FileAccess.Read);

            if(t == typeof(Wall))
            {
                Game.wall = bf.Deserialize(fs) as Wall;
            } else if(t == typeof(Food))
            {
                Game.food = bf.Deserialize(fs) as Food;
            } else if(t == typeof(Snake))
            {
                Game.snake = bf.Deserialize(fs) as Snake;
            }
            fs.Close();
        }
    }
}
