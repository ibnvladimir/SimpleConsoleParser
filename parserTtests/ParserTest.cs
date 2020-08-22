using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleParser;



namespace ParserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TryToConvert_FirstIsEmpty()
        {
            // Arrange
            Parser parser = new Parser();
            var message = "Похоже, что 1-е значение не задано; ";

            // Act
            parser.TryToConvert(",45");

            // Assert
            Assert.AreEqual(parser.ExceptionMessage, message);
        }

        [TestMethod]
        public void TryToConvert_SecondIsEmpty()
        {
            // Arrange
            Parser parser = new Parser();
            var message = "Похоже, что 2-е значение не задано; ";

            // Act
            parser.TryToConvert("45,");

            // Assert
            Assert.AreEqual(parser.ExceptionMessage, message);
        }

        [TestMethod]
        public void TryToConvert_CheCount_EqualTwo()
        {
            // Arrange
            Parser parser = new Parser();
            

            // Act
            parser.TryToConvert("45,23");

            // Assert
            Assert.IsTrue(parser.IsParseSuccessful);
        }

        [TestMethod]
        public void TryToConvert_CheCount_LessTwo()
        {
            // Arrange
            Parser parser = new Parser();
            var message = "Вы вели 1 координат, требуется 2; ";

            // Act
            parser.TryToConvert("45");

            // Assert
            Assert.AreEqual(parser.ExceptionMessage, message);
        }

        [TestMethod]
        public void TryToConvert_CheCount_MoreTwo()
        {
            // Arrange
            Parser parser = new Parser();
            var message = "Вы вели 3 координат, требуется 2; ";

            // Act
            parser.TryToConvert("45,34,67");

            // Assert
            Assert.AreEqual(parser.ExceptionMessage, message);
        }

        [TestMethod]
        public void TryToConvert_ToDecimal()
        {
            // Arrange
            Parser parser = new Parser();
            string[] value = { "23,456" };

            // Act
            parser.TryToConvertToDecimal(value);

            // Assert
            Assert.AreEqual(true, parser.IsParseSuccessful);
            //Assert.AreEqual(23.456m, parser.Result[0]);
        }
    }
}
