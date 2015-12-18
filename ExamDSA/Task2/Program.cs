namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static List<Node> graph = new List<Node>();
        static ulong maxTime = 0;

        static void Main()
        {
            //var reader = new StreamReader("../../input/3.txt");
            //Console.SetIn(reader);

            var numberOfTasks = int.Parse(Console.ReadLine());

            var durations = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => ulong.Parse(x))
                .ToArray();

            foreach (var duration in durations)
            {
                graph.Add(new Node(duration));
            }

            for (int i = 0; i < numberOfTasks; i++)
            {
                var dependancies = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

                foreach (var parentIndex in dependancies)
                {
                    if (parentIndex != 0)
                    {
                        graph[parentIndex - 1].Connections.Add(new Connection(graph[i]));
                        graph[i].Hasparents = true;
                    }
                }
            }

            List<Node> startTasks = graph.Where(x => !x.Hasparents).ToList();

            if (startTasks.Count == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            foreach (var task in startTasks)
            {
                FindTimeRecursive(task, new HashSet<Connection>());
            }

            Console.WriteLine(maxTime);
        }

        private static void FindTimeRecursive(Node task, HashSet<Connection> used)
        {
            foreach (var connection in task.Connections)
            {
                if (used.Contains(connection))
                {
                    Console.WriteLine(-1);
                    Environment.Exit(0);
                }

                if (connection.TargetNode.TimeToWait < task.Duration + task.TimeToWait)
                {
                    connection.TargetNode.TimeToWait = task.Duration + task.TimeToWait;
                    var copyOfUsed = new HashSet<Connection>(used);
                    copyOfUsed.Add(connection);
                    FindTimeRecursive(connection.TargetNode, copyOfUsed);
                }
            }

            var childFinishTime = task.TimeToWait + task.Duration;
            if (maxTime < childFinishTime)
            {
                maxTime = childFinishTime;
            }
        }

        class Node
        {
            public Node(ulong duration)
            {
                this.Duration = duration;
                this.Connections = new List<Connection>();
                this.Hasparents = false;
            }

            public ulong Duration { get; set; }

            public ulong TimeToWait { get; set; }

            public List<Connection> Connections { get; set; }

            public bool Hasparents { get; set; }
        }

        class Connection
        {
            public Connection(Node target)
            {
                this.TargetNode = target;
            }

            public Node TargetNode { get; set; }
        }
    }
}
