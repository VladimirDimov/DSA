namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Node<T> : IComparable
    {
        private List<Edge<T>> connections;

        public Node(T name)
        {
            this.Name = name;
            this.connections = new List<Edge<T>>();
            this.Salary = 0;
            this.Parents = new List<Node<T>>();
        }

        public T Name { get; set; }

        public IList<Edge<T>> Connections
        {
            get { return this.connections; }
        }

        public int DistanceFromStart { get; set; }

        public ulong Salary { get; set; }

        public List<Node<T>> Parents { get; set; }

        public void AddConnection(Node<T> targetNode, int distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.connections.Add(new Edge<T>(targetNode, distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }

            targetNode.Parents.Add(this);
        }

        public void CleanConnectionsFromParents()
        {
            foreach (var parent in this.Parents)
            {
                var parentConnections = parent.Connections
                    .Where(x => x.Target == this);
                foreach (var conn in parentConnections)
                {
                    conn.Visited = true;
                }
            }
        }

        public int CompareTo(object obj)
        {
            return this.Connections.Count(c => !c.Visited) -
                ((obj as Node<T>).Connections.Count(c => !c.Visited));
        }
    }
}
