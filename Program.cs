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

            //CheckToString();
        }

        // looks like two string works!
        public static void CheckToString()
        {
            Expression x = new Expression("x");
            Expression y = new Expression("y");
            Expression z = new Expression("z");

            And a = new And();
            a.Add(x);
            a.Add(y);

            Or o = new Or();
            o.Add(a);
            o.Add(z);

            Console.WriteLine(o.ToString());
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
                    Expression e = ExpressionParser.Parse(input);
                    Console.WriteLine("This is how i parsed it: " +  e.ToString());
                }
                else
                {
                    Console.WriteLine("This is not formatted correctly.");
                }
            }
        }
    }
}
