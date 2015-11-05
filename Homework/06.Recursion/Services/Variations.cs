namespace Services
{
    using System.Collections.Generic;

    public class Variations
    {
        public static void GetAllVariationsWithRepetitions<T>(int k, List<T> set, List<T> combination, List<List<T>> result)
        {
            if (combination.Count == k)
            {
                result.Add(combination);
                return;
            }

            for (int i = 0; i < set.Count; i++)
            {
                var currentCombination = new List<T>(combination);
                currentCombination.Add(set[i]);
                GetAllVariationsWithRepetitions(k, set, currentCombination, result);
            }
        }

        public static void GetAllVariationsWithoutRepetitions<T>(int k, List<T> set, List<T> combination, List<List<T>> result, int left = 0)
        {
            if (combination.Count == k)
            {
                result.Add(combination);
                return;
            }

            for (int i = left; i < set.Count; i++)
            {
                var currentCombination = new List<T>(combination);
                currentCombination.Add(set[i]);
                GetAllVariationsWithoutRepetitions(k, set, currentCombination, result, i + 1);
            }
        }
    }
}
