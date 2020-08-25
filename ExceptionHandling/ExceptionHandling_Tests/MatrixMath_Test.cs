using System;
using System.Collections.Generic;
using System.IO;
using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionHandling_Tests
{
    [TestClass]
    public class MatrixMath_Test
    {
        [TestMethod]
        public void ShuldReturnCorrectResultOf_Add()
        {
            // Arrange
            Matrix matrixA = Matrix.FillForTests(2, 2, new List<int>(){ 1, 1, 1, 1});
            Matrix matrixB = Matrix.FillForTests(2, 2, new List<int>() { 2, 2, 2, 2 });
            Matrix templateMatrix = Matrix.FillForTests(2, 2, new List<int>() {3, 3, 3, 3 });

            // Act
            Matrix resultMatrix = MatrixMath.Add(matrixA, matrixB);

            // Assert
            Assert.AreEqual(templateMatrix, resultMatrix);
        }

        [TestMethod]
        public void ShuldReturnCorrectResultOf_Subtract()
        {
            // Arrange
            Matrix matrixA = Matrix.FillForTests(2, 2, new List<int>() { 1, 1, 1, 1 });
            Matrix matrixB = Matrix.FillForTests(2, 2, new List<int>() { 3, 3, 3, 3 });
            Matrix templateMatrix = Matrix.FillForTests(2, 2, new List<int>() { 2, 2, 2, 2 });

            // Act
            Matrix resultMatrix = MatrixMath.Subtract(matrixB, matrixA);

            // Assert
            Assert.AreEqual(templateMatrix, resultMatrix);
        }

        [TestMethod]
        public void ShuldReturnCorrectResultOf_Multiply()
        {
            // Arrange
            Matrix matrixA = Matrix.FillForTests(2, 2, new List<int>() { 1, 2, 3, 4 });
            Matrix matrixB = Matrix.FillForTests(2, 2, new List<int>() { 5, 6, 7, 8 });
            Matrix templateMatrix = Matrix.FillForTests(2, 2, new List<int>() { 19, 22, 43, 50 });

            // Act
            Matrix resultMatrix = MatrixMath.Multiple(matrixA, matrixB);

            // Assert
            Assert.AreEqual(templateMatrix, resultMatrix);
        }

        [TestMethod]
        public void ShuldReturnExceptions()
        {
            // Arrange
            Matrix matrixA = Matrix.FillForTests(2, 2, new List<int>() { 1, 2, 3, 4 });
            Matrix matrixB = Matrix.FillForTests(1, 2, new List<int>() { 5, 6});
           
            
            // Assert
            Assert.ThrowsException<InvalidDimensionException>(() => MatrixMath.Multiple(matrixA, matrixB));
            Assert.ThrowsException<InvalidDimensionException>(() => MatrixMath.Add(matrixA, matrixB));
            Assert.ThrowsException<InvalidDimensionException>(() => MatrixMath.Subtract(matrixA, matrixB));
        }
    }
}
