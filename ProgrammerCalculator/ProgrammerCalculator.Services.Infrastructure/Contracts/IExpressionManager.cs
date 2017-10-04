using System;
using ProgrammerCalculator.Services.Infrastructure.Enumerations;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface IExpressionManager
    {
        long CurrentResult { get; }

        OperatorType LastOperator { get; }

        void ChangeLastOperator(OperatorType operatorType);
        void ResetResult();
    }
}
