namespace SuperSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int sum;

        public static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var k = inputLine[0];
            var n = inputLine[1];
            sum = 0;

            SuperSum(k, n);
            Console.WriteLine(sum);
        }

        private static void SuperSum(int k, int n)
        {
            if (k == 0)
            {
                sum += n;
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                SuperSum(k - 1, i);
            }
        }
    }
}