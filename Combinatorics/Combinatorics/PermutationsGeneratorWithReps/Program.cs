namespace PermutationsGeneratorWithReps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var arr = new int[] { 3, 5, 1, 5 };
            Array.Sort(arr);

            List<int[]> result = new List<int[]>();
            PermuteRep(arr, arr.Length, result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void PermuteRep<T>(T[] arr, int n, List<T[]> result, int start = 0)
        {
            var arrayToAdd = new T[n];
            Array.Copy(arr, arrayToAdd, n);
            result.Add(arrayToAdd);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (!arr[left].Equals(arr[right]))
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, n, result, left + 1);
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

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
