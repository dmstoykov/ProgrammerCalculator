using System;
using ProgrammerCalculator.Helpers.Contracts;

namespace ProgrammerCalculator.Services
{
    public class NummericBaseConverter : INummericBaseConverter
    {
        private const string baseSystem = "0123456789ABCDEF";

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

                checked
                {
                    var poweredDigit = digit * Power(fromBase, i);
                    result += poweredDigit;
                }
            }

            return result;
        }

        public string DecToBase(long numberBase10, int toBase)
        {
            string result = string.Empty;

            bool negative = numberBase10 < 0;
            if (toBase != 10)
            {
                if (negative)
                {
                    numberBase10 = long.MaxValue + numberBase10 + 1;
                }

                do
                {
                    result = baseSystem[(int)(numberBase10 % toBase)] + result;
                    numberBase10 /= toBase;
                }
                while (numberBase10 > 0);

                if (negative)
                {
                    string mostSBit;
                    if (result[0] < 'A')
                    {
                        mostSBit = Convert.ToString(result[0] - '0', 2);
                        mostSBit = '1' + mostSBit;
                    }
                    else
                    {
                        mostSBit = Convert.ToString(result[0] - 'A' + 10, 2);
                        mostSBit = '1' + mostSBit;
                    }

                    long index = 0;

                    for (int i = mostSBit.Length - 1; i >= 0; i--)
                    {
                        index += (mostSBit[i] - '0') << (mostSBit.Length - 1 - i);
                    }

                    if (index < toBase)
                    {
                        result = baseSystem[(int)index] + result.Substring(1);
                    }
                    else
                    {
                        index = index / toBase;
                        result = baseSystem[(int)index] + result;
                    }
                }
            }
            else
            {
                result = numberBase10.ToString();
            }

            return result;
        }
    }
}