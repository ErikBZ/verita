using System;
using System.Text;

namespace Verita.BooleanExpression
{
    public class And:Expression
    {
        public And():base()
        {
            _operation = '&';
        }
    } 
}