namespace CountWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../input.txt"))
            {
                var text = reader.ReadToEnd();
                var regex = new Regex(@"\w+", RegexOptions.Multiline);
                var words = regex.Matches(text);
                var wordsOccurences = new SortedDictionary<string, int>();

                foreach (var word in words)
                {
                    var wordToLower = word.ToString().ToLower();
                    if (wordsOccurences.ContainsKey(wordToLower))
                    {
                        wordsOccurences[wordToLower]++;
                    }
                    else
                    {
                        wordsOccurences[wordToLower] = 1;
                    }
                }

                var orderedWordsByOcurences = wordsOccurences
                    .OrderBy(w => w.Value);

                foreach (var word in orderedWordsByOcurences)
                {
                    Console.WriteLine("{0, -5} => {1}", word.Key, word.Value);
                }
            }
        }
    }
}
