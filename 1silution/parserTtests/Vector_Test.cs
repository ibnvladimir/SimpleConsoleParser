using VectorOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace parserTtests
{
    [TestClass]
    public class Vector_Test
    {
        [TestMethod]
        public void ShouldReturnSumOfTwoVectors()
        {
            // Arrange
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            // Act
            var actualResult = vector1 + vector2;
            var expectedResult = new Vector(2, 4, 6);

            // Assert
            Assert.AreEqual($"{expectedResult}", $"{actualResult}");
        }

        [TestMethod]
        public void ShouldReturnMultiplicationVectorOnScalar()
        {
            // Arrange
            var vector1 = new Vector(1, 2, 3);
            var scalar = 10;

            // Act
            var actualResult = vector1 * scalar;
            var expectedResult = new Vector(10, 20, 30);

            // Assert
            Assert.AreEqual($"{expectedResult}", $"{actualResult}");
        }
    }
}
