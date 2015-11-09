//  Write a recursive program for generating and printing all the 
//  combinations with duplicatesof k elements from n-element set. Example:
namespace CombinationsWithDuplicates
{
    using Services;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Console.Write("Set length - K:");
            var k = int.Parse(Console.ReadLine());
            Console.Write("Number of elements - N:");
            var n = int.Parse(Console.ReadLine());

            var combinations = new List<List<int>>();
            Combinations.GetAllCombinationsWithDuplicates(k, n, 1, new List<int>(), combinations);

            ConsolePrinter.Print(combinations);
        }
    }
}
