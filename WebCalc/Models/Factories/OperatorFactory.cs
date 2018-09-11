using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class OperatorFactory : IOperatorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public OperatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IOperator<decimal> Build(string sign)
        {
            var operatorList = _serviceProvider.GetServices<IOperator<decimal>>();
            var topSignDetails = Constants.Operators.Single(o => o.Sign.Equals(sign));
            var currentOperator = operatorList.Single(o => o.Name.Equals($"{ topSignDetails.Description }Operator"));
            return currentOperator;
        }
    }
}
