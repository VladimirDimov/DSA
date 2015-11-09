namespace BiDictionary.Data
{
    public class KeysValueTripple<K1, K2, T>
    {
        public KeysValueTripple(K1 key1, K2 key2, T value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }

        public K1 Key1 { get; set; }

        public K2 Key2 { get; set; }

        public T Value { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
