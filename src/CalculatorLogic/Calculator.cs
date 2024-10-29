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
        
        
    }
}