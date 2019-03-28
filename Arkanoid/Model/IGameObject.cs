using System.Drawing;

namespace Arkanoid.Model
{
    public interface IGameObject
    {
        Size Size { get; set; }
        Point Position { get; set; }
        Scene Scene { get; }
    }
}
