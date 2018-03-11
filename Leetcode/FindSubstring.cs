using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal static class FindSubstring
    {
        internal static IList<int> Execute(string s, string[] words)
        {
            if (!words.Any())
                return Enumerable.Empty<int>().ToList();

            if (s.Length == 0)
                return Enumerable.Empty<int>().ToList();

            if(s.Length < words[0].Length * words.Length)
                return Enumerable.Empty<int>().ToList();

            var charLookup = words.Select(x => x[0]).ToHashSet();

            var cursor = 0;
            var startingIndexes = new List<int>();

            while(cursor < s.Length - (words[0].Length * words.Length) + 1)
            {
                if(charLookup.Contains(s[cursor]))
                {
                    var startIndex = cursor;
                    var hasFoundWord = false;
                    var wordsLookup = words.GroupBy(x => x[0]).ToDictionary(x => x.Key, x => x.ToList());
                    var nbFoundWords = 0;

                    do
                    {
                        if (!wordsLookup.ContainsKey(s[cursor]))
                            break;

                        if (cursor + words[0].Length > s.Length)
                            break;
                        
                        var foundWord = wordsLookup[s[cursor]].Where(x => x == s.Substring(cursor, words[0].Length)).Select(x => x);
                        hasFoundWord = foundWord.Any();
                        if (hasFoundWord)
                        {
                            wordsLookup[s[cursor]].Remove(foundWord.First());
                            nbFoundWords++;
                        }
                            
                        cursor += words[0].Length;
                    }
                    while (hasFoundWord && nbFoundWords < words.Length && cursor < s.Length);

                    if (nbFoundWords == words.Length)
                        startingIndexes.Add(startIndex);

                    cursor = startIndex + 1;
                }
                else
                {
                    ++cursor;
                }
            }

            return startingIndexes;
        }
    }
}