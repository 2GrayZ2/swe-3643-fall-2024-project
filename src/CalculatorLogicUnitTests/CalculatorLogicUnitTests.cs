using System;
using CalculatorLogic;
using NUnit.Framework;

namespace CalculatorLogicUnitTests
{
    [TestFixture]
    public class CalculatorLogicUnitTests
    {
        [Test]
        public void ComputeMean_ValidInput_ReturnsCorrectMean()
        {
            //preq-UNIT-TEST-4
            // Arrange
            double [] values = {1, 2, 3, 4, 5};

            // Act
            double mean = Calculator.ComputeMean(values);

            // Assert
            Assert.AreEqual(3.0, mean);  // Expected mean is 3.0
            
        }

        [Test]
        public void ComputeMean_EmptyArray_ThrowsArgumentException()
        {
            //preq-UNIT-TEST-4
            //Arrange
            double [] values = {};
            
            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => Calculator.ComputeMean(values));
            
            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot be null or empty");
        }
    }
}