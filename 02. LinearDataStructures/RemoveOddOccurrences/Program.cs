// Write a program that removes from given sequence all numbers that occur odd number of times
namespace RemoveOddOccurrences
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var sequence = new int[] { 1, 1, 2, 4, 4, 4, 5, 1, 3, 3, 1, 1, 1 };

            var result = RemoveOddTimesOccurrences(sequence);

            Console.WriteLine(string.Join(",", result));
        }

        private static int[] RemoveOddTimesOccurrences(int[] sequence)
        {
            var result = sequence
                .Where(s => sequence
                    .Count(x => x == s) % 2 == 0);
            return result.ToArray();
        }
    }
}
