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
//        private new int X, Y;
#pragma warning restore 169
        public static readonly Direction
            NW = new Direction(-1, -1),
            N = new Direction(0, -1),
            NE = new Direction(1, -1),
            W = new Direction(-1, 0),
            Stay = new Direction(0,0),
            E = new Direction(1, 0),
            SW = new Direction(-1, 1),
            S = new Direction(0, 1),
            SE = new Direction(1, 1);

        public Direction(int x, int y) : base(x==0?0:x/Math.Abs(x), y==0?0:y / Math.Abs(y))
        {
        }

        public static Direction GetDirectionAfterCollision(Direction objectDirection, Direction collisionDirection)
        {
            if (collisionDirection.X != 0)
                return new Direction(-objectDirection.X, objectDirection.Y);
            if (collisionDirection.Y != 0)
                return new Direction(objectDirection.X, -objectDirection.Y);
            throw new NotImplementedException();
        }

        public override string ToString() => $"({X}; {Y})";

        public override bool Equals(object obj)
        {
            var anotherDirection = obj as Direction;
            return X == anotherDirection.X && Y == anotherDirection.Y;
        }

        public override int GetHashCode() => 2 * X + 2 * Y;
    }
}