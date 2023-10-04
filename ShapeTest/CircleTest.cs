using Shapes;

namespace ShapeTest
{
    public class CircleTest
    {

        [Test]
        public void CircleInitTest()
        {
            double r = 2d;

            Circle circle = new Circle(r);

            Assert.NotNull(circle);
            Assert.That(r, Is.EqualTo(circle.Radius));
        }


        [TestCase(0)]
        [TestCase(-2)]
        public void IncorrectCircleInitTest(double r)
        {
            Assert.Catch<ArgumentException>(() => new Circle(r));
        }


        [Test]
        public void CalculateSquareTest()
        {
            double r = 2d;
            Circle circle = new Circle(r);
            double expectedSquare = Math.PI * Math.Pow(r, 2);

            double actualSquare = circle.CalculateSquare();

            Assert.That(expectedSquare, Is.EqualTo(actualSquare));
        }

    }
}
