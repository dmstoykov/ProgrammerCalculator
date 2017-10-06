using System;
using ProgrammerCalculator.Helpers.Contracts;

namespace ProgrammerCalculator.Services
{
    public class NummericBaseConverter : INummericBaseConverter
    {
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
        //public static string DecToBase(string numberBaseS, int baseS, int baseD)
        //{
        //    string numberBaseD = "";
        //    long numberBase10 = 0;
        //    if (baseS != 10)
        //    {
        //        //  Using own method for power because Math.Pow is slow and main use for floating point powers
        //        for (int pow = 0, i = numberBaseS.Length - 1; i >= 0; pow++, i--)
        //        {
        //            if (numberBaseS[i] < 'A')
        //            {
        //                numberBase10 += (numberBaseS[i] - '0') * Power(baseS, pow);
        //            }
        //            else
        //            {
        //                numberBase10 += (numberBaseS[i] - 'A' + 10) * Power(baseS, pow);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        numberBase10 = long.Parse(numberBaseS);
        //    }
        //    string baseUni = "0123456789ABCDEF";
        //    bool negative = numberBase10 < 0;
        //    if (baseD != 10)
        //    {
        //        if (negative)
        //        {
        //            numberBase10 = long.MaxValue + numberBase10 + 1;
        //        }
        //        do
        //        {
        //            //numberBaseD = (char)((numberBase10 % baseD) + '0') + numberBaseD;
        //            numberBaseD = baseUni[(int)(numberBase10 % baseD)] + numberBaseD;
        //            numberBase10 /= baseD;
        //        } while (numberBase10 > 0);

        //        if (negative)
        //        {
        //            string mostSBit;
        //            if (numberBaseD[0] < 'A')
        //            {
        //                mostSBit = Convert.ToString(numberBaseD[0] - '0', 2);
        //                mostSBit = "1" + mostSBit;
        //            }
        //            else
        //            {
        //                mostSBit = Convert.ToString(numberBaseD[0] - 'A' + 10, 2);
        //                mostSBit = "1" + mostSBit;
        //            }
        //            long index = 0;
        //            for (int i = mostSBit.Length - 1; i >= 0; i--)
        //            {
        //                index += (mostSBit[i] - '0') << (mostSBit.Length - 1 - i);
        //            }
        //            if (index < baseD)
        //            {
        //                numberBaseD = baseUni[(int)index] + numberBaseD.Substring(1);
        //            }
        //            else
        //            {
        //                index = index % baseD;
        //                numberBaseD = baseUni[(int)index] + numberBaseD;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        numberBaseD = numberBase10.ToString();
        //    }

        //    return numberBaseD;
        //}
    }
}
