namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        static ulong[] prefixes;
        static ulong[] suffixes;

        static void Main()
        {
            var reader = new StreamReader("../../input/1.txt");
            Console.SetIn(reader);

            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            int n = text.Length;
            int m = pattern.Length;

            prefixes = new ulong[m];
            suffixes = new ulong[m];

            Hash.ComputePowers(m);
            Hash hpattern = new Hash(string.Empty);
            Hash suffPattern = new Hash(string.Empty);

            for (int subLen = 1; subLen <= m; subLen++)
            {
                hpattern.AddToBack(pattern[subLen - 1]);
                suffPattern.AddToFront(pattern[m - subLen], subLen);
                Hash hwindow = new Hash(text.Substring(0, subLen));

                if (hpattern.Value == hwindow.Value)
                {
                    prefixes[m - subLen - 1]++;
                }

                if (suffPattern.Value == hwindow.Value)
                {
                    suffixes[m - subLen - 1]++;
                }

                for (int i = 0; i < n - m; i++)
                {
                    hwindow.AddToBack(text[i + subLen]);
                    hwindow.Remove(text[i], subLen);
                    
                    if (hpattern.Value == hwindow.Value)
                    {
                        prefixes[subLen - 1]++;
                    }

                    if (suffPattern.Value == hwindow.Value)
                    {
                        suffixes[subLen - 1]++;
                    }
                }
            }

            BigInteger result = 0;
            for (int i = 0; i < m - 1; i++)
            {
                result += prefixes[i] * suffixes[i];
            }

            result += prefixes[m - 1];

            Console.WriteLine(result);
        }
    }

    // The "Hash" class is a coppy from the teleric academy DSA demos!!!
    class Hash
    {
        private const ulong BASE = 256;
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
                this.AddToBack(c);
            }
        }

        public void AddToBack(char c)
        {
            this.Value = (this.Value * BASE + c) % MOD;
        }

        public void AddToFront(char c, int wordLength)
        {
            this.Value = (powers[wordLength - 1] * c + this.Value) % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value = (MOD + this.Value - powers[n] * c % MOD) % MOD;
        }
    }
}