using System;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var longestValidParentheses = LongestValidParentheses.Execute("()(())");
        
            Console.WriteLine(longestValidParentheses);
        }
    }
}
