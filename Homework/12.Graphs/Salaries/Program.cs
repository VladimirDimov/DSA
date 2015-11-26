namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var graph = new Graph<int>();
            var linkedList = new LinkedList<Node<int>>();
            var numberOfEmployees = int.Parse(Console.ReadLine());

            // Create empty nodes
            for (int i = 0; i < numberOfEmployees; i++)
            {
                graph.AddNode(i);
            }

            // connect the nodes
            for (int row = 0; row < numberOfEmployees; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < numberOfEmployees; col++)
                {
                    if (line[col] == 'Y')
                    {
                        graph.Nodes[row]
                            .AddConnection(graph.Nodes[col], 1, false);
                    }
                }
            }

            foreach (var node in graph.Nodes)
            {
                linkedList.AddLast(node.Value);
            }

            ulong sallaryCounter = 0;
            while (linkedList.Count != 0)
            {
                var smallest = linkedList.FirstOrDefault(n => n.Connections.Count(c => !c.Visited) == 0);
                var smallestSalary = smallest.Salary != 0 ? smallest.Salary : 1;
                sallaryCounter += smallestSalary;
                foreach (var parent in smallest.Parents)
                {
                    parent.Salary += smallestSalary;
                }

                smallest.CleanConnectionsFromParents();
                linkedList.Remove(smallest);
            }

            Console.WriteLine(sallaryCounter);
        }
    }
}
