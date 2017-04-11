using System;
using System.Text;
using System.Collections.Generic;
using Verita.BooleanExpression;

namespace Verita.Parser
{
    public static class ExpressionParser
    {
        // delimters are
        // & for and
        // ^ for xor
        // | for or
        private static char[] operators = {'(', ')', '|', '&', '^', ' '};
       
        public static Expression Parse(string exp)
        {
            // set up stacks
            Stack<char> opts = new Stack<char>();
            Stack<string> vars = new Stack<string>();
            Stack<Expression> expres = new Stack<Expression>();

            // getting the stacks to use
            string[] variables = GetVariableNames(exp);
            vars = GetVarStack(variables);

            char[] operations = GetOperators(exp);
            opts = GetOperatorStack(operations);

            expres.Push(null);

            // whlie we still have operations to use
            while(opts.Count > 0)
            {
                char opt = opts.Pop();

                if(opt != '(' && opt != ')')
                // opt is actually an operator
                // later on i will need to implement Not
                {
                }
                // opening a paren
                else if(opt != '(')
                {
                }
                // this will be for close paren
                else
                {
                }
            }

            return null;
        }

        // fuck this i can just use regex
        private static string[] GetVariableNames(string exp)
        {
            string[] tokens = exp.Split(operators, StringSplitOptions.RemoveEmptyEntries);
            return tokens;
        }

        private static Stack<string> GetVarStack(string[] vars)
        {
            Stack<string> stk = new Stack<string>();
            
            for(int i=vars.Length-1; i>-1; i--)
            {
                stk.Push(vars[i]);
            }

            return stk;
        }

        private static char[] GetOperators(string exp)
        {
            List<char> list = new List<char>();
            for(int i=0; i<exp.Length;i++)
            {
                char c = exp[i];
                if(IsOperator(c))
                {
                    list.Add(c);
                }
            }

            return list.ToArray();
        }

        private static Stack<char> GetOperatorStack(char[] opts)
        {
            Stack<char> stk = new Stack<char>();

            for(int i=opts.Length-1; i > -1; i--)
            {
                stk.Push(opts[i]);                
            }

            return stk;
        }
        
        // making sure the string is well formated
        public static bool Preprocess(string exp)
        {
            // checks for paren balances
            // and checks for operator consistency
            Stack<char> expressionTracker = new Stack<char>();

            int i  = 0;
            bool stackIsGood = true;

            while(i < exp.Length && stackIsGood)
            {
                char c = GetNextOperator(exp, ref i);
                if(c != '\0')
                {
                    stackIsGood = AddToStack(c, expressionTracker);
                }
            }

            // making sure the last item in the stack is not a paren
            if(expressionTracker.Count != 0)
            {
                stackIsGood = !(expressionTracker.Peek() == '(' || expressionTracker.Peek() == ')');
            } 

            // if the trackers goood but has more than 1 items left in the queue
            // that means not everything has been chekced 
            return stackIsGood && (expressionTracker.Count <= 1);
        }

        // returns false if something went wrong when adding the char to the stack
        private static bool AddToStack(char c, Stack<char> stack)
        {
            // assume that the char willl be added just fine
            bool charAdded = true;
            switch(c)
            {
                // just add this to the stack
                case '(':
                    stack.Push(c);
                    break;
                // check if there's only 1 operator in between or if
                // it's an open paren
                case ')':
                    bool done = false;
                    char d = '\0';

                    while(!done)
                    {
                        if(stack.Count != 0)
                        {
                            d = stack.Peek();
                        }
                        else
                        {
                            d = '\0';
                        }
                        // everything is all good and we can pop this off
                        if(d == '(')
                        {
                            stack.Pop();
                            done = true;
                            charAdded = true;
                        }
                        // unbalanced
                        else if( d == ')' || stack.Count == 0)
                        {
                            done = true;
                            charAdded = false;
                        }
                        // we can safely assume the item is an operator
                        // so we can just pop it now that this operatation is done
                        else
                        {
                            stack.Pop();
                        }
                    }
                    break;
                case '!':
                    charAdded = true;
                    break;
                // these fall through since the same thing must happen for them
                case '|':
                case '&':
                case '^':
                    char b = '\0';
                    if(stack.Count != 0)
                    {
                        b = stack.Peek();
                    }

                    if(b == c)
                    {
                       // don't add and just continue, but say that we added it just fine
                       charAdded = true; 
                    }
                    // stack is empty so we just add an operator
                    // or there is an open paren
                    else if(stack.Count == 0 || b == '(')
                    {
                        charAdded = true;
                        stack.Push(c);
                    }
                    // if the two are not achieved it means there is something wrong
                    else
                    {
                        charAdded = false;
                    }
                    break;
                default:
                    charAdded = false;
                    break;
            }

            return charAdded;
        }

        private static char GetNextOperator(string exp, ref int i)
        {
            bool optFound = false;
            char c = '\0';

            // looking for th next operator
            while(!optFound && i < exp.Length)
            {
                optFound = IsOperator(exp[i]);
                if(optFound)
                {
                    c = exp[i];
                }
                i++;
            }
            return c;
        }

        private static bool IsOperator(char c)
        {
            return c == '(' || c == ')' || c == '&' || c == '|' ||
                   c == '!' || c == '^';
        }
    }
}