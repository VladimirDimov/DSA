namespace PermutationsNoReps
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<string[]> result = new List<string[]>();

        static void Main()
        {
            string[] arr = { "apple", "banana", "orange" };
            GeneratePermutations(arr, 0, result);
        }

        static void GeneratePermutations<T>(T[] arr, int k, List<T[]> result)
        {
            if (k >= arr.Length)
            {
                var arrToAdd = new T[arr.Length];
                Array.Copy(arr, arrToAdd, arr.Length);
                result.Add(arrToAdd);
            }
            else
            {
                GeneratePermutations(arr, k + 1, result);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1, result);
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
