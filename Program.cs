using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakegame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Random random = new Random();
            int[, ,] pointpos = new int[3, 3, 3];//массив для чек поинтов
            for (int i = 0; i < pointpos.GetLength(0); i++)
            {
                pointpos[i, 0, 0] = random.Next(5, 10);//заполняем массив
                pointpos[0, i, 0] = random.Next(5, 10);//заполняем массив
                pointpos[0, 0, i] = 0;
                Console.SetCursorPosition(pointpos[0, i, 0], pointpos[i, 0, 0]);
                Console.Write("@");//выводим на экран чек поинты
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("*");//выводим нашу змейку
            while (K != ConsoleKey.Escape)// пока не нажата клавиша ESC
            {
                
                for (int i = 0; i < pointpos.GetLength(0); i++)
                {
                    if (x == pointpos[0, i, 0] && y == pointpos[i, 0, 0]) // если положение x и y совпадает с положением чек поинта
                    {
                        if (pointpos[0, 0, i] == 0)// если чек поинт не "съеден"(значение его 0)
                        {
                            playersize += 1; // добавляем единицу к размеру змейки
                            pointpos[0, 0, i] = 1;// помечаем чек поинт как "съеденый"(присваиваем ему значение 1)
                        }
                    }
                }
                
            }

        }

        
    }
}
