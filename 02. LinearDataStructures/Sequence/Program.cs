//  We are given the following sequence:

//  S1 = N;
//  S2 = S1 + 1;
//  S3 = 2*S1 + 1;
//  S4 = S1 + 2;
//  S5 = S2 + 1;
//  S6 = 2*S2 + 1;
//  S7 = S2 + 2;
//  ...
//  Using the Queue<T> class write a program to print its first 50 members for given N.
//  Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
namespace Sequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var sequence = GetSequence(2, 52);
            Console.WriteLine(string.Join(", ", sequence));
        }

        private static List<int> GetSequence(int startingNumber, int length)
        {
            var result = new List<int>() { startingNumber };
            var qurrentNumber = new Queue<int>();
            qurrentNumber.Enqueue(startingNumber);

            for (int i = 0; i < length / 3 + 1; i++)
            {
                qurrentNumber.Enqueue(qurrentNumber.Peek() + 1);
                result.Add(qurrentNumber.Peek() + 1);
                result.Add(2 * qurrentNumber.Peek() + 1);
                result.Add(qurrentNumber.Dequeue() + 2);
            }

            return result.Take(length).ToList();
        }
    }
}
