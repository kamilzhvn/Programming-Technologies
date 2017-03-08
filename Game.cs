using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSnake.Models
{
    [Serializable]
    public class Game
    {
        public static int i;
        public static int cnt;
        public static int size;
        public static ConsoleKeyInfo btn;
        public static String last;
        public static Boolean game;
        public static int level;

        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void lala()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 35);

            i = 1;
            cnt = 0;
            size = 5;
            level = 1;
            game = true;
            last = Convert.ToString(ConsoleKey.DownArrow);

            List<Point> snake_body = new List<Point>();
            snake_body.Add(new Point(35, 14));
            snake_body.Add(new Point(35, 15));
            snake_body.Add(new Point(35, 16));
            snake_body.Add(new Point(35, 17));
            snake = new Snake(ConsoleColor.Yellow, 'o', snake_body);

            List<Point> wall_body = new List<Point>();
            wall = new Wall(ConsoleColor.White, '■', wall_body);

            List<Point> food_body = new List<Point>();
            food_body.Add(new Point(0, 0));
            food = new Food(ConsoleColor.Green, '$', food_body);
        }

        public static void Serialize()
        {
            Game.snake.Serialize();
            Game.wall.Serialize();
            Game.food.Serialize();
            Console.Clear();
        }

        public static void Deserialize()
        {
            Game.snake.Deserialize();
            Game.wall.Deserialize();
            Game.food.Deserialize();
            Console.Clear();
        }

        public static void Draw()
        {
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}
