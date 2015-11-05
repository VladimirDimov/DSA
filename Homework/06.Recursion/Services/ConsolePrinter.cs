namespace Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
