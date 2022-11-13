namespace MyDataStructures
{
    class HashTable<TKey, TValue>
    {
        LinkedList<KeyValPair<TKey, TValue>>?[] _storage;
        Func<TKey, int> _hashFunc;
        
        private double LoadFactor 
        {
            get => Length / _storage.Length;   
        }

        public int Length {get; private set;} = 0;

        public HashTable(Func<TKey, int> hashFunc)
        {
            _storage = new LinkedList<KeyValPair<TKey, TValue>>[10];
            _hashFunc = hashFunc;            
        }

        public void Add(TKey key, TValue value)
        {
            var idx = _hashFunc.Invoke(key) % _storage.Length;            
            
            if(_storage[idx] is null)
            {
                _storage[idx] = new LinkedList<KeyValPair<TKey, TValue>>();
            }
            _storage[idx]!.Add(new KeyValPair<TKey, TValue>(key, value));
        }

        public bool Contains(TKey key)
        {
            if(key is null)
                throw new ArgumentNullException("Passed a null key");

            var idx = _hashFunc.Invoke(key) % _storage.Length;

            if(_storage[idx] is null)
                return false;
            
            foreach (var item in _storage[idx]!)
            {
                if(key.Equals(item.Key))
                {
                    return true;
                }
            }

            return false;
        }

        public TValue this[TKey key]
        {
            get 
            { 
                if(key is null)
                    throw new ArgumentNullException("Passed a null key");

                var idx = _hashFunc.Invoke(key) % _storage.Length;

                if(_storage[idx] is null)
                    throw new KeyNotFoundException($"HashTable does not contain key: {key}");
                
                foreach (var item in _storage[idx]!)
                {
                    if(key.Equals(item.Key))
                    {
                        return item.Value;
                    }
                }
                
                throw new KeyNotFoundException($"HashTable does not contain key: {key}");
            }
        }
    }
}