using System;
using ProgrammerCalculator.Helpers.Enumerations;

namespace ProgrammerCalculator.Helpers.Contracts
{
    public interface IMathOperation
    {
        void SetNextOperation(IMathOperation nextOperation);

        long Calculate(OperatorType operatorType, long firstOperand, long secondOperand);
    }
}
