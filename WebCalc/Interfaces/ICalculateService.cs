using WebCalc.Models;

namespace WebCalc.Interfaces
{
    public interface ICalculateService
    {
        CalculationResponse Evaluate(CalculationRequest request);
    }
}
