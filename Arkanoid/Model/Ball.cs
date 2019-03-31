using System.Drawing;
using System.Numerics;

namespace Arkanoid.Model
{
    public class Ball: IMovingObject, ICollidable
    {
        public Ball(Scene scene)
        {
            Scene = scene;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Size Size { get; } = new Size(1,1);
        public Vector Position { get; set; }
        public Scene Scene { get; }
        public Vector Velocity { get; set; }
        public void Move(Direction direction)
        {

        }

        //TODO: Test it
        public void Collide(IGameObject anotherGameObject)
        {
            if (anotherGameObject is Brick)
            {
                Velocity = Direction.GetDirectionAfterCollision(new Direction(Velocity),
                    new Direction(anotherGameObject.Position - Velocity));
            }
        }
    }
}