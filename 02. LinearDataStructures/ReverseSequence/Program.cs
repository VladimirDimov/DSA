//Write a program that reads N integers from the console and reverses them using a stack.
//
//Use the Stack<int> class.
namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var sequence = new Stack<int>();
            string currentLine;

            Console.WriteLine("Enter empty line at the end of the sequence.");
            do
            {
                Console.Write("Enter some number:");
                currentLine = Console.ReadLine().Trim();
                try
                {
                    sequence.Push(int.Parse(currentLine));
                }
                catch (Exception)
                {
                }
            } while (currentLine != string.Empty);

            var reversedSequence = new List<int>(sequence.Count);
            while (sequence.Count != 0)
            {
                reversedSequence.Add(sequence.Pop());
            }

            Console.WriteLine("Reversed sequence: {0}", string.Join(", ", reversedSequence));
        }
    }
}
