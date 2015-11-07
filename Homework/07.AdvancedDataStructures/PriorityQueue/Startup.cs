// Implement a class PriorityQueue<T> based on the data structure "binary heap".
namespace PriorityQueueImaplementation
{
    using System;

    class Startup
    {
        private static void Main()
        {
            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Add(1);
            priorityQueue.Add(1);
            priorityQueue.Add(3);
            priorityQueue.Add(1);
            priorityQueue.Add(3);
            priorityQueue.Add(10);
            priorityQueue.Add(2);
            priorityQueue.Add(2);
            priorityQueue.Add(3);
            priorityQueue.Add(2);

            while (priorityQueue.Count != 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}
