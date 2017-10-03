using System;

namespace ProgrammerCalculator.Services.Contacts
{
    public interface INummericBaseConverter
    {
        long ConvertToDecimal(string input, int fromBase);

        string ConvertFromDecimal(long input, int toBase);
    }
}
