// Modify the previous program to skip duplicates:
// n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
namespace CombinationsWithDuplicates
{
    using Services;
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            Console.Write("Set length - K:");
            var k = int.Parse(Console.ReadLine());
            Console.Write("Number of elements - N:");
            var n = int.Parse(Console.ReadLine());

            var combinations = new List<List<int>>();
            Combinations.GetAllCombinationsWithoutDuplicates(k, n, 1, new List<int>(), combinations);

            ConsolePrinter.Print(combinations);
        }
    }
}
