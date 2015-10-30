namespace Queue
{
    using Queue.Data;
    using System;

    class Program
    {
        static void Main()
        {
            var testingQueue = new Queue<int>();

            for (int i = 1; i <= 10; i++)
            {
                testingQueue.Enqueue(i);
            }

            do
            {
                Console.WriteLine("{0} -- Length: {1}", testingQueue.Dequeue(), testingQueue.Length);
            } while (testingQueue.Length != 0);
        }
    }
}
