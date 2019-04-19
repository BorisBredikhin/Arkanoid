using System.Drawing;

namespace Arkanoid.Model
{
    public class Paddle: BaseBrick
    {
        public int Width { get => MySize.Width; set => MySize.Width = value; }
        public Paddle(Scene scene) : base(scene, new Vector(scene.SceneSize.Width / 2 - 1, scene.SceneSize.Height - 3))
        {
            //MySize = new Size(20,1);
            Scene[Position] = null;
        }

        public void MoveLeft()
        {
            if (Position.X>1)
                Position -= new Vector(1, 0);
        }

        public void MoveRight()
        {
            if (Position.X+MySize.Width<Scene.SceneSize.Width-1)
                Position += new Vector(1, 0);
        }

        public void Collide()
        {
            var ball = Scene.Ball;
            if (ball.Position.Y == Position.Y-1)
                if (Position.X <= ball.Position.X && ball.Position.X <= Position.X + Size.Width)
                    ball.Velocity.Y *= -1;
        }

        public override void Collide(IGameObject anotherGameObject)
        {
            if (anotherGameObject is Ball ball)
                ball.Velocity.Y *= -1;
            if (anotherGameObject is ICollidable collidable)
                collidable.Collide(this);
        }
    }
}
