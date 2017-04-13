using System;
using System.Collections.Generic;

namespace Verita.BooleanExpression
{
    public class Or:Expression
    {
        public Or():base()
        {
            _operation = '|';
        }

        public override bool Evaluate(Dictionary<string, bool> dict)
        {
            bool evaluation = false;
            int i = 0;

            while(!evaluation && i < subExpressions.Count)
            {
                bool eval = subExpressions[i].Evaluate(dict);
                evaluation = eval || evaluation;
            }

            return evaluation;
        }
    }
}