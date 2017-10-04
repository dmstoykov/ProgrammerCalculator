using System;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface IBasicMathOperations
    {
        string Add(string number, int fromBase);

        string Substract(string number, int fromBase);

        string Multiply(string number, int fromBase);

        string Divide(string number, int fromBase);

        string Evaluate(string number, int fromBase);
    }
}
