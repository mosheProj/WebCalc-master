using WebCalc.Interfaces;
using WebCalc.Models;

namespace WebCalc.Services
{
    public class DecimalCalculateService : ICalculateService
    {
        private readonly ICalculatotManager<decimal> _manager;
        public DecimalCalculateService(ICalculatotManager<decimal> manager)
        {
            _manager = manager;
        }
        public CalculationResponse Evaluate(CalculationRequest request)
        {
            return new CalculationResponse { Result = _manager.Manage(request.Expression) };
        }
    }
}
