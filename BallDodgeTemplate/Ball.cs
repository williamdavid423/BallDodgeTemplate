using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BallDodgeTemplate
{
    internal class Ball
    {
        // colour, rectangle 
        public int size = 10;
        public int xSpeed, ySpeed;
        public int x, y;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(Size screenSize)
        {
            x += xSpeed;
            y += ySpeed;

            //check if ball has reached right or left edge
            if (x > screenSize.Width - size || x < 0)
            {
                xSpeed *= -1; ;
            }

            //check if ball has reached right or left edge
            if (y > screenSize.Height - size || y < 0)
            {
                ySpeed *= -1; ;
            }
        }

    }
}
