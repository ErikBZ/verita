using System;
using Verita.BooleanExpression;
using Verita.Parser;

namespace Verita
{
    public class Program
    {
        private static char[] operators = {'(', ')', '|', '&', '^'};
        public static void Main(string[] args)
        {
            RunProg();
        }

        public static void RunProg()
        {
            // doing some testing
            string input = string.Empty;
            while(input != "quit")
            {
                input = Console.ReadLine();
                bool stringGood = ExpressionParser.Preprocess(input);
                if(stringGood)
                {
                    ExpressionParser.Parse(input);
                }
                else
                {
                    Console.WriteLine("This is not formatted correctly.");
                }
            }
        }
    }
}
