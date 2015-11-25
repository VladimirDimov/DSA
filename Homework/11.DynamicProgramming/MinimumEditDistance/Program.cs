namespace MinimumEditDistance
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var medCalculator = new MEDCalculator(0.8m, 0.9m, 1);

            var input = new List<string[]>();
            input.Add(new string[] { "developer", "enveloped" });
            input.Add(new string[] { "developer", "eveloper" });
            input.Add(new string[] { "eveloper", "enveloper" });
            input.Add(new string[] { "r", "d" });


            foreach (var pair in input)
            {
                Console.WriteLine("{0, -10} | {1, -10} | {2}", pair[0], pair[1], medCalculator.Calculate(pair[0], pair[1]));
            }
        }
    }
}
