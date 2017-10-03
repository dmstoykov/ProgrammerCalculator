using System;
using ProgrammerCalculator.Services.Contacts;

namespace ProgrammerCalculator.Services
{
    public class MultiBaseCalculator : ICalculator
    {
        private readonly INummericBaseConverter baseConverter;
        private long currentResult;
        private string lastInputString;

        public MultiBaseCalculator(INummericBaseConverter baseConverter)
            : base()
        {
            this.baseConverter = baseConverter;
            this.currentResult = 0;
            this.lastInputString = string.Empty;
        }

        public long CurrentResult
        {
            get
            {
                return this.currentResult;
            }
        }
        public string LastInputString
        {
            get
            {
                return this.lastInputString;
            }
        }

        public virtual void Add(string number, int fromBase)
        {
            var addent = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.currentResult += addent;
        }

        public virtual void Substract(string number, int fromBase)
        {
            var subtractor = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.currentResult -= subtractor;
        }

        public virtual void Multiply(string number, int fromBase)
        {
            var multiplicator = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.currentResult *= multiplicator;
        }

        public virtual void Divide(string number, int fromBase)
        {
            var divisor = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.currentResult /= divisor;
        }
    }
}
