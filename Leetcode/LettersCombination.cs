using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal class LettersCombination
    {
        internal static IList<string> Execute(string digits)
        {
            var digitsToLettersDictionary = new Dictionary<char, IEnumerable<string>>{
                {'2', new List<string>{"a", "b", "c"}},
                {'3', new List<string>{"d", "e", "f"}},
                {'4', new List<string>{"g", "h", "i"}},
                {'5', new List<string>{"j", "k", "l"}},
                {'6', new List<string>{"m", "n", "o"}},
                {'7', new List<string>{"p", "q", "r", "s"}},
                {'8', new List<string>{"t", "u", "v"}},
                {'9', new List<string>{"w", "x", "y", "z"}}
            };

            return BuildCombinations(digits, digitsToLettersDictionary).ToList();
        }

        private static IEnumerable<string> BuildCombinations(string digits, Dictionary<char, IEnumerable<string>> digitsToLettersDictionary)
        {
            if (!digits.Any())
                return Enumerable.Empty<string>();

            var firstDigit = digits[0];

            var underlyingDigits = BuildCombinations(digits.Substring(1), digitsToLettersDictionary);

            if (digitsToLettersDictionary.ContainsKey(firstDigit))
            {
                return (from letter in digitsToLettersDictionary[firstDigit]
                        from underlyingDigit in underlyingDigits.DefaultIfEmpty()
                        select letter + underlyingDigit).ToList();
            }
            else
            {
                return underlyingDigits;
            }
        }
    }
}