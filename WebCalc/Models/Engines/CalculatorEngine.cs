using System.Collections.Generic;
using System.Linq;
using WebCalc.ExtensionMethods;
using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class CalculatorEngine : ICalculatorEngine<decimal>
    {
        private readonly IOperatorEgine _engine;

        Stack<string> _operatorsStack = new Stack<string>();
        Stack<decimal> _operandsStack = new Stack<decimal>();

        public CalculatorEngine(IOperatorEgine engine)
        {
            _engine = engine;
        }
        public decimal Calculate(List<string> formedExpression)
        {
            foreach (var currentSign in formedExpression)
            {
                if (!currentSign.IsOperator())
                    _operandsStack.Push(currentSign.ToDecimal());
                else
                {
                    if (!_operatorsStack.IsEmpty())
                    {
                        var topSign = _operatorsStack.Peek();
                        if (topSign.IsSuperior(currentSign))
                        {
                            var result = _engine.Execute(_operandsStack, _operatorsStack);
                            _operandsStack.Push(result);
                            _operatorsStack.Push(currentSign);
                        }
                        else
                            _operatorsStack.Push(currentSign);
                    }
                    else
                        _operatorsStack.Push(currentSign);
                }
            }
            return _engine.Finalize(_operandsStack, _operatorsStack);
        }
    }
}
