using System;
using System.Numerics;
// ReSharper disable InconsistentNaming

namespace Arkanoid.Model
{
    /// <summary>
    ///     Имя направления соответствует стороне света
    /// </summary>
    public class Direction: Vector
    {
#pragma warning disable 169
        private new int X, Y;
#pragma warning restore 169
        public static Vector2
            NW = new Vector2(-1, -1),
            N = new Vector2(0, -1),
            NE = new Vector2(-1, 1),
            W = new Vector2(-1, 0),
            Stay = Vector2.Zero,
            E = new Vector2(1, 0),
            SW = new Vector2(-1, 1),
            S = new Vector2(0, 1),
            SE = new Vector2(1, 1);

        public Direction(int x, int y) : base(x/Math.Abs(x), y / Math.Abs(y))
        {
        }
    }

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