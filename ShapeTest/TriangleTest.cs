using Shapes;

namespace ShapeTest
{
    public class TriangleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TriangleInitTest()
        {
            double a = 2d, b = 3d, c = 4d;

            Triangle triangle = new Triangle(a, b, c);

            Assert.NotNull(triangle);
            Assert.That(a, Is.EqualTo(triangle.SideA));
            Assert.That(b, Is.EqualTo(triangle.SideB));
            Assert.That(c, Is.EqualTo(triangle.SideC));
        }

        [TestCase(0, 0, 0)]
        [TestCase(-10, 10, 10)]
        [TestCase(10, -10, 10)]
        [TestCase(10, 10, -10)]
        [TestCase(8, 5, 13)]
        public void IncorrectTriangleInitTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void CalculateSquareTest()
        {
            double a = 3d, b = 4d, c = 5d;
            double expectedSquare = 6d;
            Triangle triangle = new Triangle(a, b, c);

            double actualSquare = triangle.CalculateSquare();

            Assert.NotNull(actualSquare);
            Assert.That(expectedSquare, Is.EqualTo(actualSquare));
        }

        [TestCase(7, 24, 26, ExpectedResult = false)]
        [TestCase(7, 24, 25, ExpectedResult = true)]
        [TestCase(7, 24, 25.00001, ExpectedResult = false)]
        public bool RightTriangleTest(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool isRight = triangle.IsRightTriangle;
            return isRight;
        }

    }
}