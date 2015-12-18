using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recover_Message
{
    class Program
    {
        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var dict = new Dictionary<char, Node>();
            for (int i = 0; i < numberOfLines; i++)
            {
                var currentLine = Console.ReadLine();
                var parents = new List<Node>();
                foreach (var letter in currentLine)
                {
                    if (!dict.ContainsKey(letter))
                    {
                        dict.Add(letter, new Node(letter));
                    }

                    foreach (var par in parents)
                    {
                        par.Connections.Add(dict[letter]);
                    }

                    parents.Add(dict[letter]);
                }
            }

            var builder = new StringBuilder();
            char[] selection;
            do
            {
                selection = dict
                   .Where(x => x.Value.Connections.Count(y => !y.Used) == 0 && !x.Value.Used)
                   .Select(x => x.Value.Value)
                   .OrderByDescending(x => x)
                   .ToArray();

                foreach (var item in selection)
                {
                    dict[item].Used = true;
                }

                builder.Append(string.Join("", selection));

            } while (selection.Length != 0);

            Console.WriteLine(Reverse(builder.ToString()));
        }

        static string Reverse(string a)
        {
            var builder = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                builder.Append(a[i]);
            }

            return builder.ToString();
        }
    }

    public class Node
    {
        public Node(char val)
        {
            this.Value = val;
            this.Connections = new List<Node>();
            this.Used = false;
        }

        public char Value { get; set; }

        public bool Used { get; set; }

        public ICollection<Node> Connections { get; set; }

        public int Unused
        {
            get
            {
                return this.Connections.Count(x => x.Used);
            }
        }
    }
}
