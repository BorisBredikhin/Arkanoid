using System.Drawing;

namespace Arkanoid.Model
{
    public class Ball: IMovingObject, ICollidable
    {
        private PointF _positionF;
        private long time = 0;

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
            Collide(gameObject);

            //if (gameObject == null)
            {
                time++;
                var prep = Position;
                PositionF = new PointF(PositionF.X + (float) (Velocity.X * (Scene.Speed*100.0 / fps)),
                    PositionF.Y + (float) (Velocity.Y * (Scene.Speed*100.0 / fps)));
               // return;
            }

        }

        public void Collide(IGameObject anotherGameObject)
        {
           if (anotherGameObject == null)
                return;
           // var collisionDirection = new Direction(2*anotherGameObject.Position - Velocity);
            if (anotherGameObject is Brick)
            {
                Velocity.Y *= -1;
                if (Scene.InBounds(Position + Velocity) &&Scene[Position + Velocity] == null)
                    goto collision;
                Velocity.X *= -1;
                Velocity.Y *= -1;
                if (Scene.InBounds(Position + Velocity) && Scene[Position + Velocity] == null)
                    goto collision;
                Velocity.Y *= -1;
                if (Scene.InBounds(Position + Velocity) && Scene[Position + Velocity] == null)
                    goto collision;
            }
            collision:
            if (anotherGameObject is ICollidable collidable)
                {
                    collidable.Collide(this);
                }

            //Position += Velocity;
        }

        }
    }
