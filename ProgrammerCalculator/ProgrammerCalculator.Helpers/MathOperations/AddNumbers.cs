using System;
using ProgrammerCalculator.Helpers.Enumerations;
using ProgrammerCalculator.Helpers.Contracts;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public class AddNumbers : MathOperation, IMathOperation
    {
        public override long Calculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            if (operatorType == OperatorType.Addition)
            {
                return firstOperand + secondOperand;
            }
            else if(this.nextOperation != null)
            {
                return this.nextOperation.Calculate(operatorType, firstOperand, secondOperand);
            }
            else
            {
                throw new ArgumentException("Supported operations: Add, Subtract, Multiply, Divide!");
            }
        }
    }
}
