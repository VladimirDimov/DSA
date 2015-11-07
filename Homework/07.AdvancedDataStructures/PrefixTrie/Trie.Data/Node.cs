namespace PrefixTrie
{
    using System.Collections;
    using System.Collections.Specialized;

    public class Node
    {
        public const char Eow = '$';
        public const char Root = ' ';

        public char Letter { get; set; }
        public HybridDictionary Children { get; private set; }

        public Node() { }

        public Node(char letter)
        {
            this.Letter = letter;
        }

        public Node this[char index]
        {
            get { return (Node)Children[index]; }
        }

        public ICollection Keys
        {
            get { return Children.Keys; }
        }

        public bool ContainsKey(char key)
        {
            return Children.Contains(key);
        }

        public Node AddChild(char letter)
        {
            if (Children == null)
                Children = new HybridDictionary();

            if (!Children.Contains(letter))
            {
                var node = letter != Eow ? new Node(letter) : null;
                Children.Add(letter, node);
                return node;
            }

            return (Node)Children[letter];
        }

        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}
