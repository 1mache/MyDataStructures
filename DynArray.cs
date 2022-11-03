using System.Collections;

namespace MyDataStructures
{
    class DynArray<T> : IEnumerable<T>
    {
        //Actual capacity of internal array
        private int _capacity = 2;
        private T[] _storage;

        public int Length { get; private set;} = 0;

        public DynArray()
        {
            _storage = new T[_capacity];
        }
        public DynArray(params T[] items)
        {
            _storage = new T[items.Length];
            _capacity = items.Length;
            Length = _capacity;

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
            if(Length == _capacity)
            {
                _capacity = _capacity*2;
                var newStorage = new T[_capacity];
                
                _storage.CopyTo(newStorage, 0);
                _storage = newStorage;
            }

            //Length value is always 1 more than last element's index.
            _storage[Length] = item; 
            Length++;
        }

        public void AddRange(IEnumerable<T> range)
        {
            if(range is null)
                throw new ArgumentNullException();
            
            foreach (var item in range)
            {
                this.Add(item);
            }
        }

        public T Find(Predicate<T> predicate, out bool found)
        {

            foreach (var item in this)
            {
                if (predicate(item))
                {
                    found = true;
                    return(item); 
                }   
            }
            found = false;
            return default(T);
        }

        public int FindIndex(Predicate<T> predicate)
        {

            for (int i = 0; i < Length; i++)
            {
                if (predicate(_storage[i]))
                {
                    return(i); 
                }   
            }
            return -1;
        }

        public int FindIndex(T item)
        {
            return FindIndex(i => i.Equals(item));
        }

        public bool Contains(T element)
        {
            bool found;
            Find(n => n.Equals(element), out found);

            return found;
        }

        public void RemoveAt(int index)
        {
            if((index >= Length) || index<0)
                throw new IndexOutOfRangeException();
            
            Length--;
            Array.Copy(_storage, index+1, _storage, index, Length - index);
            _storage[Length] = default(T);
        }
        
        public bool Remove(T item)
        {
            var index = FindIndex(item);
            
            if(index == -1)
                return false;
            
            RemoveAt(index);
            return true;
        }

        public void Clear()
        {
            Length = 0;
            _capacity = 2;
            _storage = new T[_capacity];
        }

        public override string ToString()
        {
            string str = "[";
            for (int i = 0; i < Length; i++)
            {
                var item = _storage[i];

                if (item is null)
                {
                    str += "null,";
                }
                else
                {
                    str += $"{item.ToString()},";
                }
                
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