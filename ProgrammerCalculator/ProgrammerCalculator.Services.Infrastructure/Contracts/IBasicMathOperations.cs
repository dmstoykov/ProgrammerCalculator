using System;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface IBasicMathOperations
    {
        void Add(string number, int fromBase);

        void Substract(string number, int fromBase);

        void Multiply(string number, int fromBase);

        void Divide(string number, int fromBase);
    }
}
