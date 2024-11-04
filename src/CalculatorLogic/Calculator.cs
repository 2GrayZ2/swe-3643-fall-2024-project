using System;
namespace CalculatorLogic
{
    public class Calculator
    {
        public static double ComputeMean(double [] valueList)
        {
            if(valueList == null || valueList.Length == 0){
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }
            double sumAccumulator = 0;

            for (int i = 0; i < valueList.Length; i++) {
                sumAccumulator += valueList[i];
            }
            
            return sumAccumulator / valueList.Length;
        }
        
        public static double ComputeSquareOfDifferences(double [] valueList, double mean){
            if(valueList == null || valueList.Length == 0){
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

        public static double ComputeVariance(double squareOfDifferences, double numValues, bool isPopulation){
            if(!isPopulation){
                numValues -= 1;
            }
            if(numValues < 1){
                throw new ArgumentException("numValues is too low (sample size must be >= 2, population size must be >= 1)");
            }
            return squareOfDifferences / numValues;
        }

        public static double ComputeStandardDeviation(double [] valueList, bool isPopulation){
            if(valueList == null || valueList.Length == 0){
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }
            double mean = ComputeMean(valueList);
            double squareOfDifferences = ComputeSquareOfDifferences(valueList,mean);
            double variance = ComputeVariance(squareOfDifferences, valueList.Length, isPopulation);

            return Math.Sqrt(variance);
        }

        public static double ComputeSampleStandardDeviation(double [] valueList){
            if(valueList == null || valueList.Length == 0){
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }
            return ComputeStandardDeviation(valueList,false);
        }

        public static double ComputePopulationStandardDeviation(double [] valueList){
            if(valueList == null || valueList.Length == 0){
                throw new ArgumentException("valuesList parameter cannot be null or empty");
            }
            if (valueList.Length == 1)
            {
                throw new ArgumentException("valuesList parameter cannot contain one value");
            }

            return ComputeStandardDeviation(valueList, true);
        }
    }
}