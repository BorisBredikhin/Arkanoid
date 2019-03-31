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

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }
}