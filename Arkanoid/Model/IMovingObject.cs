using System.Numerics;

namespace Arkanoid.Model
{
    public interface IMovingObject: IGameObject
    {
        Vector2 Velocity { get; set; }

        void Move(Direction direction);
    }
}
