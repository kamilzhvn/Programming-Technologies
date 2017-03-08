using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSnake.Models
{
    [Serializable]
    public class Wall : Drawer
    {
        public Wall(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body)
        {
            LoadLevel(Game.level);
        }

        public void LoadLevel(int level)
        {
            String filename = String.Format(@"Levels\level{0}.txt", level);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            String line = "";
            int row = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                row++;
            }
        }
        
        public static void Delete(List<Point> body)
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
            body.Clear();
        }
    }
}
