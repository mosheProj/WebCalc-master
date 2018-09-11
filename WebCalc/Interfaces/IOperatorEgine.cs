using System.Collections;
using System.Collections.Generic;

namespace WebCalc.Interfaces
{
    public interface IOperatorEgine
    {
        decimal Execute(Stack<decimal> operandsStack, Stack<string> operatorsStack);
        decimal Finalize(Stack<decimal> operandsStack, Stack<string> operatorsStack);

    }
}
