using HashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashedSet
{
    class HashedSet<T> : IEnumerable<T>
    {
        HashTable<T, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<T, T>();
        }

        public int Count
        {
            get
            {
                return hashTable.Count;
            }
        }

        public void Add(T item)
        {
            hashTable.Add(item, item);
        }

        public bool Find(T item)
        {
            return hashTable.ContainsKey(item);
        }

        public void Remove(T item)
        {
            hashTable.Remove(item);
        }

        public void Clear()
        {
            hashTable.Clear();
        }

        public void Union(HashedSet<T> hashedSet)
        {
            foreach (var item in hashedSet)
            {
                if (!(this.Find(item)))
                {
                    this.Add(item);
                }
            }
        }

        public void Intersect(HashedSet<T> hashedSet)
        {
            HashTable<T, T> newtable = new HashTable<T, T>();
            foreach (var item in hashedSet)
            {
                if (this.Find(item))
                {
                    newtable.Add(item, item);
                }
            }
            this.hashTable = newtable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.hashTable.Keys.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return hashTable.Keys.GetEnumerator();
        }
    }
}
