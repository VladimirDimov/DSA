namespace OrderedSubsets
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
