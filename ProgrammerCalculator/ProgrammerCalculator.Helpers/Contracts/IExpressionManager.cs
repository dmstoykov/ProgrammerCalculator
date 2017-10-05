using System;

namespace ProgrammerCalculator.Helpers.Contracts
{
    public interface IExpressionManager
    {
        long CurrentResult { get; }

        bool IsOperatorSelected { get; set; }

        void ResetResult();
    }
}
