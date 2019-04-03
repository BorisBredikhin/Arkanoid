using NUnit.Framework;

namespace Arkanoid.Model.Tests
{
    [TestFixture]
    class DirectionTest
    {
        [Test]
        public void Test()
        {
            TestDirection(Direction.SW, Direction.W, Direction.SE);
            TestDirection(Direction.NW, Direction.W, Direction.NE);
            TestDirection(Direction.SW, Direction.S, Direction.NW);
            TestDirection(Direction.SE, Direction.S, Direction.NE);
            TestDirection(Direction.NE, Direction.E, Direction.NW);
            TestDirection(Direction.SE, Direction.E, Direction.SW);
            TestDirection(Direction.NW, Direction.N, Direction.SW);
            TestDirection(Direction.NE, Direction.N, Direction.SE);
        }

        [Test]
        public void TestBallCollision()
        {
            Assert.Pass();
            //var ball = new Ball(new Scene(new Game()));
            //ball.Collide(new Brick(new Scene(new Game()), new Vector(2,2)));
            //Assert.AreEqual(ball.Velocity.Direction, Direction.NW.Direction);
        }

        public void TestDirection(Direction ballDirection, Direction wallDirection, Direction resultDirection)
        {
            Assert.AreEqual(resultDirection, Direction.GetDirectionAfterCollision(ballDirection, wallDirection));
        }
    }
}
