namespace Graphs
{
    public class Edge<T>
    {
        internal Edge(Node<T> target, int distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        internal Node<T> Target { get; private set; }

        internal int Distance { get; private set; }
    }
}
