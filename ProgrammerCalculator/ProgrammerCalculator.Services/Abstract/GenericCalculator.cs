using System;
using ProgrammerCalculator.Services.Infrastructure.Contracts;

namespace ProgrammerCalculator.Services.Abstract
{
    public abstract class GenericCalculator
    {
        private long currentResult;
        private string lastInputString;

        public GenericCalculator()
        {
            this.currentResult = 0;
            this.lastInputString = string.Empty;
        }

        public long CurrentResult
        {
            get
            {
                return this.currentResult;
            }
            private set
            {
                this.currentResult = value;
            }
        }
        public string LastInputString
        {
            get
            {
                return this.lastInputString;
            }
            private set
            {
                this.lastInputString = value;
            }
        }

        public virtual void Add(long number)
        {
            this.currentResult += number;
        }

        public virtual void Substract(long number)
        {
            this.currentResult -= number;
        }

        public virtual void Multiply(long number)
        {
            this.currentResult *= number;
        }

        public virtual void Divide(long number)
        {
            this.currentResult /= number;
        }
    }
}
