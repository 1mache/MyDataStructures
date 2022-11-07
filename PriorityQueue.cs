namespace MyDataStructures
{
    class PriorityQueue<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        BinaryHeap<PQNode<TPriority, TValue>>? _heap;

        public void Enqueue(TPriority priority, TValue value)
        {
            if(_heap is null)
                _heap = new BinaryHeap<PQNode<TPriority, TValue>>(MinMax.MIN);

            _heap.Insert(new PQNode<TPriority, TValue>(priority, value));
        }

        public TValue Dequeue()
        {
            if(_heap is null)
                throw new InvalidOperationException("Queue is empty");
            return _heap.Extract().Value;
        }

        public TValue Peek()
        {
            if(_heap is null)
                throw new InvalidOperationException("Queue is empty");
            return _heap.Head.Value;
        }
    }
}