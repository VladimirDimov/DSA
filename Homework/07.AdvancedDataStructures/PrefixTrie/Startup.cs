namespace PrefixTrie
{
    using PrefixTrie.TrieData;
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    class Startup
    {
        private const int NumberOfSuggestions = 50;

        static void Main()
        {
            var reader = new StreamReader("../../input/big-text.txt");
            var trie = TrieFactory.CreateTrie();

            var counter = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var matches = Regex.Matches(line, @"\w+");

                foreach (var match in matches)
                {
                    trie.AddWord(match.ToString());
                }

                if (counter % 10000 == 0)
                {
                    Console.Write('.');
                }
                counter++;
            }

            Console.WriteLine();

            string preffix;
            do
            {
                Console.Write("Enter word preffix: ");
                preffix = Console.ReadLine();
                var matches = trie.GetWords(preffix);

                var output = new StringBuilder();
                foreach (var word in matches)
                {
                    output.AppendLine(string.Format("{0, -20} => {1}", word, trie.WordCount(word)));
                }

                Console.WriteLine(output);
            } while (preffix != string.Empty);
        }
    }
}
