namespace CombinationsNoRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = 5;
            int k = 3;

            string[] objects = new string[] { "A", "B", "C", "D", "E" };

            List<string[]> result = new List<string[]>();
            GenerateCombinationsNoRepetitions(objects, n, k, new int[k], result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void GenerateCombinationsNoRepetitions(string[] objects, int n, int k, int[] currentIndexPositions, List<string[]> result, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                result.Add(currentIndexPositions.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    currentIndexPositions[index] = i;
                    GenerateCombinationsNoRepetitions(objects, n, k, currentIndexPositions, result, index + 1, i + 1);
                }
            }
        }
    }
}
