using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Arkanoid.Model;

namespace Arkanoid
{
    public partial class MainForm : Form
    {
        public Game Game { get; set; } = new Game();
        public const int Unit = 20;

        private Ball _ball;

        private Brush _baseBrickBrush,
            _balllBrush;

        public MainForm()
        {
            InitializeComponent();
            _baseBrickBrush = new SolidBrush(Color.Green);
            Size = new Size((Game.GameAreaSize.Width+1)*Unit, (Game.GameAreaSize.Height+2)*Unit+50);
            _ball = new Ball(Game.Scene);
            _ball.PositionF = new PointF(Unit*_ball.Position.X, Unit*_ball.Position.Y);
            _balllBrush = new SolidBrush(Color.Red);
            Game.Scene.Ball = _ball;
            Timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGame();
        }

        private void DrawGame()
        {
            var graphics = CreateGraphics();
            graphics.Clear(Color.White);
            var areaSize = Game.GameAreaSize;
            var rectangles = new List<(RectType, Rectangle)>();

            for (var i = 0; i < areaSize.Width; i++)
            {
                for (var j = 0; j < areaSize.Height; j++)
                {
                    var cell = Game.Scene[i, j];
                    if (cell is BaseBrick)
                    {
                        rectangles.Add((RectType.BaseBrick, new Rectangle(i * Unit, j * Unit, Unit, Unit)));
                    }
                }
            }

            graphics.FillRectangles(_baseBrickBrush,
                rectangles.Where(r => r.Item1 == RectType.BaseBrick).Select(r => r.Item2).ToArray());
            graphics.FillEllipse(_balllBrush, _ball.PositionF.X, _ball.PositionF.Y, Unit, Unit);
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            _ball.Move(null,Game.FPS);
            DrawGame();
            if (Game.IsOver)
            {
                _ball = null;
                Timer.Stop();
            }
        }
    }
}
