namespace Graphs
{
    using System.Collections.Generic;

    public class Graph<T>
    {
        private Dictionary<T, Node<T>> nodes;

        public Graph()
        {
            this.nodes = new Dictionary<T, Node<T>>();
        }

        public IDictionary<T, Node<T>> Nodes
        {
            get { return this.nodes; }
        }

        public void AddNode(T name)
        {
            this.nodes.Add(name, new Node<T>(name));
        }

        public bool ContainsNode(T name)
        {
            return this.nodes.ContainsKey(name);
        }

        public void AddConnection(T fromNode, T toNode, int distance, bool twoWay)
        {
            this.nodes[fromNode].AddConnection(this.nodes[toNode], distance, twoWay);
        }
    }
}
