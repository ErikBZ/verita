using System;
using System.Collections.Generic;
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
            Dictionary<string, bool> mapping = new Dictionary<string, bool>();
            string input = string.Empty;
            string[] vars = new string[0];

            while(input != "quit")
            {
                input = Console.ReadLine();
                bool stringGood = ExpressionParser.Preprocess(input);
                if(stringGood)
                {
                    Expression e = ExpressionParser.Parse(input, out vars);
                    Console.WriteLine("This is how i parsed it: " +  e.ToString());
                    mapping = AskForVariableValues(vars);
                    PrintDict(mapping);
                }
                else
                {
                    Console.WriteLine("This is not formatted correctly.");
                }

                mapping.Clear();
            }
        }

        private static Dictionary<string, bool> AskForVariableValues(string[] vars)
        {
            Dictionary<string, bool> mapping = new Dictionary<string, bool>();
            
            foreach(string key in vars)
            {
                Console.Write("Value for " + key + ":");
                string input = Console.ReadLine();
                int num = 0;
                if(int.TryParse(input, out num) && num==1)
                {
                    mapping.Add(key, true);
                }
                else
                {
                    mapping.Add(key, false);
                }

                Console.WriteLine(input);
            } 

            return mapping;
        }

        private static void PrintDict(Dictionary<string, bool> dict)
        {
            foreach(KeyValuePair<string, bool> kvp in dict)
            {
                Console.Write(kvp.Key + " is set to " + kvp.Value);
                Console.WriteLine();
            }
        }
    }
}
