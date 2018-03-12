using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public static class LongestValidParentheses
    {
        public static int Execute(string s)
        {
            var parenthesesStack = new Stack<int>();
            var parenthesesBlocksStack = new Stack<Tuple<int, int>>();
            var maxLength = 0;
            
            for(int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                {
                    parenthesesStack.Push(i);
                }
                else if (s[i] == ')' && parenthesesStack.Any())
                {
                    var head = parenthesesStack.Pop();
                    var tail = i;
                    
                    if (!parenthesesBlocksStack.Any())
                    {
                        parenthesesBlocksStack.Push(new Tuple<int, int>(head, tail));
                        maxLength = Math.Max(maxLength, tail - head + 1);
                    }
                    else
                    {
                        var lastElem = parenthesesBlocksStack.Pop();
                        if(head < lastElem.Item1 && tail > lastElem.Item2)
                        {
                            parenthesesBlocksStack.Push(new Tuple<int, int>(head, tail));
                            maxLength = Math.Max(maxLength, tail - head + 1);
                        }
                        else
                        {
                            parenthesesBlocksStack.Push(lastElem);
                            parenthesesBlocksStack.Push(new Tuple<int, int>(head, tail));
                            maxLength = Math.Max(maxLength, tail - head + 1);
                        }

                        if (parenthesesBlocksStack.Count > 1)
                        {
                            var frontElem = parenthesesBlocksStack.Pop();
                            var frontFrontElem = parenthesesBlocksStack.Pop();
                            
                            if (frontFrontElem.Item2 == frontElem.Item1 - 1)
                            {
                                parenthesesBlocksStack.Push(new Tuple<int, int>(frontFrontElem.Item1, frontElem.Item2));
                                maxLength = Math.Max(maxLength, frontElem.Item2 - frontFrontElem.Item1 + 1);
                            }
                            else
                            {
                                parenthesesBlocksStack.Push(frontFrontElem);
                                parenthesesBlocksStack.Push(frontElem);
                            }
                        }
                    }
                }
            }

            return maxLength;
        }
    }
}