using System.Collections.Generic;

namespace WebCalc
{
    public static class Constants
    {
        // Usually we get this data from DB that way the code is Expandable
        public static List<OperatorDetails> Operators = new List<OperatorDetails>{
            new OperatorDetails{ Sign ="+", Precedence=1 , Description="Plus" },
            new OperatorDetails{ Sign ="-", Precedence=1 , Description="Minus" },
            new OperatorDetails{ Sign ="*", Precedence=2 , Description="Multiple" },
            new OperatorDetails{ Sign ="/", Precedence=2 , Description="Divide" },
        };
    }
    public  class OperatorDetails
    {
        public string Sign { get; set; }
        public int Precedence { get; set; }
        public string Description { get; set; }
    }
}
