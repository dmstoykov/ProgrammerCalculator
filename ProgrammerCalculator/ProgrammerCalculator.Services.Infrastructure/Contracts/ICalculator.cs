using System;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface ICalculator : IBasicMathOperations, IExpressionManager
    {
    }
}
