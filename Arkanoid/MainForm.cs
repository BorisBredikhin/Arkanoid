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

        public Ball Ball;
        public Paddle Paddle;
        
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

            _infoPanel = new InfoPanel(gameWidth, gameHeight, Game, this);

            Size = new Size(gameWidth+_infoPanel.Width, gameHeight);


            Ball = new Ball(Game.Scene);
            Ball.PositionF = new PointF(Unit*Ball.Position.X, Unit*Ball.Position.Y);
            _balllBrush = new SolidBrush(Color.Red);
            Game.Scene.Ball = Ball;

            Paddle = Game.Scene.Paddle;
            _paddleBrush = new SolidBrush(Color.Orange);

            Controls.Add(_infoPanel);

            //Timer.Start();
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
                    Paddle.MoveLeft();
                    break;
                case Keys.Right:
                case Keys.D:
                case Keys.NumPad6:
                    Paddle.MoveRight();
                    break;
            }
        }

        private void DrawGame()
        {
            var graphics = CreateGraphics();
            //graphics.Clear(Color.White);
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

            var r = rectangles.Where(r1 => r1.Item1 == RectType.BaseBrick).Select(r1 => r1.Item2).ToArray();
            if(r.Length>0)
                graphics.FillRectangles(_baseBrickBrush,
                r);
            r = rectangles.Where(r1 => r1.Item1 == RectType.SimpleBrick).Select(r1 => r1.Item2).ToArray();
            if(r.Length>0)
            graphics.FillRectangles(_simpleBrickBrush,
                r);

            graphics.FillRectangle(_paddleBrush, Paddle.PositionF.X, Paddle.PositionF.Y, Unit*Paddle.Size.Width, Unit*Paddle.Size.Height);

            graphics.FillEllipse(_balllBrush, Ball.PositionF.X, Ball.PositionF.Y, Unit, Unit);
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
            Paddle.Collide();
            Ball.Move(null, Game.FPS);

            //DrawGame();
            Invalidate();
        }
    }
}
