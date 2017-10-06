using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public class DivideNumbers : MathOperation, IMathOperation
    {
        protected override long? TryCalculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            if (operatorType == OperatorType.Division)
            {
                return firstOperand / secondOperand;
            }

            return null;
        }
    }
}
