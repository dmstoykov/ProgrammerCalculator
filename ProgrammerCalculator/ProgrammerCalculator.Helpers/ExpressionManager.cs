using System;
using System.Linq;
using System.Collections.Generic;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Enumerations;

namespace ProgrammerCalculator.Helpers
{
    public abstract class ExpressionManager : IExpressionManager
    {
        protected Queue<OperatorType> operators;
        protected Queue<long> operands;
        protected IMathOperation mathOperation;

        protected bool isOperatorSelected;

        public ExpressionManager()
        {
            this.operands = new Queue<long>();
            this.operators = new Queue<OperatorType>();
            this.mathOperation = this.RegisterMathOperations();
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

        public void ResetResult()
        {
            this.operators = new Queue<OperatorType>();
            this.operands = new Queue<long>();
        }

        private IMathOperation RegisterMathOperations()
        {
            var mathOperationType = typeof(IMathOperation);

            var mathOperations = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => mathOperationType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select(x => Activator.CreateInstance(x))
            .ToList();

            for (int i = 0; i < mathOperations.Count - 1; i++)
            {
                var currentOperation = mathOperations[i] as IMathOperation;
                var nextOperation = mathOperations[i + 1] as IMathOperation;

                currentOperation.SetNextOperation(nextOperation);
            }

            return mathOperations[0] as IMathOperation;
        }
    }
}
