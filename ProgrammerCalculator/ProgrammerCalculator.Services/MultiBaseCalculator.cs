using System;
using ProgrammerCalculator.Services.Infrastructure.Contracts;
using ProgrammerCalculator.Services.Infrastructure.Enumerations;
using System.Collections.Generic;

namespace ProgrammerCalculator.Services
{
    public class MultiBaseCalculator : ICalculator
    {
        private const string ResetFieldCharacter = "";

        private readonly INummericBaseConverter baseConverter;

        private Queue<OperatorType> operators;
        private Queue<long> operands;

        private bool isOperatorSelected;

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

        public bool IsOperatorSelected
        {
            get
            {
                return this.isOperatorSelected;
            }
            set
            {
                this.isOperatorSelected = value;
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
            if (this.isOperatorSelected)
            {
                this.SwitchOperators(operatorType);
                return ResetFieldCharacter;
            }

            var operand = this.baseConverter.ConvertToDecimal(number, fromBase);

            this.operands.Enqueue(operand);

            if (this.operands.Count < 2)
            {
                this.operators.Enqueue(operatorType);
                this.isOperatorSelected = true;
                return ResetFieldCharacter;
            }
            else
            {
                this.Evaluate(this.operators.Peek());
                this.SwitchOperators(operatorType);
                this.isOperatorSelected = true;
            }

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
        }

        private void Evaluate(OperatorType operatorType)
        {
            var firstOperand = this.operands.Dequeue();
            var secondOperand = this.operands.Dequeue();

            switch (this.operators.Peek())
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
            if (this.isOperatorSelected)
            {
                return number;
            }

            var newOperand = this.baseConverter.ConvertToDecimal(number, fromBase);
            this.operands.Enqueue(newOperand);

            this.Evaluate(this.operators.Peek());

            return this.baseConverter.ConvertFromDecimal(this.CurrentResult, fromBase);
        }

        private void SwitchOperators(OperatorType operatorType)
        {
            this.operators.Dequeue();
            this.operators.Enqueue(operatorType);
        }

        public void ResetResult()
        {
            this.operators = new Queue<OperatorType>();
            this.operands = new Queue<long>();
        }
    }
}
