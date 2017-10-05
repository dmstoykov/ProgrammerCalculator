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

        private Queue<OperatorType> operators;
        private Queue<long> operands;

        public MultiBaseCalculator(INummericBaseConverter baseConverter)
        {
            this.baseConverter = baseConverter;
            this.operands = new Queue<long>();
            this.operators = new Queue<OperatorType>();
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
            var result = PerformOperationWithType(OperatorType.Addition, number, fromBase);
            return result;
        }

        public string Substract(string number, int fromBase)
        {
            var result = PerformOperationWithType(OperatorType.Subtraction, number, fromBase);
            return result;
        }

        public string Multiply(string number, int fromBase)
        {
            var result = PerformOperationWithType(OperatorType.Multiplication, number, fromBase);
            return result;
        }

        public string Divide(string number, int fromBase)
        {
            var result = PerformOperationWithType(OperatorType.Division, number, fromBase);
            return result;
        }

        private string PerformOperationWithType(OperatorType operatorType, string number, int fromBase)
        {
            var operand = this.baseConverter.ConvertToDecimal(number, fromBase);

            this.operands.Enqueue(operand);

            if (this.operands.Count < 2)
            {
                this.lastOperator = operatorType;
                return string.Empty;
            }
            else
            {
                this.Evaluate(this.lastOperator);
                this.lastOperator = operatorType;
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
