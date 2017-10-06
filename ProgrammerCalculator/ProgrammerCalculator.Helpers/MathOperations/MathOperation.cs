using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;
using ProgrammerCalculator.Helpers.Constants;

namespace ProgrammerCalculator.Helpers.MathOperations
{
    public abstract class MathOperation : IMathOperation
    {
        private IMathOperation NextOperation { get; set; }

        public void SetNextOperation(IMathOperation nextOperation)
        {
            this.NextOperation = nextOperation;
        }

        public long Calculate(OperatorType operatorType, long firstOperand, long secondOperand)
        {
            var result = this.TryCalculate(operatorType, firstOperand, secondOperand);

            if (result.HasValue)
            {
                return result.Value;
            }
            else if (this.NextOperation != null)
            {
                return this.NextOperation.Calculate(operatorType, firstOperand, secondOperand);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.UnsupportedOperationsErrorMessage);
            }
        }

        protected abstract long? TryCalculate(OperatorType operatorType, long firstOperand, long secondOperand);
    }
}
