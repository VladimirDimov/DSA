namespace CombinationsGeneratorWithReps
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        const int n = 5;
        const int k = 3;

        static string[] objects = new string[n] 
	    {
		    "banana", "apple", "orange", "strawberry", "raspberry"
	    };

        static int[] arr = new int[k];


        static void Main()
        {
            List<string[]> result = new List<string[]>();
            GenerateCombinationsNoRepetitions(0, 0, objects, result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void GenerateCombinationsNoRepetitions<T>(int index, int start, T[] objects, List<T[]> result)
        {
            if (index >= k)
            {
                var output = new T[arr.Length];                
                result.Add(arr.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i, objects, result);
                }
            }
        }
    }
}
