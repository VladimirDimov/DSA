namespace Permutations
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the length of the sequence to permute:");
            var n = int.Parse(Console.ReadLine());

            var result = new List<List<int>>();
            Permute(n, new List<int>(), new HashSet<int>(), result);

            PrintCollection(result);
        }

        private static void Permute(int n, List<int> permutation, HashSet<int> passed, List<List<int>> result)
        {
            if (permutation.Count == n)
            {
                result.Add(permutation);
            }

            for (int i = 1; i < n + 1; i++)
            {
                if (!passed.Contains(i))
                {
                    var currentPermutation = new List<int>(permutation);
                    var currentPassed = new HashSet<int>(passed);
                    currentPermutation.Add(i);
                    currentPassed.Add(i);
                    Permute(n, currentPermutation, currentPassed, result);
                }
            }
        }

        private static void PrintCollection(List<List<int>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
