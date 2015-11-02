using System.Collections.Generic;
namespace HashTable
{
    public class HashTable<K,T>
    {
        private LinkedList<KeyValuePair<K, T>>[] data;
        private int currentIndex;

        public HashTable(int initialCapacity = 16)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[initialCapacity];
            this.currentIndex = 0;
        }

        //Add(key, value)
        public void Add(K key, T value)
        {
            this.data[currentIndex] = new KeyValuePair<K, T>(key, value);
            
        }
        
        //Find(key)->value
        
        //Remove(key)
        
        //Count
        
        //Clear()
        
        //this[]
        
        //Keys

        private void DoubleCapacity()
        {
            var doubleSizeData = new LinkedList<KeyValuePair<K, T>>[this.data.Length * 2];
            for (int i = 0; i < this.data.Length; i++)
            {
                doubleSizeData[i] = this.data[i];
            }

            this.data = doubleSizeData;
        }
    }
}
