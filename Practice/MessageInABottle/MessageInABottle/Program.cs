namespace MessageInABottle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class Program
    {
        static SortedDictionary<long, char> codesOfLetters = new SortedDictionary<long, char>();
        static SortedDictionary<char, long> lettersToCodes = new SortedDictionary<char, long>();

        static void Main()
        {
            //var reader = new StreamReader("../../input/3.txt");
            //Console.SetIn(reader);

            var message = Console.ReadLine();
            var cypher = Console.ReadLine();

            var currentCode = new StringBuilder();
            for (int i = 0; i < cypher.Length; i++)
            {
                if (char.IsLetter(cypher[i]) && currentCode.Length != 0)
                {
                    codesOfLetters.Add(
                        int.Parse(currentCode.ToString().Substring(1, currentCode.Length - 1)),
                        currentCode[0]);

                    lettersToCodes.Add(
                        currentCode[0],
                        int.Parse(currentCode.ToString().Substring(1, currentCode.Length - 1)));

                    currentCode.Clear();
                }

                currentCode.Append(cypher[i]);
            }

            codesOfLetters.Add(
                        int.Parse(currentCode.ToString().Substring(1, currentCode.Length - 1)),
                        currentCode[0]);
            lettersToCodes.Add(
                        currentCode[0],
                        int.Parse(currentCode.ToString().Substring(1, currentCode.Length - 1)));

            var possibleMessages = new SortedSet<string>();

            var root = new Node(-1);
            BuildTree(message, root);

            ExtractMessagesFromTree(root, possibleMessages, new List<char>());

            var validMessages = new SortedSet<string>();
            foreach (var m in possibleMessages)
            {
                var builder = new StringBuilder();
                foreach (var letter in m)
                {
                    if (lettersToCodes.ContainsKey(letter))
                    {
                        builder.Append(lettersToCodes[letter]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (builder.ToString() == message)
                {
                    validMessages.Add(m);
                }
            }

            Console.WriteLine(validMessages.Count);
            Console.WriteLine(string.Join(Environment.NewLine, validMessages));
        }

        private static void ExtractMessagesFromTree(Node root, SortedSet<string> possibleMessages, List<char> currentMessage)
        {
            if (root.Children.Count == 0 && currentMessage.Count != 0)
            {
                possibleMessages.Add(string.Join("", currentMessage));
            }

            foreach (var node in root.Children)
            {
                var newCurrentMessage = new List<char>(currentMessage);
                newCurrentMessage.Add(codesOfLetters[node.Value]);
                ExtractMessagesFromTree(node, possibleMessages, newCurrentMessage);
            }
        }

        private static void BuildTree(string message, Node root, int left = 0)
        {
            var builder = new StringBuilder();
            for (int i = left; i < message.Length; i++)
            {
                builder.Append(message[i]);
                var currentCode = long.Parse(builder.ToString());
                if (codesOfLetters.ContainsKey(currentCode))
                {
                    var nodeToAppend = new Node(currentCode);
                    root.AddChild(nodeToAppend);
                    BuildTree(message, nodeToAppend, i + 1);
                }
            }
        }
    }

    class Node
    {
        public Node(long value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public IList<Node> Children { get; private set; }

        public long Value { get; private set; }

        public void AddChild(Node node)
        {
            this.Children.Add(node);
        }
    }
}
