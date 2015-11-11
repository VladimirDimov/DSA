namespace PermutationsGeneratorWithReps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int[]> result = new List<int[]>();

        static void Main()
        {
            var arr = new int[] { 3, 5, 1, 5, 5 };
            Array.Sort(arr);

            PermuteRep(arr, 0, arr.Length, result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void PermuteRep<T>(T[] arr, int start, int n, List<T[]> result)
        {
            var arrayToAdd = new T[arr.Length];
            Array.Copy(arr, arrayToAdd, arr.Length);
            result.Add(arrayToAdd);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (!arr[left].Equals(arr[right]))
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n, result);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
