using System;

namespace Arkanoid.Model
{
    public class Vector
    {
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public double Angle => Math.Atan2(Y, X);
    }
}