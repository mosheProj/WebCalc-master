using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class DivideOperator : IOperator<decimal> 
    {
        public string Name => nameof(DivideOperator);
        
      
        public decimal Calculate(decimal operand1, decimal operand2)
        {
            return operand1 / operand2;
        }
    }
}
