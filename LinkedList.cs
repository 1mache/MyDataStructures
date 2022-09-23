using System.Collections;

namespace MyDataStructures
{
    class LinkedList<T> : IEnumerable<T>
    {
        private LLNode<T> _head;
        private LLNode<T> _last;
        
        public int Count { get; private set;} = 0;

        public LinkedList()
        {
            _head = new LLNode<T>();
            _last = _head;
        }

        public T this[int index]
        {
            get 
            { 
                if(index >= Count)
                    throw new IndexOutOfRangeException();
                
                var node = _head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public void Add(T item)
        {
            if(_head.HasValue)
            {
                _last.Next = new LLNode<T>();
                _last = _last.Next;
                _last.Value = item;
            }
            //if adding first time
            else
            {
                _head.Value = item;
            }

            Count++;
        }

        public T Find(Predicate<T> predicate, out bool found)
        {
            var node = _head;
            for (int i = 0; i < Count; i++)
            {
                if (predicate(node.Value))
                {
                    found = true;
                    return node.Value;
                }

                node = node.Next;
            }

            found = false;
            return default(T);
        }

        public override string ToString()
        {
            var str = "";
            return str;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            for (int i = 0; i < Count; i++)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}