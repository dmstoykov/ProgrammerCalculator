using System;
using ProgrammerCalculator.Services.Infrastructure.Contracts;
using ProgrammerCalculator.Services.Infrastructure.Enumerations;
using System.Collections.Generic;

namespace ProgrammerCalculator.Services
{
    public class MultiBaseCalculator : ICalculator
    {
        private readonly INummericBaseConverter baseConverter;
        private OperatorType lastOperator;
        private Queue<long> operands;

        public MultiBaseCalculator(INummericBaseConverter baseConverter)
        {
            this.baseConverter = baseConverter;
            this.operands = new Queue<long>();
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

        public string Add(string number, int fromBase)
        {
            var addent = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(addent);

            if (this.operands.Count < 2)
            {
                this.lastOperator = OperatorType.Addition;
                return string.Empty;
            }
            else
            {
                this.Evaluate(this.LastOperator);
                this.lastOperator = OperatorType.Addition;
            }

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
        }

        public string Substract(string number, int fromBase)
        {
            var subtractor = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(subtractor);

            if (this.operands.Count < 2)
            {
                this.lastOperator = OperatorType.Subtraction;
                return string.Empty;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = OperatorType.Subtraction;
            }

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
        }

        public string Multiply(string number, int fromBase)
        {
            var multiplicator = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(multiplicator);

            if (this.operands.Count < 2)
            {
                this.lastOperator = OperatorType.Multiplication;
                return string.Empty;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = OperatorType.Multiplication;
            }

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
        }

        public string Divide(string number, int fromBase)
        {
            var divisor = this.baseConverter.ConvertToDecimal(number, fromBase);

            this.operands.Enqueue(divisor);

            if (this.operands.Count < 2)
            {
                this.lastOperator = OperatorType.Division;
                return string.Empty;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = OperatorType.Division;
            }

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
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

        public string Evaluate(string number, int fromBase)
        {
            var newOperand = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(newOperand);

            this.Evaluate(this.LastOperator);

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
        }

        public void ResetResult()
        {
            this.lastOperator = OperatorType.None;
            this.operands = new Queue<long>();
        }

        public void ChangeLastOperator(OperatorType operatorType)
        {
            if (this.operands.Count < 2)
            {
                this.lastOperator = operatorType;
            }
        }
    }
}
