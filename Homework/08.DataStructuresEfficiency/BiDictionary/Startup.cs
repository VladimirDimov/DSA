namespace BiDictionary
{
    using BiDictionary.Data;
    using System;

    class Startup
    {
        static void Main()
        {
            var bidictionary = new BiDictionary<int, int, string>();

            bidictionary.Add(1, 1, "AA");
            bidictionary.Add(1, 2, "AB");
            bidictionary.Add(1, 2, "AB");
            bidictionary.Add(2, 1, "BA");
            bidictionary.Add(2, 2, "BB");
            bidictionary.Add(2, 3, "BC");
            bidictionary.Add(3, 1, "CA");
            bidictionary.Add(3, 2, "CB");
            bidictionary.Add(3, 3, "CC");
            bidictionary.Add(3, 4, "CD");
            bidictionary.Add(3, 5, "CE");
            bidictionary.Add(3, 6, "CF");

            Console.WriteLine("Values by two keys:");
            Console.WriteLine(bidictionary[1, 1]);
            Console.WriteLine(bidictionary[1, 2]);
            Console.WriteLine(bidictionary[3, 2]);

            Console.WriteLine();
            var collectionByKey1 = bidictionary.GetByKey1(3);
            Console.WriteLine("All values with key1 = 3:");
            Console.WriteLine(string.Join(Environment.NewLine, collectionByKey1));

            Console.WriteLine();
            var collectionByKey2 = bidictionary.GetByKey2(2);
            Console.WriteLine("All values with key2 = 2:");
            Console.WriteLine(string.Join(Environment.NewLine, collectionByKey2));
        }
    }
}
