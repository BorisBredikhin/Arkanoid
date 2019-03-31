using System;
using System.Drawing;

namespace Arkanoid.Model
{
    public interface IGameObject: IDisposable
    {
        Size Size { get; }
        Vector Position { get; set; }
        Scene Scene { get; }
    }
}
