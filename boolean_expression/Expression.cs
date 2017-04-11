using System;
using System.Text;
using System.Collections.Generic;

namespace Verita.BooleanExpression
{
    public class Expression
    {
        // if this string is non-empty that means this expression is a singleton
        private string variable;
        // if this list is non-empty that means it is an equation
        protected List<Expression> subExpressions;
        protected char _operation;
        public bool Singleton;

        // this creates a placeholder
        public Expression()
        {
            variable = string.Empty;
            subExpressions = new List<Expression>();
            Singleton = false;
        }

        public Expression(string exp)
        {
            variable = exp;
            subExpressions = null;
            Singleton = true;
        }
        
        public void Add(Expression exp)
        {
            subExpressions.Add(exp);
        }

        public void Add(string exp)
        {
            this.Add(new Expression(exp));
        }

        public virtual bool Evaluate(Dictionary<string, bool> variables)
        {
            return variables[variable];
        }

        // an uninherited expression should never be the highest level expression
        public override string ToString()
        {
            // if this is a singleton
            if(this.Singleton)
            {
                return this.variable;
            }

            StringBuilder sb = new StringBuilder();

            for(int i=0; i<subExpressions.Count;i++)
            {
                Expression e = subExpressions[i];

                if(e.Singleton)
                {
                    sb.Append(e.ToString());
                }
                else
                {
                    sb.Append('(');
                    sb.Append(e.ToString());
                    sb.Append(')');
                }

                if(i != subExpressions.Count - 1)
                {
                    sb.Append(_operation);
                }
            }

            return sb.ToString();
        }
    }
}