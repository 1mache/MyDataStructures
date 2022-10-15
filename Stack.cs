namespace MyDataStructures
{
    class Stack<T>
    {
        private LLNode<T> _head;
        
        public int Count = 0;

        public void Push(T element)
        {
            var node = new LLNode<T>();
            node.Value = element;

            if(_head is null)
            {
                _head = node;
            }
            else
            {
                node.Next = _head; 
                _head = node;
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
            else throw new InvalidOperationException("Stack empty");
        }

        public T Peek()
        {
            if(_head is not null) return _head.Value;
            else throw new InvalidOperationException("Stack empty");
        }

        public void Empty()
        {
            _head = null;
            Count = 0;
        }
    }
}