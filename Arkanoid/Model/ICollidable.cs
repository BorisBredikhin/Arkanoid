namespace Arkanoid.Model
{
    interface ICollidable
    {
        void Collide(IGameObject movingObject);
    }
}
