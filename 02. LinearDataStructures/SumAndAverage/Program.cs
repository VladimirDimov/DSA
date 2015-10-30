//Write a program that reads from the console a sequence of positive integer numbers.
//
//The sequence ends when empty line is entered.
//Calculate and print the sum and average of the elements of the sequence.
//Keep the sequence in List<int>.
namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var numbers = new List<int>();
            string currentLine;

            Console.WriteLine("Enter empty line at the end of the sequence.");
            do
            {
                Console.Write("Enter some number:");
                currentLine = Console.ReadLine().Trim();
                try
                {
                    numbers.Add(int.Parse(currentLine));
                }
                catch (Exception)
                {
                }
            } while (currentLine != string.Empty);

            Console.WriteLine("Sum: {0}", numbers.Sum());
            Console.WriteLine("Average: {0}", numbers.Average());
        }
    }
}
