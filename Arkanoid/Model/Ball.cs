using System.Drawing;
using System.Numerics;

namespace Arkanoid.Model
{
    public class Ball: IMovingObject, ICollidable
    {
        public Ball(Scene scene)
        {
            Scene = scene;
            Position = new Vector(Scene.SceneSize.Width/2, Scene.SceneSize.Height/2);
            Velocity = new Vector(1,1);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Size Size { get; } = new Size(1,1);
        public Vector Position { get; set; }
        public Scene Scene { get; }
        public Vector Velocity { get; set; }
        public void Move(Direction direction = null)
        {
            Position += Velocity;
        }

        public void Collide(IGameObject anotherGameObject)
        {
            var collisionDirection = new Direction(2*anotherGameObject.Position - Velocity);
            if (anotherGameObject is Brick)
            {
                var delta = new Vector(-Velocity.Y/collisionDirection.X, -Velocity.X/collisionDirection.Y);
                if (Scene[Position + delta] == null)
                    Velocity = delta;
                else
                    Velocity = -1 * delta;
            }
        }
    }
}