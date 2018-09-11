using System.Collections.Generic;
using System.Linq;
using WebCalc.ExtensionMethods;
using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class OperatorEgine : IOperatorEgine
    {
        private readonly IOperatorFactory _operatorFactory;
        public OperatorEgine(IOperatorFactory operatorFactory)
        {
            _operatorFactory = operatorFactory;
        }
        public decimal Execute(Stack<decimal> operandsStack, Stack<string> operatorsStack)
        {
            var operand2 = operandsStack.Pop();
            var operand1 = operandsStack.Pop();
            var sign = operatorsStack.Pop();
            var currentOperator = _operatorFactory.Build(sign);
            return currentOperator.Calculate(operand1, operand2);
        }

        public decimal Finalize(Stack<decimal> operandsStack, Stack<string> operatorsStack)
        {
            while (!operatorsStack.IsEmpty())
            {
                var result = Execute(operandsStack, operatorsStack);
                operandsStack.Push(result);
            }
            return operandsStack.Pop();
        }
    }
}
