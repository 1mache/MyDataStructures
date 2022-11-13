namespace MyDataStructures
{
    struct KeyValPair<TKey, TValue>
    {
        public TKey Key { get;}
        public TValue Value { get; set;}
        public KeyValPair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public void Deconstruct(out TKey key, out TValue value)
        {
            key = Key;
            value = Value;
        }
    }
}