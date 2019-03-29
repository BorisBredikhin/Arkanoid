using System.Drawing;
using System.Numerics;

namespace Arkanoid.Model
{
    public class Ball: IMovingObject
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Size Size { get; }
        public Point Position { get; set; }
        public Scene Scene { get; }
        public Vector2 Velocity { get; set; }
        public void Move(Direction direction)
        {
            throw new System.NotImplementedException();
        }
    }
}