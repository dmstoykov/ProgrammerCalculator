using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammerCalculator.Helpers.Contracts;

namespace ProgrammerCalculator.Helpers.Validators
{
    public class NumberInputValidator : INumberInputValidator
    {
        private readonly INummericBaseConverter baseConverter;

        public NumberInputValidator(INummericBaseConverter baseConverter)
        {
            this.baseConverter = baseConverter;
        }

        public bool ValidateNumber(string inputNumber, int fromBase)
        {
            var isNumberValid = true;

            try
            {
                long decNumber = this.baseConverter.BaseToDec(inputNumber, fromBase);
            }
            catch (OverflowException)
            {

                isNumberValid = false;
            }

            return isNumberValid;
        }
    }
}
