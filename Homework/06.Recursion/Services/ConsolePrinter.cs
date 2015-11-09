namespace Services
{
    using System;
    using System.Collections.Generic;

    public class ConsolePrinter
    {
        public static void Print<T>(List<List<T>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
