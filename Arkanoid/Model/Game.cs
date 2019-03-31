using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid.Model
{
    public class Game
    {
        public Size GameAreaSize { get; set; }
        public Scene Scene { get; set; }

        public int FPS { get; private set; } = 30;

        public Game()
        {
            GameAreaSize = new Size(22, 30);
            Scene = new Scene(this);
        }
    }
}
