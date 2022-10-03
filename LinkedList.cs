using System.Collections;

namespace MyDataStructures
{
    class LinkedList<T> : IEnumerable<T>
    {
        private LLNode<T> _head;
        private LLNode<T> _tail;
        
        public int Count { get; private set;} = 0;

        public LinkedList()
        {
            _head = new LLNode<T>();
            _tail = _head;
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
            if(Count>0)
            {
                _tail.Next = new LLNode<T>();
                _tail = _tail.Next;
                _tail.Value = item;
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
                    if (node == _tail)
                        _tail = prev;
                    return true;
                }
                prev = node;
                node = node.Next;
            }

            return false;
        }

        public void Insert(int id, T item)
        {
            if(id > Count-1 || id < 0)
                throw new IndexOutOfRangeException();

            if(id == 0)
            {
                var temp = _head;
                _head = new LLNode<T>();
                _head.Value = item;
                _head.Next = temp;

                Count++;
            }

            var node = _head;
            for (int i = 0; i < id; i++)
            {
                if(i == id-1)
                {
                    var temp = node.Next;
                    node.Next = new LLNode<T>();
                    node.Next.Value = item;
                    node.Next.Next = temp;

                    Count++;
                }

                node = node.Next;
            }
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