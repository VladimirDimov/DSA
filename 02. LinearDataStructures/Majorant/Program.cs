namespace Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var numbers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            var majorantMinCount = numbers.Length / 2 + 1;
            var occurrences = GetOccurences(numbers);
            var maxOccurences = occurrences
                .Where(x => x.Value == occurrences.Max(y => y.Value))
                .Select(x => new { Number = x.Key, Value = x.Value })
                .ToList();

            if (maxOccurences[0].Value >= majorantMinCount)
            {
                Console.WriteLine("Majorant {0} => {1} times", maxOccurences[0].Number, maxOccurences[0].Value);
            }
            else
            {
                Console.WriteLine("No majorant");
            }
        }

        private static Dictionary<int, int> GetOccurences(int[] array)
        {
            var occurrences = new Dictionary<int, int>();
            foreach (var num in array)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num]++;
                }
                else
                {
                    occurrences[num] = 1;
                }
            }

            return occurrences;
        }
    }
}
