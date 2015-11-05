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
            Permutations.Permute(n, new List<int>(), new HashSet<int>(), result);

            ConsolePrinter.Print(result);
        }
    }
}
