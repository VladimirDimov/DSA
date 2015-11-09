// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
// Example: n=3, k=2, set = {hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
namespace OrderedSubsets
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            // Documentate this to manually input from console
            Console.SetIn(new StreamReader("../../input/1.txt"));

            Console.WriteLine("Set length - K:");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter set values, separated by commas and/or space:");
            var set = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var variations = new List<List<string>>();
            Variations.GetAllVariationsWithRepetitions(k, set, new List<string>(), variations);

            ConsolePrinter.Print(variations);
        }
    }
}
