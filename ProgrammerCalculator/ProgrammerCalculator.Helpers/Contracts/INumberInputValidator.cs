using System;

namespace ProgrammerCalculator.Helpers.Contracts
{
    public interface INumberInputValidator
    {
        bool ValidateNumber(string number, int fromBase);
    }
}
