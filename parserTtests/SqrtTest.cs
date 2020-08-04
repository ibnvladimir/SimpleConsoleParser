using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sqrt;


namespace ParserTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Pow_Test()
        {
            // Arrange
            var newton = new NewtonSqrt();

            // Act
            var actualPesult = newton.Pow(3.0, 2);
            var expectedResult = 9;

            // Assert
            Assert.AreEqual(expectedResult, actualPesult);
        }


        [TestMethod]
        public void Test_NewtonSqrtFormula()
        {
            // Arrange
            var newton = new NewtonSqrt();

            // Act
            var actualResult = newton.NewtonSqrtFormula(2, 4.0, 2);
            var expectedResult = 2;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_NewtonSqrtMethod()
        {
            // Arrange
            var newton = new NewtonSqrt();

            // Act
            var actualResult = newton.NewtonSqrtMethod(2, 9.0);
            var expectedResult = 3;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
