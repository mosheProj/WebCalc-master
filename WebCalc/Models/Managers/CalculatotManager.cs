using System;
using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class CalculatotManager : ICalculatotManager<decimal>
    {
        private readonly ICacheManager _cacheManager;
        private readonly IExpressionFormater _formater;
        private readonly ICalculatorEngine<decimal> _calculatorEngine;
        private readonly IExpressionValidation _validator;
        public CalculatotManager(ICacheManager cacheManager,
                                 IExpressionValidation validator,
                                 IExpressionFormater formater,
                                 ICalculatorEngine<decimal> calculatorEngine)
        {
            _cacheManager = cacheManager;
            _validator = validator;
            _formater = formater;
            _calculatorEngine = calculatorEngine;
        }
        public decimal Manage(string expression)
        {
            
            if (_cacheManager.Exist(expression)) return _cacheManager.Get(expression);

            if (!_validator.Validate(expression)) throw new InvalidOperationException("Expression is invalid");

            var formedExpression = _formater.Format(expression);

            var result = _calculatorEngine.Calculate(formedExpression);

            _cacheManager.Insert(expression, result);

            return result;
        }
    }
}
