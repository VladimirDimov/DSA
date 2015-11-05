using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Combinations
    {
        public static void GetAllPossibleCombinations(int n, List<int> combination, List<List<int>> result)
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
                GetAllPossibleCombinations(n, currentCombination, result);
            }
        }

        public static void GetAllCombinationsWithDuplicates(int k, int n, int left, List<int> combination, List<List<int>> result)
        {
            if (combination.Count == k)
            {
                result.Add(combination);
                return;
            }

            for (int i = left; i < n + 1; i++)
            {
                var currentCombination = new List<int>(combination);
                currentCombination.Add(i);
                GetAllCombinationsWithDuplicates(k, n, i, currentCombination, result);
            }
        }

        public static void GetAllCombinationsWithoutDuplicates(int k, int n, int left, List<int> combination, List<List<int>> result)
        {
            if (combination.Count == k)
            {
                result.Add(combination);
                return;
            }

            for (int i = left; i < n + 1; i++)
            {
                var currentCombination = new List<int>(combination);
                currentCombination.Add(i);
                GetAllCombinationsWithDuplicates(k, n, i+1, currentCombination, result);
            }
        }
    }
}
