using System;
using System.Drawing;

namespace Arkanoid.Model
{
    public abstract class Brick : IGameObject, ICollidable
    {
        protected Size MySize;

        private PointF _position;

        public Size Size => MySize;

        public Vector Position
        {
            get => new Vector((int)_position.X, (int)_position.Y);
            set
            {
                if ((0<=value.X && value.X<Scene.SceneSize.Width) && (0 <= value.Y && value.Y < Scene.SceneSize.Height))
                {
                    _position = new PointF(value.X, value.Y);
                }
                else
                {
                    throw new ArgumentException("Value must be in scene rectangle");
                }
            }
        }

        public Scene Scene { get; }
        public PointF PositionF { get; set; }

        protected Brick(Scene scene, Vector position)
        {
            MySize = new Size(1,1);
            Scene = scene;
            Position = position;
            Scene[position] = this;
        }

        public abstract void Dispose();

        public abstract void Collide(IGameObject anotherGameObject);
    }
}
