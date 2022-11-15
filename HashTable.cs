namespace MyDataStructures
{
    class HashTable<K, V>
    {
        private const double MAX_LOAD_FACTOR = 0.7;
        private const int DEFAULT_SIZE = 8;
        
        private LinkedList<KeyValPair<K, V>>?[] _storage;
        private readonly Func<K, int> _hashFunc;
        //how many buckets are occupied, different from Length

        private double LoadFactor 
        {
            get => Length *1.0 / _storage.Length;   
        }

        //how many items there are in the table
        public int Length {get; private set;} = 0;

        //default constructor with a default hash function
        public HashTable()
            :this(key => key is null ? throw new ArgumentNullException() : key.GetHashCode())
        {}
        public HashTable(Func<K, int> hashFunc)
        {
            _storage = new LinkedList<KeyValPair<K, V>>[DEFAULT_SIZE];
            _hashFunc = hashFunc;            
        }

        public void Add(K key, V value)
        {
            var idx = NormalizeIdx(_hashFunc.Invoke(key));
            
            if(_storage[idx] is null)
            {
                _storage[idx] = new LinkedList<KeyValPair<K, V>>();
            }
            _storage[idx]!.Add(new KeyValPair<K, V>(key, value));
            Length++;

            if(LoadFactor > MAX_LOAD_FACTOR)
            {
                Expand();
            }
        }

        public bool Contains(K key)
        {
            if(key is null)
                throw new ArgumentNullException("Passed a null key");

            var idx = NormalizeIdx(_hashFunc.Invoke(key));

            if(_storage[idx] is null)
                return false;
    
            return _storage[idx]!.Contains(item => key.Equals(item.Key));
        }

        public V this[K key]
        {
            get 
            { 
                if(key is null)
                    throw new ArgumentNullException("Passed a null key");

                var idx = NormalizeIdx(_hashFunc.Invoke(key));

                if(_storage[idx] is null)
                    throw new KeyNotFoundException($"HashTable does not contain key: {key}");
                
                bool found;
                var pair = _storage[idx]!.Find(item => key.Equals(item.Key), out found);

                if(found) 
                    return pair.Value;
                
                throw new KeyNotFoundException($"HashTable does not contain key: {key}");
            }
        }

        public void Remove(K key)
        {
            if(key is null)
                throw new ArgumentNullException("Key is null");

            var idx = NormalizeIdx(_hashFunc.Invoke(key));

            if(_storage[idx] is null)
                throw new KeyNotFoundException($"HashTable does not contain key: {key}");
            
            bool removed = _storage[idx]!.Remove(pair => key.Equals(pair.Key));
            
            if(removed)
                Length--;
            else
                throw new KeyNotFoundException($"HashTable does not contain key: {key}");
                
        }

        public K?[] Keys()
        {
            DynArray<K> keys = new DynArray<K>();

            foreach (var bucket in _storage)
            {
                if(bucket is not null)
                {
                    foreach (var item in bucket)
                    {
                        keys.Add(item.Key);
                    }
                }
            }
            
            return keys.ToArray();
        }

        public V?[] Values()
        {
            DynArray<V> values = new DynArray<V>();

            foreach (var bucket in _storage)
            {
                if(bucket is not null)
                {
                    foreach (var item in bucket)
                    {
                        values.Add(item.Value);
                    }
                }
            }

            return values.ToArray();
        }

        public void Clear()
        {
            _storage = new LinkedList<KeyValPair<K, V>>[DEFAULT_SIZE];
            Length = 0;
        }

        private int NormalizeIdx(int hashCode)
        {
            return Math.Abs(hashCode) % _storage.Length;
        }

        private void Expand()
        {
            var old_storage = _storage;
            _storage = new LinkedList<KeyValPair<K, V>>[_storage.Length*2];
            Length = 0;

            foreach (var bucket in old_storage)
            {
                if(bucket is not null)
                {
                    foreach (var pair in bucket)
                    {
                        var (key, value) = pair;
                        Add(key, value);
                    }
                }
            }
        }
    }
}