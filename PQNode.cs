namespace MyDataStructures
{
    internal class PQNode<TPriority,TValue> : IComparable<PQNode<TPriority,TValue>> where TPriority: IComparable<TPriority>
    {
        public TPriority Priority { get; }
        public TValue Value {get; set;}

        public PQNode(TPriority priority, TValue value)
        {
            Priority = priority;
            Value = value;
        }

        public int CompareTo(PQNode<TPriority, TValue>? other)
        {
            if(other is null)
                throw new ArgumentNullException();
            
            return this.Priority.CompareTo(other.Priority);
        }
    }
}