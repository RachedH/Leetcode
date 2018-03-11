using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal class ValidParenthesis
    {
        internal static bool Execute(string s)
        {
            var openenedParenthesis = new Stack<char>();

            foreach(var character in s)
            {
                if(character == '(' ||
                   character == '{' ||
                   character == '[')
                {
                    openenedParenthesis.Push(character);
                }

                if(character == ')' ||
                  character == ']' ||
                   character == '}')
                {
                    if (!openenedParenthesis.Any())
                        return false;
                    
                    var lastOpenedParenthesis = openenedParenthesis.Pop();

                    if (lastOpenedParenthesis == '(' && character != ')')
                        return false;

                    if (lastOpenedParenthesis == '{' && character != '}')
                        return false;

                    if (lastOpenedParenthesis == '[' && character != ']')
                        return false;
                }
            }

            return !openenedParenthesis.Any();
        }
    }
}