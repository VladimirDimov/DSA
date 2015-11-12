namespace Combinatorics
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine((long)Math.Pow(2, Console.ReadLine().Where(ch => ch == '*').Count()));
        }
    }
}
