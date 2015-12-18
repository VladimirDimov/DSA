namespace LongestSubSequence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var reader = new StreamReader("../../input/1.txt");
            Console.SetIn(reader);

            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            var patternLength = pattern.Length;
            Hash.ComputePowers(text.Length);

            for (int curLength = patternLength; curLength >= 0; curLength--)
            {
                for (int index = 0; index <= patternLength - curLength; index++)
                {
                    var subPattern = pattern.Substring(index, curLength);
                    if (ContainsPattern(text, subPattern))
                    {
                        Console.WriteLine(curLength);
                        return;
                    }
                }
            }
        }

        private static bool ContainsPattern(string text, string subPattern)
        {
            var pHash = new Hash(subPattern);
            var pLength = subPattern.Length;
            var tLength = text.Length;
            var tHash = new Hash(text.Substring(0, pLength));

            var index = 0;
            while (index < tLength - pLength)
            {
                if (tHash.Value == pHash.Value)
                {
                    return true;
                }

                tHash.Add(text[index + pLength]);
                tHash.Remove(text[index], pLength);
                index++;
            }

            return false;
        }
    }

    class Hash
    {
        private const ulong BASE = 257;
        private const ulong MOD = 1000000033;

        private static ulong[] powers;

        public static void ComputePowers(int n)
        {
            powers = new ulong[n + 1];
            powers[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers[i + 1] = powers[i] * BASE % MOD;
            }
        }

        public ulong Value { get; private set; }

        public Hash(string str)
        {
            this.Value = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value = (this.Value * BASE + c) % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value = (MOD + this.Value - powers[n] * c % MOD) % MOD;
        }
    }
}
