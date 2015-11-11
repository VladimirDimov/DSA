namespace CombinationsNoRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        const int n = 5;
        const int k = 3;

        static string[] objects = new string[n] { "banana", "apple", "orange", "strawberry", "raspberry" };
        static int[] arr = new int[k];
        static List<string[]> combinationsNoRepResult = new List<string[]>();

        static void Main()
        {
            GenerateCombinationsNoRepetitions(0, 0, combinationsNoRepResult);

            foreach (var item in combinationsNoRepResult)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void GenerateCombinationsNoRepetitions(int index, int start, List<string[]> result)
        {
            if (index >= k)
            {
                result.Add(arr.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1, result);
                }
            }
        }
    }
}
