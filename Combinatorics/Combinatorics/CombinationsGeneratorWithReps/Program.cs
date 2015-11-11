namespace CombinationsGeneratorWithReps
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {



        static void Main()
        {
            int n = 3;
            int k = 2;

            string[] objects = new string[3] 
	        {
		        "A", "B", "C"
	        };

            int[] arr = new int[k];

            List<string[]> result = new List<string[]>();
            GenerateCombinationsNoRepetitions(n, k, objects, new int[k], result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void GenerateCombinationsNoRepetitions<T>(int n, int k, T[] objects, int[] indexPositions, List<T[]> result, int index = 0, int start = 0)
        {
            if (index >= k)
            {
                var output = new T[k];
                result.Add(indexPositions.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    indexPositions[index] = i;
                    GenerateCombinationsNoRepetitions(n, k, objects, indexPositions, result, index + 1, i);
                }
            }
        }
    }
}
