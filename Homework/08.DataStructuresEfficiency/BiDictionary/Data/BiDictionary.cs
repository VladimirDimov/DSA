using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary.Data
{
    class BiDictionary<K1, K2, T>
    {
        private LinkedList<KeysValueTripple<K1, K2, T>>[,] data;
        int numberOfOccupiedCells = 0;

        public BiDictionary(int initialSize = 16)
        {
            this.data = new LinkedList<KeysValueTripple<K1, K2, T>>[initialSize, initialSize];
        }

        public T this[K1 key1, K2 key2]
        {
            get
            {
                int rowIndex = key1.GetHashCode() % this.data.GetLength(0);
                int colIndex = key2.GetHashCode() % this.data.GetLength(1);

                return this.data[rowIndex, colIndex]
                    .First(x => x.Key1.Equals(key1) && x.Key2.Equals(key2)).Value;
            }

            set
            {
                int rowIndex = key1.GetHashCode() % this.data.GetLength(0);
                int colIndex = key2.GetHashCode() % this.data.GetLength(1);

                this.data[rowIndex, colIndex]
                    .AddLast(new KeysValueTripple<K1, K2, T>(key1, key2, value));
            }
        }

        public ICollection<KeysValueTripple<K1, K2, T>> GetByKey1(K1 key1)
        {
            var result = new List<KeysValueTripple<K1, K2, T>>();
            int row = key1.GetHashCode() % this.data.GetLength(0);

            for (int col = 0; col < this.data.GetLength(1); col++)
            {
                if (this.data[row, col] != null)
                {
                    foreach (var item in this.data[row, col])
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public ICollection<KeysValueTripple<K1, K2, T>> GetByKey2(K2 key2)
        {
            var result = new List<KeysValueTripple<K1, K2, T>>();
            int colIndex = key2.GetHashCode() % this.data.GetLength(1);

            for (int row = 0; row < this.data.GetLength(0); row++)
            {
                if (this.data[row, colIndex] != null)
                {
                    foreach (var item in this.data[row, colIndex])
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }


        public void Add(K1 key1, K2 key2, T value)
        {
            int rowIndex = key1.GetHashCode() % this.data.GetLength(0);
            int colIndex = key2.GetHashCode() % this.data.GetLength(1);

            if (this.data[rowIndex, colIndex] == null)
            {
                this.data[rowIndex, colIndex] = new LinkedList<KeysValueTripple<K1, K2, T>>();
                numberOfOccupiedCells++;
                UpdateSize();
            }

            this.data[rowIndex, colIndex]
                .AddLast(new KeysValueTripple<K1, K2, T>(key1, key2, value));
        }

        public bool ContainsKeyPair(K1 key1, K2 key2)
        {
            int rowIndex = key1.GetHashCode() % this.data.GetLength(0);
            int colIndex = key2.GetHashCode() % this.data.GetLength(1);

            if (this.data[rowIndex, colIndex] == null)
            {
                return false;
            }

            return true;
        }

        private void UpdateSize()
        {
            if (this.numberOfOccupiedCells > 0.7 * this.data.GetLength(0) * this.data.GetLength(1)) ;
            {
                DoubleSize();
            }
        }

        private void DoubleSize()
        {
            var doubleSizeRows = this.data.GetLength(0);
            var doubleSizeCols = this.data.GetLength(1);
            var doubleData = new LinkedList<KeysValueTripple<K1, K2, T>>[doubleSizeRows, doubleSizeCols];

            for (int row = 0; row < doubleSizeRows; row++)
            {
                for (int col = 0; col < doubleSizeCols; col++)
                {
                    doubleData[row, col] = this.data[row, col];
                }
            }

            this.data = doubleData;
        }
    }
}
