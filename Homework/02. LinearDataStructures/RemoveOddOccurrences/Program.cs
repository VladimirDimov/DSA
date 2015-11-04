// Write a program that removes from given sequence all numbers that occur odd number of times
namespace RemoveOddOccurrences
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var sequence = new int[] { 4,2,2,5,2,3,2,3,1,5,2 };

            var result = RemoveOddTimesOccurrences(sequence);

            Console.WriteLine(" Input: => {0}", string.Join(",", sequence));
            Console.WriteLine("Output: => {0}", string.Join(",", result));
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
