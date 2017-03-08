using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSnake.Models
{
    [Serializable]
    public class Point
    {
        private int x;
        private int y;

        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }

        public int Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }

        public Point() { }

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
