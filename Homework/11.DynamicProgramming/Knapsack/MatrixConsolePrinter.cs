namespace Knapsack
{
    using System;

    public static class ArrayConsolePrinter
    {
        public static void Print<T>(T[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", arr[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
