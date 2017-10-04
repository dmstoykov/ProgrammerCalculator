using System;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface IBasicMathOperations
    {
        long Add(string number, int fromBase);

        long Substract(string number, int fromBase);

        long Multiply(string number, int fromBase);

        long Divide(string number, int fromBase);

        long Evaluate(string number, int fromBase);
    }
}
