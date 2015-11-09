// Write a program for generating and printing all subsets of k strings from given set of strings.
// Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)
namespace OrderedSubsetsWithoutRepetitions
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
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
            Variations.GetAllVariationsWithoutRepetitions(k, set, new List<string>(), variations);

            ConsolePrinter.Print(variations);
        }
    }
}
