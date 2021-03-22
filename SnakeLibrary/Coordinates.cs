using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeLibrary
{
    public class Coordinates
    {
        public Coordinates(int _x, int _y)
        {
            x = _x;
            y = _y;

        }

        public Coordinates()
        {

        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
