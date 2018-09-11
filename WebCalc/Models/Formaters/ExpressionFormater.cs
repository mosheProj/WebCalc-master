using System;
using System.Collections.Generic;
using System.Linq;
using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class ExpressionFormater : IExpressionFormater
    {
        public List<string> Format(string expression)
        {
            var operatorSigns = Constants.Operators.Select(o=>o.Sign).ToArray();
            var operands = expression.Split(operatorSigns, StringSplitOptions.RemoveEmptyEntries);
            var operators = expression.Split(operands, StringSplitOptions.RemoveEmptyEntries);

            List<string> unionList = new List<string>();
            // in case the expression is valid
            //operands list will alway contain one item more then operator list
            for (int i = 0; i < operands.Length; i++)
            {
                unionList.Add(operands[i]);
                if (i < operands.Length - 1)
                    unionList.Add(operators[i]);
            }

            return unionList;
        }
    }
}
