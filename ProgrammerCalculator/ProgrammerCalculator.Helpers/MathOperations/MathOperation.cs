using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public abstract class MathOperation : IMathOperation
    {
        protected IMathOperation nextOperation;

        public void SetNextOperation(IMathOperation nextOperation)
        {
            this.nextOperation = nextOperation;
        }

        public abstract long Calculate(OperatorType operatorType, long firstOperand, long secondOperand);
    }
}
