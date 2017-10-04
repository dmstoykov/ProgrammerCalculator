using System;

namespace ProgrammerCalculator.Services.Infrastructure.Contracts
{
    public interface INummericBaseConverter
    {
        long ConvertToDecimal(string input, int fromBase);

        string ConvertFromDecimal(long input, int toBase);
    }
}
