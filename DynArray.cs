using System.Collections;
using System.Linq;

namespace MyDataStructures
{
    class DynArray<T> : IEnumerable<T>
    {
        private int _size = 2;
        private T[] _storage;

        public int Length { get; private set;} = 0;

        public DynArray()
        {
            _storage = new T[_size];
        }
        public DynArray(int size)
        {
            _storage = new T[size];
        }
        public DynArray(params T[] items)
        {
            _storage = new T[items.Length];
            Length = items.Length;

            items.CopyTo(_storage,0);
        }

        public T this[int index]
        {
            get
            {
                if(index > Length-1) 
                    throw new IndexOutOfRangeException();
                return _storage[index];
            }
            set
            {
                if(index > Length-1) 
                    throw new IndexOutOfRangeException();
                _storage[index] = value;
            }
        }

        public void Add(T item)
        {
            if(Length == _size)
            {
                var newStorage = new T[_size*2];
                for (int i = 0; i < _size; i++)
                {
                    newStorage[i] = _storage[i];
                }
                _storage = newStorage;
            }

            //Length value is always 1 more than last element's index.
            _storage[Length] = item; 
            Length++;
        }

        public T Find(Predicate<T> predicate, out bool found)
        {
            for (int i = 0; i < Length; i++)
            {
                if (predicate(_storage[i]))
                {
                    found = true;
                    return(_storage[i]); 
                }   
            }

            found = false;
            return default(T);
        }

        public bool Contains(T element)
        {
            bool found;
            Find(n => n.Equals(element), out found);

            return found;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if(_storage[i].Equals(item))
                    //Remove functiom
                    return true;
            }
            return false;  
        }

        public override string ToString()
        {
            string str = "[";
            for (int i = 0; i < Length; i++)
            {
                str += String.Format("{0},",_storage[i].ToString());
                
                if (i == Length-1)
                {
                    //Gets rid of the coma.
                    str  = str.Remove(str.Length -1);
                } 
            }
            str += "]";

            return str;   
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}