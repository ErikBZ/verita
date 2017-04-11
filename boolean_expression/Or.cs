using System;

namespace Verita.BooleanExpression
{
    public class Or:Expression
    {
        public Or():base()
        {
            _operation = '|';
        }
    }
}