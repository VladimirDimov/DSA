// Write a recursive program for generating and printing all permutations 
// of the numbers 1, 2, ..., n for given integer number n. Example:
// n=3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
namespace AllPermutations
{
    using Services;
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter the length of the sequence to permute:");
            var n = int.Parse(Console.ReadLine());

            var result = new List<List<int>>();
            Permutations.PermuteWithRepetition(n, new List<int>(), new HashSet<int>(), result);

            ConsolePrinter.Print(result);
        }
    }
}
