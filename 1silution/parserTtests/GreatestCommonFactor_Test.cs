using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatestCommonFactor;

namespace parserTtests
{
    [TestClass]
    public class GreatestCommonFactor_Test
    {
        [TestMethod]
        public void ShouldReturnGreatestCommonFactor_Of2Integers()
        {
            // Arrange
            var gcf = new GreatestCommonFactorCounter();

            // Act
            var actualResult = gcf.FactorCounter(6, 12);
            var expectedResult = 6;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShouldReturnGreatestCommonFactor_OfThreeOrMoreIntegers()
        {
            // Arrange
            var gcf = new GreatestCommonFactorCounter();

            // Act
            var actualResult = gcf.FactorCounter(5, 15, new int[] {30, 100500} );
            var expectedResult = 5;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShouldReturnGreatestCommonFactor_SteinAlgorithm()
        {
            // Arrange
            var gcf = new GreatestCommonFactorCounter();

            // Act
            var actualResult = gcf.Stein(5, 15);
            var expectedResult = 5;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
