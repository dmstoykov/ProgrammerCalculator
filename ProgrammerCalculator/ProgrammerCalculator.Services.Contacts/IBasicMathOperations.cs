using System;

namespace ProgrammerCalculator.Services.Contacts
{
    public interface IBasicMathOperations
    {
        void Add(string number, int fromBase);

        void Substract(string number, int fromBase);

        void Multiply(string number, int fromBase);

        void Divide(string number, int fromBase);
    }
}
