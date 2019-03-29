using System;
using System.Drawing;

namespace Arkanoid.Model
{
    public interface IGameObject: IDisposable
    {
        Size Size { get; }
        Point Position { get; set; }
        Scene Scene { get; }
    }
}
