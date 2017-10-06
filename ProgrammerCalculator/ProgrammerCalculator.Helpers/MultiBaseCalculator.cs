using System;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;
using ProgrammerCalculator.Helpers;
using ProgrammerCalculator.Helpers.Constants;

namespace ProgrammerCalculator.Services
{
    public class MultiBaseCalculator : ExpressionManager, ICalculator
    {
        private readonly INummericBaseConverter baseConverter;

        public MultiBaseCalculator(INummericBaseConverter baseConverter)
            : base()
        {
            this.baseConverter = baseConverter;
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
                return GlobalConstants.ResetFieldCharacter;
            }

            var operand = this.baseConverter.BaseToDec(number, fromBase);

            this.operands.Enqueue(operand);

            if (this.operands.Count < 2)
            {
                this.operators.Enqueue(operatorType);
                this.isOperatorSelected = true;
                return GlobalConstants.ResetFieldCharacter;
            }
            else
            {
                this.EvaluateExpression(this.operators.Peek());
                this.SwitchOperators(operatorType);
                this.isOperatorSelected = true;
            }
            
            return this.baseConverter.DecToBase(this.CurrentResult, fromBase);
        }

        private void EvaluateExpression(OperatorType operatorType)
        {
            var firstOperand = this.operands.Dequeue();
            var secondOperand = this.operands.Dequeue();

            var result = this.mathOperation.Calculate(operatorType, firstOperand, secondOperand);

            this.operands.Enqueue(result);
        }

        public string Evaluate(string number, int fromBase)
        {
            if (this.isOperatorSelected)
            {
                return number;
            }

            var newOperand = this.baseConverter.BaseToDec(number, fromBase);
            this.operands.Enqueue(newOperand);

            this.EvaluateExpression(this.operators.Peek());

            return this.baseConverter.DecToBase(this.CurrentResult, fromBase);
        }

        private void SwitchOperators(OperatorType operatorType)
        {
            this.operators.Dequeue();
            this.operators.Enqueue(operatorType);
        }
    }
}
