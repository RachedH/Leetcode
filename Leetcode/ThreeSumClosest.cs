using System;
using System.Linq;

namespace Leetcode
{
    internal class ThreeSumClosest
    {
        internal static int Execute(int[] nums, int target)
        {
            if (nums.Length < 3)
                return 0;
            
            var sortedInputs = nums.OrderBy(x => x).ToList();

            int? closestResult = null;

            for (int i = 0; i < sortedInputs.Count - 2; ++i)
            {
                var firstElement = sortedInputs[i];
                var headIndex = i + 1;
                var tailIndex = sortedInputs.Count - 1;
                var head = sortedInputs[headIndex];
                var tail = sortedInputs[tailIndex];

                var result = 0;

                do
                {
                    result = firstElement + head + tail;

                    if (closestResult == null ||
                       Math.Abs(target - result) < Math.Abs(target - closestResult.Value))
                    {
                        closestResult = result;
                    }

                    if (result > target)
                    {
                        var previousTail = tail;
                        while (tail == previousTail && headIndex < tailIndex)
                        {
                            tailIndex--;
                            tail = sortedInputs[tailIndex];
                        }
                    }

                    if (result < target)
                    {
                        var previousHead = head;
                        while (head == previousHead && headIndex < tailIndex)
                        {
                            headIndex++;
                            head = sortedInputs[headIndex];
                        }
                    }
                }
                while (headIndex < tailIndex && result != target);

                if (result == target)
                    break;
            }

            return closestResult.HasValue ? closestResult.Value : 0;
        }
    }
}