//Write a program that reads a sequence of integers (List<int>) ending 
//with an empty line and sorts them in an increasing order.
namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var sequence = new List<int>();
            string currentLine;

            Console.WriteLine("Enter empty line at the end of the sequence.");
            do
            {
                Console.Write("Enter some number:");
                currentLine = Console.ReadLine().Trim();
                try
                {
                    sequence.Add(int.Parse(currentLine));
                }
                catch (Exception)
                {
                }
            } while (currentLine != string.Empty);

            var sortedSequence = sequence.OrderBy(x => x);
            Console.WriteLine("Sorted sequence: {0}", string.Join(", ", sortedSequence));
        }
    }
}
