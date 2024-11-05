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
            //preq-UNIT-TEST-3

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
            //preq-UNIT-TEST-3
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
            //preq-UNIT-TEST-3
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
            //preq-UNIT-TEST-3
            // Arrange
            double[] values = {1};

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputePopulationStandardDeviation(values));

            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot contain one value");
        }
        
        [Test]
        public void ComputeZScore_ValidInput_ReturnsCorrectZScore()
        {
            //preq-UNIT-TEST-5
            // Arrange
            double value = 11.5;
            double mean = 7;
            double stdDev = 1.5811388300841898;

            //Act
            double zScore = Calculator.ComputeZScore(value, mean, stdDev);
            //Assert
            Assert.AreEqual(2.846049894151541, zScore);
        }
        
        [Test]
        public void ComputeZScore_AllEmptyParameters_ThrowsArgumentException()
        {
            //preq-UNIT-TEST-5
            // Arrange
            double value = double.NaN;
            double mean = double.NaN;
            double stdDev = double.NaN;

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputeZScore(value, mean, stdDev));
            //Assert
            Assert.AreEqual(exception.Message, "parameters cannot be NaN or empty");
        }
        
        [Test]
        public void ComputeZScore_MeanEqualsZero_ThrowsArgumentException()
        {
            //preq-UNIT-TEST-5
            // Arrange
            double value = 27;
            double mean = 0;
            double stdDev = 1.5811388300841898;

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputeZScore(value, mean, stdDev));
            //Assert
            Assert.AreEqual(exception.Message, "mean cannot be equal to zero");
        }
    }
}