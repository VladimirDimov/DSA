namespace PermutationsNoReps
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] arr = { "A", "B", "C" };

            List<string[]> result = new List<string[]>();
            GeneratePermutations(arr, result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void GeneratePermutations<T>(T[] arr, List<T[]> result, int k = 0)
        {
            if (k >= arr.Length)
            {
                var arrToAdd = new T[arr.Length];
                Array.Copy(arr, arrToAdd, arr.Length);
                result.Add(arrToAdd);
            }
            else
            {
                GeneratePermutations(arr, result, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, result, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
