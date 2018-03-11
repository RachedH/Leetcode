namespace Leetcode
{
    internal static class NextPermutation
    {
        public static void Execute(int[] nums)
        {
            if (nums.Length == 0)
                return;
            
            var head = 0;
            var tail = head + 1;
            var swapPosition = -1;
            var swapTargetPosition = -1;

            while (tail < nums.Length)
            {
                if (nums[head] < nums[tail])
                {
                    swapPosition = head;
                    swapTargetPosition = tail;
                }

                if (swapPosition != -1 && nums[tail] < nums[swapTargetPosition] && nums[tail] > nums[swapPosition])
                    swapTargetPosition = tail;

                ++head;
                ++tail;
            }

            if (swapPosition != -1)
            {
                var backup = nums[swapPosition];
                nums[swapPosition] = nums[swapTargetPosition];
                nums[swapTargetPosition] = backup;
                
                bool lexicographicallyOrdered = false;

                while (!lexicographicallyOrdered)
                {
                    lexicographicallyOrdered = true;
                    head = swapPosition + 1;
                    tail = swapPosition + 2;
                    
                    while (tail < nums.Length)
                    {
                        if (nums[head] > nums[tail])
                        {
                            backup = nums[head];
                            nums[head] = nums[tail];
                            nums[tail] = backup;
                            lexicographicallyOrdered = false;
                        }

                        ++head;
                        ++tail;
                    }
                }
            }
            else
            {
                head = 0;
                tail = nums.Length - 1;
                while (head < tail)
                {
                    var backup = nums[head];
                    nums[head] = nums[tail];
                    nums[tail] = backup;
                    ++head;
                    --tail;
                }
            }
        }
    }
}