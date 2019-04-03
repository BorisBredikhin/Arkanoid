using System.Drawing;

namespace Arkanoid.Model
{
    public class Scene
    {
        public Size SceneSize { get; set; }

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
            SceneSize = game.GameAreaSize;
            _scene = new IGameObject[SceneSize.Width, SceneSize.Height];

            for (var i = 0; i < SceneSize.Width; i++)
            {
                _scene[i, 0] = new BaseBrick(this, new Vector(i, 0));
            }

            for (var i = 0; i < SceneSize.Height; i++)
            {
                _scene[0, i] = new BaseBrick(this, new Vector(0, i));
                _scene[SceneSize.Width-1, i] = new BaseBrick(this, new Vector(SceneSize.Width-1, i));
            }
        }

    }
}
