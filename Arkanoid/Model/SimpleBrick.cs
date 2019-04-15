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
                return;
            }
            //base.Collide(anotherGameObject);
        }
    }
}
