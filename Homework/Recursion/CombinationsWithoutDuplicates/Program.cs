namespace CombinationsWithDuplicates
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the length of the sequence.");
            var n = int.Parse(Console.ReadLine());
            var combinations = new List<List<int>>();
            GenerateAllCombinationsWithDuplicates(n, 1, new List<int>(), combinations);

            PrintCollection(combinations);
        }

        private static void GenerateAllCombinationsWithDuplicates(int n, int left, List<int> combination, List<List<int>> result)
        {
            if (combination.Count == n)
            {
                result.Add(combination);
                return;
            }

            for (int i = left; i < n + 1; i++)
            {
                var currentCombination = new List<int>(combination);
                currentCombination.Add(i);
                GenerateAllCombinationsWithDuplicates(n, i, currentCombination, result);
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
