using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkanoid.Model;

namespace Arkanoid
{
    class Paddle: BaseBrick
    {
        public Paddle(Scene scene) : base(scene, new Vector(scene.SceneSize.Width / 2 - 1, scene.SceneSize.Height - 3))
        {
            MySize = new Size(3,1);
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
    }
}
