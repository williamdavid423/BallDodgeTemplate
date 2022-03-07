using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Player
    {
        public int width = 30;
        public int height = 10;
        public int speed = 6;
        public int x, y;

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
