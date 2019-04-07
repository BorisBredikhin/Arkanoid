using NUnit.Framework;

namespace Arkanoid.Model.Tests
{
    [TestFixture]
    class PaddleTests
    {
        [Test]
        public void MovementTest()
        {
            var paddle = new Paddle((new Game()).Scene);
            var pX = new Vector(paddle.Position.X, paddle.Position.Y);
            paddle.MoveRight();
            Assert.IsTrue(paddle.Position.X == pX.X + 1 && paddle.Position.Y == pX.Y, $"{paddle.Position}, {pX}");

            pX = new Vector(paddle.Position.X, paddle.Position.Y); ;
            paddle.MoveLeft();
            Assert.IsTrue(paddle.Position.X == pX.X - 1 && paddle.Position.Y == pX.Y, $"{paddle.Position}, {pX}");
        }

        [Test]
        public void NotMovesThroughBorder()
        {
            var scene = (new Game()).Scene;
            var leftPaddle = new Paddle(scene);
            leftPaddle.Position.X = 1;
            leftPaddle.MoveLeft();
            Assert.AreEqual(1, leftPaddle.Position.X);

            var rightPaddle = new Paddle(scene);
            rightPaddle.Position.X = scene.SceneSize.Width-2;
            rightPaddle.MoveRight();
            Assert.AreEqual(scene.SceneSize.Width - 2, rightPaddle.Position.X);
        }
    }
}
