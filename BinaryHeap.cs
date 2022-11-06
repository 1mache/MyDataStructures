namespace MyDataStructures
{
    enum MinMax 
    {
        MAX = 1,
        MIN = -1
    }

    class BinaryHeap<T> where T:IComparable<T>
    {
        private DynArray<T> _items;
        private MinMax _type;
        public int Length{get; private set;} = 0;

        public BinaryHeap(MinMax type)
        {
            //in all the comparisons the comparison sign is basically flipped
            //by multiplying by _type enum.
            _type = type;
            _items = new DynArray<T>();
        }

        public void Insert(T item)
        {
            if(item is null)
                throw new ArgumentNullException("Heap doesnt accept null");

            _items.Add(item);
            int itemId = _items.Length - 1;
            int parentId = ParentId(itemId);
            //while parent is smaller(in MAX)/ bigger(in MIN)
            while(item.CompareTo(_items[parentId]) * ((int)_type) > 0)
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

        public T Extract()
        {
            if(_items.Length == 0)
                throw new InvalidOperationException("Heap is empty");
            
            var max = _items[0];

            var temp = _items[_items.Length-1];
            _items.RemoveAt(_items.Length-1);
            _items[0] = temp;
            
            SinkDown(0);

            return max!;
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

            T compared = _items[startId]!;
            //if children are in range
            if(child1id < _items!.Length)
            {
                var child1 = _items[child1id];
                if(child2id < _items.Length)
                {
                    var child2 = _items[child2id]!;

                    if(compared.CompareTo(child1) * ((int)_type) < 0)
                    {
                        swapId = child1id;
                    }
                    if(compared.CompareTo(child2) * ((int)_type) < 0)
                    {
                        //if we did not initialize swapId meaning child1 is not bigger(MAX)/ not smaller(MIN) than subject
                        if(swapId == -1)
                        {
                            swapId = child2id;
                        }
                        //we initalized swapId meaning child1 is bigger(MAX)/smaller(MIN) than subject
                        else
                        {
                            //only if child2 is bigger(MAX)/smaller(MIN) we change the swapId, if not we should swap with child1
                            if(child2.CompareTo(child1) * ((int)_type) > 0) 
                                swapId = child2id; 
                        }
                    }
                }
                else
                {
                    if(compared.CompareTo(child1) * ((int)_type) < 0)
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