using System;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var originalPermutation = new[] {2, 3, 1};
            
            NextPermutation.Execute(originalPermutation);
        
            foreach (var entry in originalPermutation)
                Console.WriteLine(entry);
        }
    }
}
