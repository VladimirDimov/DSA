namespace PermutationsWithRepetition
{
    using System;

    public class PermutationsGenerator
    {
        public static void Generate(int[] set, int startingPosition = 0)
        {
            Print(set);
            if (startingPosition < set.Length)
            {
                for (int i = set.Length - 2; i >= startingPosition; i--)
                {
                    for (int j = i + 1; j < set.Length; j++)
                    {
                        if (set[i] != set[j])
                        {
                            Swap(i, j, set);
                            Generate(set, i + 1);
                        }
                    }

                    var buffer = set[i];
                    for (int k = i; k < set.Length - 1; )
                    {
                        set[k] = set[++k];
                    }

                    set[set.Length - 1] = buffer;
                }
            }
        }

        private static void Swap(int start, int end, int[] array)
        {
            var buffer = array[end];
            array[end] = array[start];
            array[start] = buffer;
        }

        public static void Print(int[] numbers)
        {
            Console.WriteLine("({0})", string.Join(" ", numbers));
        }
    }
}
