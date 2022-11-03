namespace MyDataStructures
{
    class MaxBinaryHeap<T> where T:IComparable<T>
    {
        private DynArray<T> _items;

        public void Insert(T item)
        {
            if(_items is null)
            {
                _items = new DynArray<T>(item);
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
        }

        public T[] ToArray()
        {
            return _items.ToArray();
        }
        
        //=============Aid methods=============
        
        //int is flooring by default 
        private int ParentId(int childId) => childId/2;
        private int FirstChildId(int parentId) => parentId*2 + 1; 
    }
}