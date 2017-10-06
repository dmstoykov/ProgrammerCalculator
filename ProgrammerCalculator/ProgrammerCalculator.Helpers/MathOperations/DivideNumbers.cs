using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;
using ProgrammerCalculator.Helpers.Constants;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public class DivideNumbers : MathOperation, IMathOperation
    {
        public override long Calculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            if (operatorType == OperatorType.Division)
            {
                return firstOperand / secondOperand;
            }
            else if (this.nextOperation != null)
            {
                return this.nextOperation.Calculate(operatorType, firstOperand, secondOperand);
            }
            else
            {
                throw new ArgumentException(GlobalConstants.UnsupportedOperationsErrorMessage);
            }
        }
    }
}
