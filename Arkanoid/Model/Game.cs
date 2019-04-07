using System.Drawing;

namespace Arkanoid.Model
{
    public class Game
    {
        public Size GameAreaSize { get; set; }
        public Scene Scene { get; set; }
        public bool IsOver { get; set; } = false;

        public int FPS { get; private set; } = 30;

        public Game()
        {
            GameAreaSize = new Size(22, 30);
            Scene = new Scene(this);
        }
    }
}
