using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class PlusOperator : IOperator<decimal>
    {
        public string Name =>nameof(PlusOperator);

        public decimal Calculate(decimal operand1, decimal operand2)
        {
            return operand1 + operand2;
        }
    }
}
