using System;

namespace Leetcode
{
    internal class RemoveElement
    {
        internal static int Execute(int[] nums, int val)
        {
            var currentCleanedIndex = 0;
            var currentIndex = 0;

            while(currentIndex < nums.Length)
            {
                if(nums[currentIndex] == val)
                {
                    while(currentIndex < nums.Length && nums[currentIndex] == val)
                    {
                        ++currentIndex;
                    }

                    if(currentIndex < nums.Length)
                    {
                        for (int counter = 0; currentCleanedIndex + counter < nums.Length; ++counter)
                        {
                            nums[currentCleanedIndex + counter] = currentIndex + counter < nums.Length ? nums[currentIndex + counter] : val;
                        }

                        ++currentCleanedIndex;
                        currentIndex = currentCleanedIndex;
                    }


                }
                else
                {
                    ++currentIndex;
                    ++currentCleanedIndex;
                }
            }

            return currentCleanedIndex;
        }
    }
}