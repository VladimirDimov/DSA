namespace PrefixTrie
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    class Startup
    {
        private const int NumberOfSuggestions = 50;

        static void Main()
        {
            var reader = new StreamReader("../../input/bigtext.txt");
            var trie = new Trie();

            var counter = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var matches = Regex.Matches(line, @"\w+");

                foreach (var match in matches)
                {
                    trie.Add(match.ToString());
                }

                if (counter % 10000 == 0)
                {
                    Console.Write('.');
                }
                counter++;
            }

            Console.WriteLine();

            string pattern;
            do
            {
                Console.Write("Enter some pattern: ");
                pattern = Console.ReadLine();
                var matches = trie.Match(pattern, NumberOfSuggestions);
                Console.WriteLine(string.Join(Environment.NewLine, matches));
            } while (pattern != string.Empty);
        }
    }
}
