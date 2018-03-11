using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal class GenerateParenthesis
    {
        internal static IList<string> Execute(int n)
        {
            var returnValue = new List<string>();

            BuildParenthesis(returnValue, "", n, n);

            return returnValue;
        }

        private static void BuildParenthesis(List<string> list, string currentValue, int toOpen, int toClose)
        {
            if(toOpen == 0)
            {
                list.Add(currentValue + new string(Enumerable.Repeat<char>(')', toClose).ToArray()));
            }
            else
            {
                BuildParenthesis(list, currentValue + "(", toOpen - 1, toClose);
                if(toOpen < toClose)
                    BuildParenthesis(list, currentValue + ")", toOpen, toClose - 1);
            }
        }
    }
}