using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal class FourSum
    {
        internal static IList<IList<int>> Execute(int[] nums, int target)
        {
            var sortedInputs = nums.OrderBy(x => x).ToList();

            var result = new List<IList<int>>();
            var firstStart = 0;
            var secondStart = 0;

            while (firstStart < sortedInputs.Count() - 2)
            {
                secondStart = firstStart + 1;
                while(secondStart < sortedInputs.Count() - 1)
                {
                    var head = secondStart + 1;
                    var tail = sortedInputs.Count() - 1;

                    while(head < tail)
                    {
                        var sum = sortedInputs[firstStart] + sortedInputs[secondStart] + sortedInputs[head] + sortedInputs[tail];

                        if (sum == target)
                        {
                            result.Add(new[] { sortedInputs[firstStart], sortedInputs[secondStart], sortedInputs[head], sortedInputs[tail] });
                            var previousHeadValue = sortedInputs[head];
                            while(previousHeadValue == sortedInputs[head] && head < tail)
                            {
                                head++;
                            }

                            var previousTailValue = sortedInputs[tail];
                            while(previousTailValue == sortedInputs[tail] && head < tail)
                            {
                                tail--;
                            }
                        }
                        else if(sum < target)
                        {
                            var previousHeadValue = sortedInputs[head];
                            while (previousHeadValue == sortedInputs[head] && head < tail)
                            {
                                head++;
                            }
                        }
                        else
                        {
                            var previousTailValue = sortedInputs[tail];
                            while (previousTailValue == sortedInputs[tail] && head > tail)
                            {
                                tail--;
                            }
                        }
                    }

                    var previousSecondStartValue = sortedInputs[secondStart];
                    while (previousSecondStartValue == sortedInputs[secondStart] && secondStart < head)
                    {
                        secondStart++;
                    }
                }

                var previousFirstStartValue = sortedInputs[firstStart];
                while (previousFirstStartValue == sortedInputs[firstStart] && firstStart < secondStart)
                {
                    firstStart++;
                }
            }

            return result;
        }
    }
}