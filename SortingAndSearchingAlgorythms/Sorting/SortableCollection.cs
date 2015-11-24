namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using SortingHomework.Searching;

    public class SortableCollection<T>
        where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            int N = items.Count;
            for (int i = 0; i < N; i++)
                if (items[i].Equals(item))
                    return true;
            return false;
        }

        public bool BinarySearch(T item)
        {
            return BinarySearcher<T>.BinarySearchRecursive(items, item, 0, items.Count - 1);
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = items.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                T t = items[r];
                items[r] = items[i];
                items[i] = t;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
