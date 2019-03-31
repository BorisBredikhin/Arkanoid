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
        }

    }
}
