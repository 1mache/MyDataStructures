namespace MyDataStructures
{
    class Queue<T>
    {
        private LLNode<T> _head;
        private LLNode<T> _last;
        
        public int Count = 0;

        public void Push(T element)
        {
            var node = new LLNode<T>();
            node.Value = element;

            if(_head is null)
            {
                _head = node;
                _last = _head;
            }
            else
            {
                _last.Next = node;
                _last = _last.Next;
            }

            Count++;
        }

        public T Pop()
        {
            if(_head is not null)
            {
                var oldHead = _head;
                _head = _head.Next;
                Count--;
                return oldHead.Value;
            }
            else throw new InvalidOperationException("Queue empty");
        }

        public T Peek()
        {
            if(_head is not null) return _head.Value;
            else throw new InvalidOperationException("Queue empty");
        }

        public void Empty()
        {
            _head = null;
            Count = 0;
        }
    }
}