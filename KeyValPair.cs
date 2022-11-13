namespace MyDataStructures
{
    struct KeyValPair<K, V>
    {
        public K Key { get;}
        public V Value { get; set;}
        public KeyValPair(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public void Deconstruct(out K key, out V value)
        {
            key = Key;
            value = Value;
        }
    }
}