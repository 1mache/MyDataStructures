namespace MyDataStructures
{
    class PriorityQueue<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        BinaryHeap<PQNode<TPriority, TValue>>? _items;

        public void Enqueue(TPriority priority, TValue value)
        {
            if(_items is null)
                _items = new BinaryHeap<PQNode<TPriority, TValue>>(MinMax.MIN);

            _items.Insert(new PQNode<TPriority, TValue>(priority, value));
        }

        public TValue Dequeue()
        {
            if(_items is null)
                throw new InvalidOperationException("Queue is empty");
            return _items.Extract().Value;
        }
    }
}