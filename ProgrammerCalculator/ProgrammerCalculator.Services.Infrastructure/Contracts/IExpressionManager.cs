using System;
using ProgrammerCalculator.Services.Infrastructure.Enumerations;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface IExpressionManager
    {
        long CurrentResult { get; }

        bool IsOperatorSelected { get; set; }

        void ResetResult();
    }
}
