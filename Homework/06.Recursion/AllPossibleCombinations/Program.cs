namespace Recursion
{
    using Services;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var combinations = new List<List<int>>();

            Combinations.GetAllPossibleCombinations(n, new List<int>(), combinations);

            ConsolePrinter.Print<int>(combinations);
        }
    }
}
