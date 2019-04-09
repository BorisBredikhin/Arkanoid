using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;
using Arkanoid.Properties;

namespace Arkanoid
{
    public class InfoPanel : Panel
    {
        private Game _game;
        private Label _scoreLabel,
            _gameOverLabel;

        public InfoPanel(int gameWidth, int gameHeight, Game game)
        {
            Location = new Point(gameWidth, 0);
            Size = new Size(300, gameHeight);

            _game = game;

            _scoreLabel = new Label {Font = new Font(FontFamily.GenericSerif, 18.0f)};
            UpdateScore();
            Controls.Add(_scoreLabel);
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