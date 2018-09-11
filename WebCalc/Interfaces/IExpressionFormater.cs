using System.Collections.Generic;

namespace WebCalc.Interfaces
{
    public interface IExpressionFormater
    {
        List<string> Format(string expression);
    }
}
