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

        public Scene(Size sceneSize)
        {
            SceneSize = sceneSize;
            _scene = new IGameObject[SceneSize.Width, SceneSize.Height];
        }

    }
}
