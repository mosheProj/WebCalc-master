using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class MinusOperator : IOperator<decimal>
    {
        public string Name => nameof(MinusOperator);

        public decimal Calculate(decimal operand1, decimal operand2)
        {
            return operand1 - operand2;
        }
    }
}
