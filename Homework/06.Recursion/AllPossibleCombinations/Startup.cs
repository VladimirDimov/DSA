// Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
namespace Recursion
{
    using Services;
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            Console.Write("Enter sequence length: ");
            var n = int.Parse(Console.ReadLine());

            var combinations = new List<List<int>>();

            Combinations.GetAllPossibleCombinations(n, new List<int>(), combinations);

            ConsolePrinter.Print<int>(combinations);
        }
    }
}
