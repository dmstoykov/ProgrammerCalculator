using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public class DivideNumbers : MathOperation
    {
        protected override long? TryCalculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            if (operatorType == OperatorType.Division && secondOperand != 0)
            {
                return firstOperand / secondOperand;
            }

            return null;
        }
    }
}
