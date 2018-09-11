using System;
using System.Linq;

namespace WebCalc.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static decimal ToDecimal(this string str) => Convert.ToDecimal(str);

        public static bool IsOperator(this string str) => Constants.Operators.Any(o => o.Sign == str);

        public static bool IsSuperior(this string newSign, string topSign)
        {
            if (!topSign.IsOperator() || !newSign.IsOperator()) throw new InvalidOperationException("Input String is not a recognized Operator");

            var newPrecedence = Constants.Operators.Single(o => o.Sign == newSign).Precedence;
            var topPrecedence = Constants.Operators.Single(o => o.Sign == topSign).Precedence;

            return newPrecedence > topPrecedence;

        }

    }
}
