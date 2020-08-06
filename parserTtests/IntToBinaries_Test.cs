using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntToBinaries;

namespace parserTtests
{
 
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Test_ParseIntToBinaries()
        {
            //  Arrange
            uint value = 8;
            var myInt = new IntAsBinary(value);
            string actualResult;
            string expectedResult;

            // Act
            actualResult = myInt.ToString();
            expectedResult = Convert.ToString(value, 2);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
