namespace Election
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var numberOfParties = int.Parse(Console.ReadLine());
            var votes = new int[numberOfParties];

            for (int i = 0; i < numberOfParties; i++)
            {
                votes[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(votes);
            var sumOfVotes = votes.Sum();

            var table = new int[numberOfParties + 1, sumOfVotes + 1];
            table[0, 0] = 1;
            for (int row = 1; row <= numberOfParties; row++)
            {
                for (int col = 0; col <= sumOfVotes; col++)
                {
                    table[row, col] += table[row - 1, col];
                    var forwardCol = col + votes[row - 1];
                    if (forwardCol <= sumOfVotes)
                    {
                        table[row, forwardCol] = table[row - 1, col] * 1;
                    }
                }
            }

            var result = 0;
            for (int col = k; col <= sumOfVotes; col++)
            {
                result += table[numberOfParties, col];
            }

            Console.WriteLine(result);
        }
    }
}