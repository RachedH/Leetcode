using System;

namespace Leetcode
{
    internal class RemoveDuplicates
    {
        internal static int Execute(int[] nums)
        {
            var currentNonDuplicateIndex = 0;
            var currentIndex = 0;
            int? lastValue = null;

            while(currentIndex < nums.Length)
            {
                if(lastValue.HasValue && nums[currentIndex] == lastValue)
                {
                    while (currentIndex < nums.Length && nums[currentIndex] == lastValue)
                    {
                        currentIndex++;
                    }

                    if(currentIndex < nums.Length)
                    {
                        nums[currentNonDuplicateIndex] = nums[currentIndex];
                        lastValue = nums[currentNonDuplicateIndex];
                        currentNonDuplicateIndex++;
                    }
                }
                else
                {
                    lastValue = nums[currentNonDuplicateIndex];
                    currentIndex++;
                    currentNonDuplicateIndex++;
                }
            }

            return currentNonDuplicateIndex;
        }
    }
}