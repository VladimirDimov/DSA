namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            //var reader = new StreamReader("../../input/2.txt");
            //Console.SetIn(reader);

            var tree = new Dictionary<ulong, Node>();

            var numberOFNodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOFNodes - 1; i++)
            {
                var lineNumbers = Console.ReadLine()
                                    .Split(new char[] { '(', ')', '<', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => ulong.Parse(x))
                                    .ToArray();

                if (!tree.ContainsKey(lineNumbers[0]))
                {
                    tree.Add(lineNumbers[0], new Node(lineNumbers[0]));
                }

                if (!tree.ContainsKey(lineNumbers[1]))
                {
                    tree.Add(lineNumbers[1], new Node(lineNumbers[1]));
                }

                tree[lineNumbers[0]].AddChild(tree[lineNumbers[1]]);
            }

            var root = tree.FirstOrDefault(x => !x.Value.HasParent).Value;

            FindMaxPath(root);

            ulong maxPath = 0;
            foreach (var node in tree)
            {
                ulong curMax = node.Value.Value;
                var pathsNumber = node.Value.PathLengths.Count;
                if (pathsNumber >= 2)
                {
                    curMax +=
                        node.Value.PathLengths[pathsNumber - 2] +
                        node.Value.PathLengths[pathsNumber - 1];
                }

                else if (pathsNumber == 1)
                {
                    curMax +=
                        node.Value.PathLengths[0];
                }

                if (maxPath < curMax)
                {
                    maxPath = curMax;
                }
            }

            Console.WriteLine(maxPath);
        }

        static ulong FindMaxPath(Node root)
        {
            foreach (var child in root.Children)
            {
                root.PathLengths.Add(FindMaxPath(child));
            }

            if (root.PathLengths.Count != 0)
            {
                return root.Value + root.PathLengths.Max();
            }
            else
            {
                return root.Value;
            }
        }
    }

    class Node
    {
        public Node(ulong val)
        {
            this.Value = val;
            this.Children = new HashSet<Node>();
            this.PathLengths = new OrderedBag<ulong>();
        }

        public ulong Value { get; set; }

        public ICollection<Node> Children { get; set; }

        public OrderedBag<ulong> PathLengths { get; set; }

        public bool HasChildren { get; private set; }

        public bool HasParent { get; private set; }

        public void AddChild(Node child)
        {
            this.Children.Add(child);
            this.HasChildren = true;
            child.HasParent = true;
        }
    }
}
