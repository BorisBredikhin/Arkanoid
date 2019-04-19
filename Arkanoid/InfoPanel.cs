using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;
using Arkanoid.Properties;

namespace Arkanoid
{
    public class InfoPanel : Panel
    {
        private readonly Game _game;
        private readonly MainForm _mainForm;

        private readonly Label _scoreLabel;

        private Label _gameOverLabel;

        private readonly Label _controlButton;

        public InfoPanel(int gameWidth, int gameHeight, Game game,
            MainForm mainForm)
        {
            Location = new Point(gameWidth, 0);
            Size = new Size(300, gameHeight);

            _game = game;
            _mainForm = mainForm;
            _controlButton = new Label()
            {
                Width = Size.Width,
                Text = Resources.NewGame,
                Top = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(5),
                BorderStyle = BorderStyle.Fixed3D,
            };

            _controlButton.Click+= ChangeGameState;

            _scoreLabel = new Label {Font = new Font(FontFamily.GenericSerif, 18.0f)};
            UpdateScore();
            Controls.Add(_scoreLabel);
            Controls.Add(_controlButton);
        }

        private void ChangeGameState(object sender, EventArgs e)
        {
            if (_controlButton.Text == Resources.NewGame)
            {
                _game.Scene = new Scene(_game,1);
                _mainForm.Ball = new Ball(_game.Scene);
                _game.Scene.Ball = _mainForm.Ball;
                _mainForm.Paddle = _game.Scene.Paddle;
                _game.Scene.Paddle = _mainForm.Paddle;
                _mainForm.Timer.Start();
                _controlButton.Text = Resources.Pause;
            }
        }

        public void OnTick(object sender, EventArgs e)
        {
            UpdateScore(); 
            if (_game.IsOver)
            {
                _gameOverLabel = new Label
                {
                    Text = Resources.GameOver,
                    ForeColor = Color.Red,
                    Font = new Font(FontFamily.GenericSerif, 18.0f, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Location = new Point(0,30)
                };
                Controls.Add(_gameOverLabel);
            }
        }

        private void UpdateScore()
        {
            _scoreLabel.Text = string.Format(Resources.ScoreLabelText, _game.Score);
        }
    }
}