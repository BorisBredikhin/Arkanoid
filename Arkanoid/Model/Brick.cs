using System.Drawing;

namespace Arkanoid.Model
{
    public abstract class Brick:IGameObject, ICollidable
    {
        public Size Size { get; } = new Size(2,1);
        public Point Position { get; set; }
        public Scene Scene { get; }

        public Brick(Scene scene, Point position)
        {
            Position = position;
            Scene = scene;
            Scene[position] = this;
        }

        public abstract void Dispose();

        public abstract void Collide(IGameObject movingObject);
    }
}
