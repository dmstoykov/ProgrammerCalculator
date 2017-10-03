using System;
using ProgrammerCalculator.Services.Contacts;

namespace ProgrammerCalculator.Services
{
    public class NummericBaseConverter : INummericBaseConverter
    {
        public string ConvertFromDecimal(long input, int toBase)
        {
            string result = Convert.ToString(input, toBase);

            return result;
        }

        public long ConvertToDecimal(string input, int fromBase)
        {
            long result = Convert.ToInt64(input, fromBase);

            return result;
        }
    }
}
