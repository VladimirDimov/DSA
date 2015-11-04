namespace TreeRead
{
    using System.Collections.Generic;

    class TreeNode<T>
    {
        private ICollection<TreeNode<T>> children;

        public TreeNode(T value)
        {
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }

        public bool HasParent { get; set; }

        public ICollection<TreeNode<T>> Children
        {
            get { return this.children; }
        }

        public void AddChild(TreeNode<T> child)
        {
            child.HasParent = true;
            this.children.Add(child);
        }
    }
}
