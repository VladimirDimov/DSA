// Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
namespace ConsoleApplication1
{
    using Services;
    using System;

    class Program
    {
        static void Main()
        {
            var input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var valuesOccurences = OccurencesCounter.GetOccurences<double>(input);            

            foreach (var keyValue in valuesOccurences)
            {
                Console.WriteLine("{0, 4} => {1} times", keyValue.Key, keyValue.Value);
            }
        }
    }
}
