namespace Services
{
    using System.Collections.Generic;

    public class Permutations
    {
        public static void Permute(int n, List<int> permutation, HashSet<int> passed, List<List<int>> result)
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
    }
}
