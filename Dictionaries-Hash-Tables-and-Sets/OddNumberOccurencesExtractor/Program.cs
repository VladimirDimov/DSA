//Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:

//{C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}

namespace OddNumberOccurencesExtractor
{
    using Services;
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var evenOccurences = OddNumberOccurencesExtractor.Apply<string>(input);

            Console.WriteLine("Even occurences: {0}", string.Join(", ", evenOccurences));
        }
    }
}
