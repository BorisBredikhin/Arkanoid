using System.Drawing;
using System.IO;
using System.Text;

namespace Arkanoid.Model
{
    public class Scene
    {
        public Size SceneSize { get; set; }
        public Ball Ball;
        public Paddle Paddle { get; set; }
        public int Level { get; set; }
        public double Speed { get; set; }

        public readonly Game Game;
        private readonly IGameObject[,] _scene;

        public IGameObject this[int x, int y]
        {
            get => _scene[x, y];
            set => _scene[x, y] = value;
        }

        public IGameObject this[Vector point]
        {
            get => _scene[point.X, point.Y];
            set => _scene[point.X, point.Y] = value;
        }

        public Scene(Game game, int level = 0, double speed = 1.0)
        {
            Level = level;
            Speed = speed;
            Game = game;
            SceneSize = game.GameAreaSize;
            _scene = new IGameObject[SceneSize.Width, SceneSize.Height];
            Paddle = new Paddle(this);

            LoadScene();
        }

        private void LoadScene()
        {
            var file = File.ReadAllLines($"levels/level{Level}.txt");
            Paddle.Width = int.Parse(file[0]);
            for (var i = 0; i < SceneSize.Width; i++)
            {
                for (var j = 0; j < SceneSize.Height; j++)
                {
                    _scene[i, j] = file[j+1][i] switch

                    {
                        'B' => new BaseBrick(this, new Vector(i, j)),
                        'S' => new SimpleBrick(this, new Vector(i, j)),
                        _ => null
                    }
                    ;
                }
            }
        }

        public void GameOver()
        {
            Ball = null;
            Game.IsOver = true;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (var i = 0; i < _scene.GetLength(1); i++)
            {
                for (var j = 0; j < _scene.GetLength(0); j++)
                {
                    if (_scene[j,i]==null)
                    {
                        result.Append(" ");
                    }
                    else
                    {
                        result.Append(_scene[j, i]);
                    }
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        public bool InBounds(Vector v) => 0 <= v.X && v.X < SceneSize.Width && 0 <= v.Y && v.Y < SceneSize.Height;
    }
}
