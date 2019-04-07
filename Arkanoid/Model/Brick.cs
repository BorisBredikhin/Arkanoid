using System;
using System.Drawing;

namespace Arkanoid.Model
{
    public abstract class Brick : IGameObject, ICollidable
    {
        protected Size MySize;


        public Size Size => MySize;

        private PointF _positionF;
        public Vector Position
        {
            get => new Vector((int)(_positionF.X / 20), (int)(_positionF.Y / 20));
            set
            {
                _positionF.X = value.X * 20;
                _positionF.Y = value.Y * 20;
            }
        }
        public Scene Scene { get; }
        public PointF PositionF { get => _positionF; set => _positionF = value; }


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
