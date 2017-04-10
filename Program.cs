using System;
using Verita.BooleanExpression;
using Verita.Parser;

namespace Verita
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // doing some testing
            string input = string.Empty;
            while(input != "quit")
            {
                input = Console.ReadLine();
                bool stringGood = ExpressionParser.Preprocess(input);
                Console.WriteLine(stringGood);
            }
        }
    }
}
