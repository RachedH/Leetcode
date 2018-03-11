using System;

namespace Leetcode
{
    internal class StrStr
    {
        internal static int Execute(string haystack, string needle)
        {
            if (needle == "")
                return 0;

            if (haystack == needle)
                return 0;
            
            if (haystack.Length < needle.Length)
                return -1;
            
            var index = 0;

            while(index < (haystack.Length - needle.Length) + 1 )
            {
                if(haystack[index] == needle[0])
                {
                    var index2 = 0;
                    bool matches = true;
                    while(index2 < needle.Length && matches)
                    {
                        if (haystack[index + index2] != needle[index2])
                            matches = false;

                        ++index2;
                    }

                    if (matches)
                        return index;
                }

                ++index;
            }

            return -1;
        }
    }
}