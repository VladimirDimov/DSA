using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recover_Message
{
    class Program
    {
        static PriorityQueue<Node> queue = new PriorityQueue<Node>();

        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var dict = new Dictionary<char, Node>();
            for (int i = 0; i < numberOfLines; i++)
            {
                var currentLine = Console.ReadLine();
                var parents = new List<Node>();
                foreach (var letter in currentLine)
                {
                    if (!dict.ContainsKey(letter))
                    {
                        dict.Add(letter, new Node(letter));
                    }

                    foreach (var par in parents)
                    {
                        par.Connections.Add(dict[letter]);
                    }

                    parents.Add(dict[letter]);
                }
            }

            var builder = new StringBuilder();
            Node[] selection;

            do
            {
                selection = dict
                       .Where(x => x.Value.Connections.Count(y => !y.Used) == 0 && !x.Value.Used)
                       .Select(x => x.Value)
                       .ToArray();


                foreach (var item in selection)
                {
                    if (!item.IsInQueue)
                    {
                        queue.Enqueue(item);
                        item.IsInQueue = true;
                    }
                }

                if (queue.Count == 0 && selection.Length == 0)
                {
                    break;
                }

                var maxLetter = queue.Dequeue();
                maxLetter.Used = true;

                builder.Append(maxLetter.Name);
            } while (true);

            Console.WriteLine(Reverse(builder.ToString()));
        }

        static string Reverse(string a)
        {
            var builder = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                builder.Append(a[i]);
            }

            return builder.ToString();
        }
    }

    public class Node : IComparable
    {
        public Node(char val)
        {
            this.Name = val;
            this.Connections = new List<Node>();
            this.Used = false;
        }

        public char Name { get; set; }

        public bool Used { get; set; }

        public bool IsInQueue { get; set; }

        public ICollection<Node> Connections { get; set; }

        public int Unused
        {
            get
            {
                return this.Connections.Count(x => x.Used);
            }
        }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as Node).Name)*(-1);
        }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }
}