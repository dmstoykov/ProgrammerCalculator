using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public class MultiplyNumbers : MathOperation
    {
        protected override long? TryCalculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            if (operatorType == OperatorType.Multiplication)
            {
                return firstOperand * secondOperand;
            }

            return null;
        }
    }
}
