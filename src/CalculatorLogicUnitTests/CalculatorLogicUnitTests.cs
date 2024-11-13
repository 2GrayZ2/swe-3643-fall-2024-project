using System;
using System.Collections.Generic;
using CalculatorLogic;
using NUnit.Framework;

namespace CalculatorLogicUnitTests
{
    [TestFixture]
    public class CalculatorLogicUnitTests
    {
        //preq-UNIT-TEST-4
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

        //preq-UNIT-TEST-4
        [Test]
        public void ComputeMean_EmptyArray_ThrowsArgumentException()
        {
            //Arrange
            double [] values = {};
            
            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => Calculator.ComputeMean(values));
            
            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot be null or empty");
        }
        
        //preq-UNIT-TEST-2
         [Test]
        public void ComputeSampleStandardDeviation_ValidInput_ReturnsCorrectSampleStandardDeviation()
        {

            //Arrange
            double[] values = { 9, 6, 8, 5, 7 };

            //Act
            double sampleStdDev = Calculator.ComputeSampleStandardDeviation(values);

            //Assert
            Assert.AreEqual(1.5811388300841898, sampleStdDev);
        }

        //preq-UNIT-TEST-2
        [Test]
        public void ComputeSampleStandardDeviation_EmptyArray_ThrowsArgumentException()
        {

            //Arrange
            double[] values = { };

            //Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputeSampleStandardDeviation(values));

            //Assert
            Assert.AreEqual(exception.Message, "valuesList parameter cannot be null or empty");
        }

        //preq-UNIT-TEST-2
        [Test]
        public void ComputeSampleStandardDeviation_ArrayOfSameValues_ReturnsZero()
        {

            //Arrange
            double[] values = { 12, 12, 12, 12, 12 };

            //Act
            double sampleStdDev = Calculator.ComputeSampleStandardDeviation(values);

            //Assert
            Assert.AreEqual(0.0, sampleStdDev);
        }

        //preq-UNIT-TEST-3
        [Test]
        public void ComputePopulationStandardDeviation_ArrayOfSameValues_ReturnsZero()
        {

            //Arrange
            double[] values = { 12, 12, 12, 12, 12 };

            //Act
            double sampleStdDev = Calculator.ComputePopulationStandardDeviation(values);

            //Assert
            Assert.AreEqual(0.0, sampleStdDev);
        }

        //preq-UNIT-TEST-3
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

        //preq-UNIT-TEST-3
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

        //preq-UNIT-TEST-3
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
        
        //preq-UNIT-TEST-5
        [Test]
        public void ComputeZScore_ValidInput_ReturnsCorrectZScore()
        {
            
            // Arrange
            double value = 11.5;
            double mean = 7;
            double stdDev = 1.5811388300841898;

            //Act
            double zScore = Calculator.ComputeZScore(value, mean, stdDev);
            //Assert
            Assert.AreEqual(2.846049894151541, zScore);
        }
        
        //preq-UNIT-TEST-5
        [Test]
        public void ComputeZScore_AllEmptyParameters_ThrowsArgumentException()
        {
            
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
        
        //preq-UNIT-TEST-5
        [Test]
        public void ComputeZScore_MeanEqualsZero_ThrowsArgumentException()
        {
            
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

        // preq-UNIT-TEST-6
        [Test]
        public void ComputeSingleLinearRegression_ValidInput_ReturnsCorrectSingleLinearRegression()
        {
            //Arrange
            List<(double X, double Y)> dataPoints = new List<(double X, double Y)>
            {
                (1.47, 52.21),
                (1.5, 53.12),
                (1.52, 54.48),
                (1.55, 55.84),
                (1.57, 57.2),
                (1.6, 58.57),
                (1.63, 59.93),
                (1.65, 61.29),
                (1.68, 63.11),
                (1.7, 64.47),
                (1.73, 66.28),
                (1.75, 68.1),
                (1.78, 69.92),
                (1.8, 72.19),
                (1.83, 74.46)
            };

            //Act
            var result = Calculator.ComputeSingleLinearRegression(dataPoints);
            
            //Assert
            Assert.AreEqual(-39.061955918838656, result.Intercept, 1e-15, "Intercept is incorrect");
            Assert.AreEqual(61.272186542107434, result.Slope, 1e-15, "Slope is incorrect");
            
        }

        // preq-UNIT-TEST-6
        [Test]
        public void ComputeSingleLinearRegression_EmptyInput_ThrowsArgumentException()
        {
            // Arrange
            List<(double X, double Y)> dataPoints = new List<(double X, double Y)>();

            // Act
            Exception exception =
                Assert.Throws<ArgumentException>(() => Calculator.ComputeSingleLinearRegression(dataPoints));
            // Assert
            Assert.AreEqual(exception.Message, "Data points cannot be empty.");
        }
        
        // preq-UNIT-TEST-6
        [Test]
        public void ComputeSingleLinearRegression_XValuesAreSame_ThrowsArgumentException()
        {
            // Arrange
            List<(double X, double Y)> dataPoints = new List<(double X, double Y)>
            {
                (1.47, 52.21),
                (1.47, 53.12),
                (1.47, 54.48),
                (1.47, 55.84),
                (1.47, 57.2),
            };

            // Act
            Exception exception = Assert.Throws<ArgumentException>(() => Calculator.ComputeSingleLinearRegression(dataPoints));
            // Assert
            Assert.AreEqual(exception.Message, "All X values are the same, making the slope undefined.");
        }
        
        // preq-UNIT-TEST-6
        [Test]
        public void ComputeSingleLinearRegression_YValuesAreSame_ThrowsArgumentException()
        {
            // Arrange
            List<(double X, double Y)> dataPoints = new List<(double X, double Y)>
            {
                (1.0, 5.0),
                (2.0, 5.0),
                (3.0, 5.0),
                (4.0, 5.0),
                (5.0, 5.0)
            };

            // Act
            Exception exception = Assert.Throws<ArgumentException>(() => Calculator.ComputeSingleLinearRegression(dataPoints));
            // Assert
            Assert.AreEqual(exception.Message, "All Y values are the same, making the slope undefined.");
        }
        
        // preq-UNIT-TEST-6
        [Test]
        public void ComputeSingleLinearRegression_XYValuesAreAllZero_ThrowsArgumentException()
        {
            // Arrange
            var dataPoints = new List<(double X, double Y)>
            {
                (0, 0),
                (0, 0),
                (0, 0)
            };

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Calculator.ComputeSingleLinearRegression(dataPoints));
            // Assert
            Assert.AreEqual(ex.Message,"All X and Y values are zero.");
        }
        
        // preq-UNIT-TEST-7
        [Test]
        public void PredictYFromLinearRegression_ValidInput_ReturnsCorrectPrediction()
        {
            // Arrange
            double xValue = 1.535;
            double slope = 61.272186542107434;
            double intercept = -39.061955918838656;
            
            // Act
            var prediction = Calculator.PredictYFromLinearRegression(xValue, slope, intercept);
            // Assert
            Assert.AreEqual(54.990850423296244, prediction);
        }
        
        // preq-UNIT-TEST-7
        [Test]
        public void PredictYFromLinearRegression_MissingOneOrMoreParams_ThrowsArgumentException()
        {
            // Arrange
            double xValue = Double.NaN;
            double slope = Double.NaN;
            double intercept = Double.NaN;
            
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Calculator.PredictYFromLinearRegression(xValue, slope, intercept));
            // Assert
            Assert.AreEqual(ex.Message,"Missing one or more parameters.");
        }
        
        [Test]
        public void ComputeSquareOfDifferences_EmptyList_ThrowsArgumentException()
        {
            // Arrange
            double [] valueList = new double[0];
            
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Calculator.ComputeSquareOfDifferences(valueList,50));
            // Assert
            Assert.AreEqual(ex.Message,"valuesList parameter cannot be null or empty");
        }
        
        [Test]
        public void ComputeVariance_NumValuesIsTooLow_ThrowsArgumentException()
        {
            // Arrange
            double numValues = 0;
            
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Calculator.ComputeVariance(35,numValues,true));
            // Assert
            Assert.AreEqual(ex.Message,"numValues is too low (sample size must be >= 2, population size must be >= 1)");
        }
        
        [Test]
        public void ComputeStandardDeviation_ValueListParamIsNullOrEmpty_ThrowsArgumentException()
        {
            // Arrange
            double [] valueList = {};
            
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Calculator.ComputeStandardDeviation(valueList,false));
            // Assert
            Assert.AreEqual(ex.Message,"valuesList parameter cannot be null or empty");
        }
    }
}