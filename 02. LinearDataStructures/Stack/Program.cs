//  Implement the ADT stack as auto-resizable array.

//  Resize the capacity on demand (when no space is available to add / insert a new element).
namespace Stack
{
    using Stack.Data;
    using System;

    class Program
    {
        static void Main()
        {
            Stack<int> test = new Stack<int>();

            for (int i = 1; i <= 20; i++)
            {
                test.Push(i);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0} -- Count: {1}", test.Pop(), test.Count());
            }
        }
    }
}
