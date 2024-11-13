using System;
using System.Linq;
using System.Collections.Generic;

namespace CalculatorLogic
{
    public class Calculator
    {
        // preq-LOGIC-5
        public static double ComputeMean(double[] valueList)
        {
            if (valueList == null || valueList.Length == 0)
            {
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }

            double sumAccumulator = 0;

            for (int i = 0; i < valueList.Length; i++)
            {
                sumAccumulator += valueList[i];
            }

            return sumAccumulator / valueList.Length;
        }

        public static double ComputeSquareOfDifferences(double[] valueList, double mean)
        {
            if (valueList == null || valueList.Length == 0) { 
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }

            double squareAccumulator = 0;
            for (int i = 0; i < valueList.Length; i++)
            {
                double difference = valueList[i] - mean;
                double squareOfDifference = difference * difference;
                squareAccumulator += squareOfDifference;
            }
            return squareAccumulator;
        }

        public static double ComputeVariance(double squareOfDifferences, double numValues, bool isPopulation)
        {
            if (!isPopulation)
            {
                numValues -= 1;
            }

            if (numValues < 1) { 
                throw new ArgumentException("numValues is too low (sample size must be >= 2, population size must be >= 1)");
            }

            return squareOfDifferences / numValues;
        }

        public static double ComputeStandardDeviation(double[] valueList, bool isPopulation)
        {
            if (valueList == null || valueList.Length == 0) { 
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }

            double mean = ComputeMean(valueList);
            double squareOfDifferences = ComputeSquareOfDifferences(valueList, mean);
            double variance = ComputeVariance(squareOfDifferences, valueList.Length, isPopulation);

            return Math.Sqrt(variance);
        }

        // preq-LOGIC-3
        public static double ComputeSampleStandardDeviation(double[] valueList)
        {
            if (valueList == null || valueList.Length == 0)
            {
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }

            return ComputeStandardDeviation(valueList, false);
        }

        // preq-LOGIC-4
        public static double ComputePopulationStandardDeviation(double[] valueList)
        {
            if (valueList == null || valueList.Length == 0)
            {
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }

            if (valueList.Length == 1)
            {
                throw new ArgumentException("valuesList parameter cannot contain one value");
            }

            return ComputeStandardDeviation(valueList, true);
            
        }

        // preq-LOGIC-6
        public static double ComputeZScore(double value, double mean, double standardDeviation)
        {
            if (mean == 0)
            {
                throw new ArgumentException("mean cannot be equal to zero");
            }

            if (double.IsNaN(value) || double.IsNaN(mean) || double.IsNaN(standardDeviation))
            {
                throw new ArgumentException("parameters cannot be NaN or empty");
            }

            return (value - mean) / standardDeviation;
        }

        // preq-LOGIC-7
        public static (double Intercept, double Slope) ComputeSingleLinearRegression(List<(double X, double Y)> dataPoints)
        {
            int n = dataPoints.Count;
            
            if (n == 0)
            {
                throw new ArgumentException("Data points cannot be empty.");
            }
            
            bool allZero = true;
            foreach (var p in dataPoints)
            {
                if (p.X != 0 || p.Y != 0)
                {
                    allZero = false;
                    break;
                }
            }
            if (allZero)
            {
                throw new ArgumentException("All X and Y values are zero.");
            }
            
            if (dataPoints.All(p =>  p.X == dataPoints[0].X))
            {
                throw new ArgumentException("All X values are the same, making the slope undefined.");
            }
            if (dataPoints.All(p => p.Y == dataPoints[0].Y))
            {
                throw new ArgumentException("All Y values are the same, making the slope undefined.");
            }
            
            double sumX = dataPoints.Sum(p => p.X);
            double sumY = dataPoints.Sum(p => p.Y);
            double sumXy = dataPoints.Sum(p => p.X * p.Y);
            double sumXSquare = dataPoints.Sum(p => p.X * p.X);

            double slope = (n * sumXy - sumX * sumY) / (n * sumXSquare - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            return (intercept, slope);
        }

        public static double PredictYFromLinearRegression(double xValue, double slope, double intercept)
        {
            if (double.IsNaN(xValue) || double.IsNaN(slope) || double.IsNaN(intercept))
            {
                throw new ArgumentException("Missing one or more parameters.");
            }

            return ((xValue * slope) + intercept);
        }
    }
}