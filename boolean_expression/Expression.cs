using System;
using System.Collections.Generic;

namespace Verita.BooleanExpression
{
    public class Expression
    {
        // if this string is non-empty that means this expression is a singleton
        private string variable;
        // if this list is non-empty that means it is an equation
        protected List<Expression> subExpressions;

        // this creates a placeholder
        public Expression()
        {
            variable = string.Empty;
            subExpressions = null;
        }
        
        public void Add(Expression exp)
        {
            subExpressions.Add(exp);
        }

        public virtual bool Evaluate(Dictionary<string, bool> variables)
        {
            return variables[variable];
        }
    }
}