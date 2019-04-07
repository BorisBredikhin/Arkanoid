using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Arkanoid.Model
{
    public class Ball: IMovingObject, ICollidable
    {
        private PointF _positionF;

        public Ball(Scene scene)
        {
            Scene = scene;
            Position = new Vector(Scene.SceneSize.Width/2, Scene.SceneSize.Height/2);
            Velocity = new Vector(1,-1);
        }

        public void Dispose()
        {
            Scene.GameOver();
        }

        public Size Size { get; } = new Size(1,1);
        public Vector Position { get=>new Vector((int) (_positionF.X/20), (int) (_positionF.Y/20));
            set
            {
                _positionF.X = value.X*20;
                _positionF.Y = value.Y*20;
            }
        }
        public Scene Scene { get; }
        public PointF PositionF { get => _positionF; set => _positionF = value; }
        public Vector Velocity { get; set; }

        
        public void Move(Direction direction, int fps)
        {
            var (x, y) = (Velocity.X, Velocity.Y);
            if (x < 0)
                x++;
          if (y<0)
                {
                    y++;
                }

          if (Position.Y==Scene.SceneSize.Height-1)
          {
              Scene.GameOver();
              return;
          }

            var gameObject = Scene[Position + new Vector(x,y)];
            if (gameObject == null)
            {

                var prep = Position;
                PositionF = new PointF(PositionF.X + (float) (Velocity.X * (100.0 / fps)),
                    PositionF.Y + (float) (Velocity.Y * (100.0 / fps)));
                return;
            }

            Collide(gameObject);
             
        }

        public void Collide(IGameObject anotherGameObject)
        {
           if (anotherGameObject == null)
                return;
            var collisionDirection = new Direction(2*anotherGameObject.Position - Velocity);
            if (anotherGameObject is Brick)
            {
                var delta = new Vector(-1/Velocity.X, 1/Velocity.Y);
                var t = Position + delta;
                if (t.X > 0 && t.Y > 0 && t.X < Scene.SceneSize.Width && t.Y < Scene.SceneSize.Height)
                {

                    if (Scene[Position + delta] == null)
                        Velocity = delta;
                    return;
                }
               t = Position - delta;
                if (t.X > 0 && t.Y > 0 && t.X < Scene.SceneSize.Width && t.Y < Scene.SceneSize.Height)
                {

                    if (Scene[Position - delta] == null)
                        Velocity = -1 * delta;
                    
                }
            }
        }
    }
}