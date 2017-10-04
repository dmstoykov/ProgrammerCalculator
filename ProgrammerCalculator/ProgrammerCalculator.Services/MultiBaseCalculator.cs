using System;
using ProgrammerCalculator.Services.Infrastructure.Contracts;
using ProgrammerCalculator.Services.Infrastructure.Enumerations;
using System.Collections.Generic;

namespace ProgrammerCalculator.Services
{
    public class MultiBaseCalculator : ICalculator
    {
        private readonly INummericBaseConverter baseConverter;
        private long currentResult;
        private OperatorType lastOperator;
        private Queue<long> operands;

        public MultiBaseCalculator(INummericBaseConverter baseConverter)
        {
            this.baseConverter = baseConverter;
            this.operands = new Queue<long>();
            this.currentResult = 0;
        }

        public long CurrentResult
        {
            get
            {
                return this.operands.Peek();
            }
        }
        public OperatorType LastOperator
        {
            get
            {
                return this.lastOperator;
            }
        }

        public virtual long Add(string number, int fromBase)
        {
            var addent = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(addent);

            if (this.lastOperator == OperatorType.None)
            {
                this.lastOperator = OperatorType.Addition;
                return 0;
            }
            else
            {
                this.Evaluate(this.LastOperator);
                this.lastOperator = OperatorType.Addition;
            }

            return this.CurrentResult;
        }

        public virtual long Substract(string number, int fromBase)
        {
            var subtractor = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(subtractor);

            if (this.lastOperator == OperatorType.None)
            {
                this.lastOperator = OperatorType.Subtraction;
                return 0;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = OperatorType.Subtraction;
            }

            return this.CurrentResult;
        }

        public virtual long Multiply(string number, int fromBase)
        {
            var multiplicator = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(multiplicator);

            if (this.lastOperator == OperatorType.None)
            {
                this.lastOperator = OperatorType.Multiplication;
                return 0;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = OperatorType.Multiplication;
            }

            return this.CurrentResult;
        }

        public virtual long Divide(string number, int fromBase)
        {
            var divisor = this.baseConverter.ConvertToDecimal(number, fromBase);

            this.operands.Enqueue(divisor);

            if (this.lastOperator == OperatorType.None)
            {
                this.lastOperator = OperatorType.Division;
                return 0;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = OperatorType.Division;
            }

            return this.CurrentResult;
        }

        private void Evaluate(OperatorType operatorType)
        {
            var firstOperand = this.operands.Dequeue();
            var secondOperand = this.operands.Dequeue();

            switch (this.LastOperator)
            {
                case OperatorType.Addition:
                    this.operands.Enqueue(firstOperand + secondOperand);
                    break;
                case OperatorType.Subtraction:
                    this.operands.Enqueue(firstOperand - secondOperand);
                    break;
                case OperatorType.Multiplication:
                    this.operands.Enqueue(firstOperand * secondOperand);
                    break;
                case OperatorType.Division:
                    this.operands.Enqueue(firstOperand / secondOperand);
                    break;
                default:
                    break;
            }
        }

        public long Evaluate(string number, int fromBase)
        {
            var newOperand = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(newOperand);

            this.Evaluate(this.LastOperator);

            return this.CurrentResult;
        }

        public void ResetResult()
        {
            this.lastOperator = OperatorType.None;
            this.operands = new Queue<long>();
        }
    }
}
