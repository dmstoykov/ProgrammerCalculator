using System;
using ProgrammerCalculator.Helpers.Contracts;

namespace ProgrammerCalculator.Services
{
    public class NummericBaseConverter : INummericBaseConverter
    {
        //public string ConvertFromDecimal(long input, int toBase)
        //{
        //    string result = Convert.ToString(input, toBase).ToUpper();

        //    return result;
        //}

        //public long ConvertToDecimal(string input, int fromBase)
        //{
        //    long result = Convert.ToInt64(input, fromBase);
        //    return result;
        //}

        private long Power(long number, long power)
        {
            long result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }

        public long BaseToDec(string number, int fromBase)
        {
            long result = 0;
            long digit = 0;
            number = number.ToUpper();

            for (int i = 0; i < number.Length; i++)
            {
                int position = number.Length - i - 1;

                if (number[position] >= '0' && number[position] <= '9')
                {
                    digit = number[position] - '0';
                }
                else if (number[position] >= 'A' && number[position] <= 'F')
                {
                    digit = number[position] - 'A' + 10;
                }

                var poweredDigit = digit * Power(fromBase, i);

                checked
                {
                    result += poweredDigit;
                }

            }

            return result;
        }

        public string DecToBase(long decNumber, int toBase)
        {
            string result = "";

            while (decNumber > 0)
            {
                long digit = decNumber % toBase;

                if (digit >= 0 && digit <= 9)
                {
                    result = (char)(digit + '0') + result;
                }
                else if (digit >= 10 && digit <= 15)
                {
                    result = (char)(digit - 10 + 'A') + result;
                }

                decNumber /= toBase;
            }

            return result;
        }
    }
}
