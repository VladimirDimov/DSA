namespace VariationsWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = 3;
            int k = 2;

            string[] objects = new string[] { "A", "B", "C" };

            List<string[]> result = new List<string[]>();
            GenerateVariationsWithRepetitions(n, k, objects, new int[k], result);

            foreach (var combo in result)
            {
                Console.WriteLine(string.Join(" ", combo));
            }
        }

        static void GenerateVariationsWithRepetitions<T>(int n, int k, T[] objects, int[] currentVariation, List<T[]> result, int index = 0)
        {
            if (index >= k)
            {
                result.Add(currentVariation.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    currentVariation[index] = i;
                    GenerateVariationsWithRepetitions(n, k, objects, currentVariation, result, index + 1);
                }
            }
        }
    }
}
