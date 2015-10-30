//Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
//how many times each of them occurs.

//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2 → 2 times
//3 → 4 times
//4 → 3 times
namespace CountOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var array = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 , 10, 11, 10};
            Console.WriteLine("Input: {0}",string.Join(", ", array));
            Console.WriteLine();

            var occurrences = GetOccurences(array);

            foreach (var number in occurrences.Keys)
            {
                Console.WriteLine("{0, 2} -- {1} times", number, occurrences[number]);
            }
        }

        private static SortedDictionary<int, int> GetOccurences(int[] array)
        {
            var occurrences = new SortedDictionary<int, int>();
            foreach (var num in array)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num]++;
                }
                else
                {
                    occurrences[num] = 1;
                }
            }

            return occurrences;
        }
    }
}
