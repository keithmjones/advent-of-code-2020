using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Expression
    {
        Expression lhs;
        Expression rhs;
        string node;

        public Expression(string source)
        {
            Console.WriteLine("Expression: {0}", source);
            if (source == "")
            {
                throw new Exception("Empty expression");
            }

            int startRhs = source.Length;
            if (source[source.Length - 1] == ')')
            {
                startRhs = FindOpenParenthesis(source);
                while (startRhs == 0)
                {
                    source = source.Substring(1, source.Length - 2);
                    startRhs = source[source.Length - 1] == ')' ? FindOpenParenthesis(source) : source.Length;
                }
            }
            if (startRhs == source.Length)
            {
                startRhs = source.LastIndexOf(' ') + 1;
            }
            Console.WriteLine("startRhs={0}", startRhs);
            var space = source.LastIndexOf(' ', 0, startRhs);
            Console.WriteLine("startRhs={0} space={1}", space);
            if (space < 0)
            {
                node = source;
                lhs = null;
                rhs = null;
            }
            else
            {
                lhs = new Expression(source.Substring(0, space - 2));
                node = source[space - 1].ToString();
                rhs = new Expression(source.Substring(space + 1));
            }
        }

        private int FindOpenParenthesis(string source)
        {
            int openingParentheses = 0;
            int closingParentheses = 0;
            int openParenthesis = source.Length - 1;
            do {
                openingParentheses++;
                openParenthesis = source.LastIndexOf('(', openParenthesis);
                if (openParenthesis < 0)
                {
                    throw new Exception("Unmatched )");
                }
                closingParentheses = source.Substring(openParenthesis).Where(chr => chr == ')').Count();
            } while (openingParentheses != closingParentheses);
            return openParenthesis;
        }

        public Int64 Evaluate()
        {
            Int64 number = 0;
            if (Int64.TryParse(node, out number))
            {
                return number;
            }
            else if (node == "+")
            {
                return lhs.Evaluate() + rhs.Evaluate();
            }
            else if (node == "*")
            {
                return lhs.Evaluate() * rhs.Evaluate();
            }
            else
            {
                throw new Exception(String.Format("Unknown operator: {0}", node));
            }
        }

        override public string ToString() => String.Format("{0} <- {1} -> {2}", lhs.ToString(), node, rhs.ToString());
   }
}
