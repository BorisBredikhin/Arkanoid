using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private Paddle _paddle;
        
        private Brush _baseBrickBrush,
            _balllBrush,
            _paddleBrush,
            _simpleBrickBrush;

        private InfoPanel _infoPanel;

        public MainForm()
        {
            InitializeComponent();
            _baseBrickBrush = new SolidBrush(Color.Green);
            _simpleBrickBrush = new SolidBrush(Color.Blue);

            var gameWidth = (Game.GameAreaSize.Width+1)*Unit;
            var gameHeight = (Game.GameAreaSize.Height+2)*Unit+50;

            _infoPanel = new InfoPanel(gameWidth, gameHeight, Game);

            Size = new Size(gameWidth+_infoPanel.Width, gameHeight);


            _ball = new Ball(Game.Scene);
            _ball.PositionF = new PointF(Unit*_ball.Position.X, Unit*_ball.Position.Y);
            _balllBrush = new SolidBrush(Color.Red);
            Game.Scene.Ball = _ball;

            _paddle = Game.Scene.Paddle;
            _paddleBrush = new SolidBrush(Color.Orange);

            Controls.Add(_infoPanel);

            Timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGame();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                case Keys.NumPad4:
                    _paddle.MoveLeft();
                    break;
                case Keys.Right:
                case Keys.D:
                case Keys.NumPad6:
                    _paddle.MoveRight();
                    break;
            }
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
                    if (cell is SimpleBrick)
                    {
                        rectangles.Add((RectType.SimpleBrick, new Rectangle(i * Unit, j * Unit, Unit, Unit)));
                    }
                }
            }

            graphics.FillRectangles(_baseBrickBrush,
                rectangles.Where(r => r.Item1 == RectType.BaseBrick).Select(r => r.Item2).ToArray());

            graphics.FillRectangles(_simpleBrickBrush,
                rectangles.Where(r => r.Item1 == RectType.SimpleBrick).Select(r => r.Item2).ToArray());

            graphics.FillRectangle(_paddleBrush, _paddle.PositionF.X, _paddle.PositionF.Y, Unit*_paddle.Size.Width, Unit*_paddle.Size.Height);

            graphics.FillEllipse(_balllBrush, _ball.PositionF.X, _ball.PositionF.Y, Unit, Unit);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _infoPanel.OnTick(sender, e);
            if (Game.IsOver)
            {
                Timer.Stop();
                return;
            }
            //_infoPanel.OnTick(sender, e);
            //if (Game.IsOver)
            //{
            //    Timer.Stop();
            //    return;
            //}
            _paddle.Collide();
            _ball.Move(null, Game.FPS);

            DrawGame();
        }
    }
}
