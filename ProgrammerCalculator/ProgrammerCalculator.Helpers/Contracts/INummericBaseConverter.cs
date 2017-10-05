using System;

namespace ProgrammerCalculator.Helpers.Contracts
{
    public interface INummericBaseConverter
    {
        long BaseToDec(string number, int fromBase);

        string DecToBase(long decNumber, int toBase);
    }
}
