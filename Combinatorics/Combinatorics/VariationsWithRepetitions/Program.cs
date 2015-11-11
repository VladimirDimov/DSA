namespace VariationsWithRepetitions
{
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        const int n = 10;
        const int k = 3;


        static int[] arr = new int[k];

        static void Main()
        {
            string[] objects = new string[n] 
			{
				"banana", "apple", "orange", "strawberry", "raspberry",
				"apricot", "cherry", "lemon", "grapes", "melon"
			};

            List<string[]> result = new List<string[]>();
            GenerateVariationsWithRepetitions(n, k, 0, objects, result);
        }

        static void GenerateVariationsWithRepetitions<T>(int n, int k, int index, T[] objects, List<T[]> result)
        {
            if (index >= k)
            {
                result.Add(arr.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(n, k, index + 1, objects, result);
                }
            }
        }
    }
}
