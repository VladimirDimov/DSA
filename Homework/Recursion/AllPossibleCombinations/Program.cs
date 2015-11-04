namespace Recursion
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var combinations = new List<List<int>>();
            GetAllCombinations(n, new List<int>(), combinations);

            PrintCollection(combinations);
        }

        private static void GetAllCombinations(int n, List<int> combination, List<List<int>> result)
        {
            if (combination.Count == n)
            {
                result.Add(combination);
                return;
            }

            for (int i = 1; i < n + 1; i++)
            {
                var currentCombination = new List<int>(combination);
                currentCombination.Add(i);
                GetAllCombinations(n, currentCombination, result);
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
