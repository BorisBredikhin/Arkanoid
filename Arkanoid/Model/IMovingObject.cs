namespace Arkanoid.Model
{
    public interface IMovingObject: IGameObject
    {
        Vector Velocity { get; set; }

        void Move(Direction direction, int fps);
    }
}
