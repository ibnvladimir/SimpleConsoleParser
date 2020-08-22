using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleApp;

namespace parserTtests
{
    [TestClass]
    public class Triangle_Tests
    {
        [TestMethod]
        public void ShuldFindTrianglePerimeter()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);

            // Act
            var actualResult = triangle.GetPerimeter();
            var expectedResult = 12;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShuldFindTriangleSquare()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);

            // Act
            var actualResult = triangle.GetSquare();
            var expectedResult = 6;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShuldRerurnWrongFormatError()
        {
            // Arrange

            var nonFormatSide = "45uy";
            
            // Act
            var actualResultNonFormat = TriangleApp.Program.ErrorMessage(nonFormatSide);
            
            // Assert
            Assert.AreEqual("Не верный формат, возможно вы ввели не число!", actualResultNonFormat);
        }

        [TestMethod]
        public void ShuldCheckOnZeroOrLess()
        {
            // Arrange
            var negativeSide = -1;
            var zeroSide = 0;

            // Act
            var actualResult = TriangleApp.Program.IsZeroOrLess(negativeSide);
            var actualResultZero = TriangleApp.Program.IsZeroOrLess(zeroSide);
            
            // Assert
            Assert.AreEqual(true, actualResult);
            Assert.AreEqual(true, actualResultZero);
        }

        [TestMethod]
        public void ShuldCheckTriangleOnExist()
        {
            // Arrange
            
            // Act
            var exist = TriangleApp.Program.IsTriangleExists(3,4,5);
            var nonExist = TriangleApp.Program.IsTriangleExists(3, 4, 56);

            // Assert
            Assert.AreEqual(true, exist);
            Assert.AreEqual(false, nonExist);
        }
    }
}
