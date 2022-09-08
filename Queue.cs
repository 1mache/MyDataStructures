namespace MyDataStructures
{
    class Queue<T>
    {
        private readonly DynArray<T> _storage;

        public int Count { 
            get
            {
                return _storage.Length;
            } 
        }

        public Queue()
        {
            _storage = new DynArray<T>();
        }

        public Queue(int capacity)
        {
            _storage = new DynArray<T>(capacity);
        }

        public void Enqueue(T item)
        {
            _storage.Add(item);
        }

        public T Dequeue()
        {
            var item = _storage[0];
            _storage.RemoveAt(0);

            return item;
        }

        public T Peek()
        {
            return _storage[0];
        }

        public void Empty()
        {
            _storage.Clear();
        }
    }
}