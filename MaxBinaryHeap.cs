namespace MyDataStructures
{
    class MaxBinaryHeap<T> where T:IComparable<T>
    {
        private DynArray<T>? _items;
        public int Length{get; private set;} = 0;

        public void Insert(T item)
        {
            if(item is null)
                throw new ArgumentNullException("Heap doesnt accept null");

            if(_items is null)
            {
                _items = new DynArray<T>(item);
                Length++;
                return;
            }

            _items.Add(item);
            int itemId = _items.Length - 1;
            int parentId = ParentId(itemId);
            //while parent is smaller 
            while(item.CompareTo(_items[parentId]) > 0)
            {
                //swapping value with parent
                var temp = _items[parentId];
                _items[parentId] = _items[itemId];
                _items[itemId] = temp;
                
                //updating index
                itemId = parentId;
                parentId = ParentId(itemId);
            }
            Length++;
        }

        public T ExtractMax()
        {
            if(_items is null)
                throw new InvalidOperationException();
            
            var max = _items[0];

            var temp = _items[_items.Length-1];
            _items.RemoveAt(_items.Length-1);
            _items[0] = temp;
            
            SinkDown(0);

            return max!;
        }

        public T[] ToArray()
        {
            if(_items is not null)
                return _items.ToArray()!;
            return new T[0];
        }
        
        //=============Aid methods=============
        
        //int is flooring by default 
        private int ParentId(int childId) => (childId-1)/2;
        private int FirstChildId(int parentId) => parentId*2 + 1; 
        private void SinkDown(int startId)
        {
            //id of what we are going to swap with
            int swapId = -1;
            int child1id = FirstChildId(startId), child2id = child1id + 1;

            T compared = _items![startId]!;
            //if children are in range
            if(child1id < _items!.Length)
            {
                var child1 = _items[child1id];
                if(child2id < _items.Length)
                {
                    var child2 = _items[child2id]!;

                    if(compared.CompareTo(child1) < 0)
                    {
                        swapId = child1id;
                    }
                    if(compared.CompareTo(child2) < 0)
                    {
                        //if we did not initialize swapId meaning child1 is not bigger than subject
                        if(swapId == -1)
                        {
                            swapId = child2id;
                        }
                        //we initalized swapId meaning child1 is bigger than subject
                        else
                        {
                            //only if child2 is bigger we change the swapId, if not we should swap with child1
                            if(child2.CompareTo(child1) > 0) 
                                swapId = child2id; 
                        }
                    }
                }
                else
                {
                    if(compared.CompareTo(child1) < 0)
                        swapId = child1id;
                }
            }

            if(swapId != -1)
            {
                _items[startId] = _items[swapId];
                _items[swapId] = compared;
                SinkDown(swapId);
            }
        }
    }
}