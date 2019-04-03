namespace Arkanoid.Model
{
    public class BaseBrick: Brick
    {
        public BaseBrick(Scene scene, Vector position) : base(scene, position)
        {
        }

        public override void Dispose()
        {
            
        }

        public override void Collide(IGameObject anotherGameObject)
        {
            if (anotherGameObject is ICollidable collidable)
                collidable.Collide(this);
        }
    }
}
