using System;
using ProgrammerCalculator.Helpers.Enumerations;
using ProgrammerCalculator.Helpers.Contracts;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public class AddNumbers : MathOperation, IMathOperation
    {
        protected override long? TryCalculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            if (operatorType == OperatorType.Addition)
            {
                return firstOperand + secondOperand;
            }

            return null;
        }
    }
}
