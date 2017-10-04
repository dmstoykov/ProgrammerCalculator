using System;
using ProgrammerCalculator.Services.Infrastructure.Contracts;
using ProgrammerCalculator.Services.Infrastructure.Enumerations;

namespace ProgrammerCalculator.Services
{
    public class MultiBaseCalculator : ICalculator
    {
        private readonly INummericBaseConverter baseConverter;
        private long currentResult;
        private Sign lastOperation;

        public MultiBaseCalculator(INummericBaseConverter baseConverter)
        {
            this.baseConverter = baseConverter;
            this.currentResult = 0;
            this.lastOperation = Sign.None;
        }

        public long CurrentResult
        {
            get
            {
                return this.currentResult;
            }
        }
        public Sign LastOperation
        {
            get
            {
                return this.lastOperation;
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

        public void ResetResult()
        {
            this.lastOperation = Sign.None;
            this.currentResult = 0;
        }
    }
}
