using System.Drawing;

namespace Arkanoid.Model
{
    public class Scene
    {
        public Size SceneSize { get; set; }

        public Scene(Size sceneSize)
        {
            SceneSize = sceneSize;
        }

    }
}
