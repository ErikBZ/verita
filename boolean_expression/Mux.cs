using System;
using System.Collections.Generic;

namespace Verita.BooleanExpression
{
    // Mux is a better way to describe what this operation does
    public class Mux:Expression
    {
        public Mux():base()
        {
            _operation='^';
        }

        // only 1 thing of this all can be true
        public override bool Evaluate(Dictionary<string, bool> dict)
        {
            bool evaluation = false;
            int i = 0;
            while(i < subExpressions.Count)
            {
                bool subExpEval = subExpressions[i].Evaluate(dict);

                // break the flow and just return false
                if(!subExpEval && evaluation)
                {
                    return false;
                }
                else if(subExpEval && !evaluation)
                {
                    evaluation = true;
                }
                // if they're both false then just keep going
                i++;
            }
            return evaluation;
        }
    } 
}