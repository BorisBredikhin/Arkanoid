namespace Arkanoid.Model
{
    interface ICollidable
    {
        void Collide(IMovingObject movingObject);
    }
}
