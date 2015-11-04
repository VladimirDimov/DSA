namespace TreeRead
{
    class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(TreeNode<T> root)
        {
            this.root = root;
        }

        public Tree(T value)
        {
            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, TreeNode<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                this.root.AddChild(child);
            }
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
        }
    }
}
