namespace MyDataStructures
{
    class Stack<T>
    {
        private readonly DynArray<T> _storage;

        public int Count { 
            get
            {
                return _storage.Length;
            } 
        }

        public Stack()
        {
            _storage = new DynArray<T>();
        }

        public Stack(int capacity)
        {
            _storage = new DynArray<T>(capacity);
        }

        public void Push(T item)
        {
            _storage.Add(item);
        }

        public T Pop()
        {
            var item = _storage[Count-1];
            _storage.RemoveAt(Count-1);

            return item;
        }

        public T Peek()
        {
            return _storage[Count-1];
        }

        public void Empty()
        {
            _storage.Clear();
        }
    }
}