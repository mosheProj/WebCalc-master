using System.Collections.Generic;

namespace WebCalc.Interfaces
{
    public interface ICalculatorEngine<T>
    {
        T Calculate(List<string> formedExpression);
    }
}
