using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class MultipleOperator : IOperator<decimal>
    {
        public string Name => nameof(MultipleOperator);

        public decimal Calculate(decimal operand1, decimal operand2)
        {
            return operand1 * operand2;
        }
    }
}
