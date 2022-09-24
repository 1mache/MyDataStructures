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

        public bool Remove(Predicate<T> predicate)
        {
            if(Count == 0) return false;
            if(predicate(_head.Value))
            {
                _head = _head.Next;
                Count--;
                return true;
            }
            
            var prev = _head;
            var node = _head.Next;
            while(node != null)
            {
                if(predicate(node.Value))
                {
                    prev.Next = node.Next;
                    Count--;
                    return true;
                }
                prev = node;
                node = node.Next;
            }

            return false;
        }

        public override string ToString()
        {
            var str = "[";

            foreach (var item in this)
            {
                str += item.ToString();
                str += " => ";
            }
            //removes the last " => "
            str = str.Remove(str.Length - 4);
            str+= "]";

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