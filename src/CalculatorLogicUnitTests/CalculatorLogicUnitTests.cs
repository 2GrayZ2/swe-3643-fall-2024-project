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
            double[] values = { 1, 2, 3, 4, 5 };

            // Act
            double mean = Calculator.ComputeMean(values);

            // Assert
            Assert.AreEqual(3.0, mean); // Expected mean is 3.0

        }

        [Test]
        public void ComputeMean_EmptyArray_ThrowsArgumentException()
        {
            //preq-UNIT-TEST-4
            //Arrange
            double[] values = { };

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => Calculator.ComputeMean(values));

            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot be null or empty");
        }

        [Test]
        public void ComputeSampleStandardDeviation_ValidInput_ReturnsCorrectSampleStandardDeviation()
        {
            //preq-UNIT-TEST-2

            //Arrange
            double[] values = { 9, 6, 8, 5, 7 };

            //Act
            double sampleStdDev = Calculator.ComputeSampleStandardDeviation(values);

            //Assert
            Assert.AreEqual(1.5811388300841898, sampleStdDev);
        }

        [Test]
        public void ComputeSampleStandardDeviation_EmptyArray_ThrowsArgumentException()
        {
            //preq-UNIT-TEST-2

            //Arrange
            double[] values = { };

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputeSampleStandardDeviation(values));

            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot be null or empty");
        }

        [Test]
        public void ComputeSampleStandardDeviation_ArrayOfSameValues_ReturnsZero()
        {
            //preq-UNIT-TEST-2

            //Arrange
            double[] values = { 12, 12, 12, 12, 12 };

            //Act
            double sampleStdDev = Calculator.ComputeSampleStandardDeviation(values);

            //Assert
            Assert.AreEqual(0.0, sampleStdDev);
        }

        [Test]
        public void ComputePopulationStandardDeviation_ArrayOfSameValues_ReturnsZero()
        {
            //preq-UNIT-TEST-2

            //Arrange
            double[] values = { 12, 12, 12, 12, 12 };

            //Act
            double sampleStdDev = Calculator.ComputePopulationStandardDeviation(values);

            //Assert
            Assert.AreEqual(0.0, sampleStdDev);
        }

        [Test]
        public void ComputePopulationStandardDeviation_ValidInput_ReturnsCorrectPopulationStdDev()
        {
            // Arrange
            double[] values = { 9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };

            // Act
            double popStdDev = Calculator.ComputePopulationStandardDeviation(values);

            // Assert
            Assert.AreEqual(2.9833, popStdDev, 0.0001); // Expected population std deviation
        }

        [Test]
        public void ComputePopulationStandardDeviation_EmptyArray_ThrowsArgumentException()
        {
            // Arrange
            double[] values = { };

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputePopulationStandardDeviation(values));

            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot be null or empty");
        }

        [Test]
        public void ComputePopulationStandardDeviation_ArrayContainsOneValue_ReturnsZero()
        {
            // Arrange
            double[] values = {1};

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputePopulationStandardDeviation(values));

            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot contain one value");
        }


    }
}