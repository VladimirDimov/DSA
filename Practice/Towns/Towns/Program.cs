namespace Towns
{
    using System;

    class Program
    {
        static void Main()
        {
            //var reader = new StreamReader("../../input/1.txt");
            //Console.SetIn(reader);

            var numberOfCities = int.Parse(Console.ReadLine());

            var citizens = new int[numberOfCities];
            for (int i = 0; i < numberOfCities; i++)
            {
                citizens[i] = int.Parse(Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
            }

            var maxIncreasingArr = new int[numberOfCities];
            for (int i = 0; i < numberOfCities; i++)
            {
                maxIncreasingArr[i] = GetCurrentMaxIncreasing(citizens, maxIncreasingArr, i);
            }

            var maxDecreasingRightToLeft = new int[numberOfCities];
            for (int i = numberOfCities - 1; i >= 0; i--)
            {
                maxDecreasingRightToLeft[i] = GetCurrentMaxIncreasingReversed(citizens, maxDecreasingRightToLeft, i);
            }

            int result = 1;
            for (int i = 0; i < numberOfCities; i++)
            {
                var curMax = maxIncreasingArr[i] + maxDecreasingRightToLeft[i] - 1;
                if (result < curMax)
                {
                    result = curMax;
                }
            }

            Console.WriteLine(result);
        }

        static int GetCurrentMaxIncreasing(int[] arr, int[] sol, int position)
        {
            var curMax = 1;
            for (int i = position - 1; i >= 0; i--)
            {
                if (arr[i] < arr[position] && curMax <= sol[i])
                {
                    curMax = sol[i] + 1;
                }
            }

            return curMax;
        }

        static int GetCurrentMaxIncreasingReversed(int[] arr, int[] sol, int position)
        {
            var curMax = 1;
            for (int i = position + 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[position] && curMax <= sol[i])
                {
                    curMax = sol[i] + 1;
                }
            }

            return curMax;
        }
    }
}
