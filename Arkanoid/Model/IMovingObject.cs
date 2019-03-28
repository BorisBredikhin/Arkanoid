
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Model
{
    public interface IMovingObject
    {
        Size Size { get; set; }
        Point Position { get; set; }
        Vector2 Velocity { get; set; }
        Scene Scene { get; }

        void Move();
    }
}
