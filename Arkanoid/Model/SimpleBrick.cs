using System;

namespace Arkanoid.Model
{
    public class SimpleBrick: BaseBrick
    {
        public SimpleBrick(Scene scene, Vector position) : base(scene, position)
        {

        }

        public override string ToString() => "S";

        public override void Collide(IGameObject anotherGameObject)
        {
            if (anotherGameObject is Ball)
            {
                Scene.Game.Score++;
                Scene[Position] = null;
                if (Scene[Position.X - 1, Position.Y] is SimpleBrick)
                    Scene[Position.X - 1, Position.Y] = null;
                if (Scene[Position.X + 1, Position.Y] is SimpleBrick)
                    Scene[Position.X + 1, Position.Y] = null;

                Console.WriteLine(Scene);
                return;
            }
            //base.Collide(anotherGameObject);
        }
    }
}
