using System.Drawing;

namespace Arkanoid.Model
{
    public class Scene
    {
        public Size SceneSize { get; set; }
        public Ball Ball;

        private readonly Game _game;
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

        public Scene(Game game)
        {
            _game = game;
            SceneSize = game.GameAreaSize;
            _scene = new IGameObject[SceneSize.Width, SceneSize.Height];

            for (var i = 0; i < SceneSize.Width; i++)
            {
                _scene[i, 0] = new BaseBrick(this, new Vector(i, 0));
                // for debug
                //_scene[i, SceneSize.Height-1] = new BaseBrick(this, new Vector(i, SceneSize.Height-1));
            }

            for (var i = 0; i < SceneSize.Height; i++)
            {
                _scene[0, i] = new BaseBrick(this, new Vector(0, i));
                _scene[SceneSize.Width-1, i] = new BaseBrick(this, new Vector(SceneSize.Width-1, i));
            }
        }

        public void GameOver()
        {
            Ball = null;
            _game.IsOver = true;
        }
    }
}
