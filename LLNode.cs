namespace MyDataStructures
{
    internal class LLNode<T>
    {
        private T _value;

        public LLNode<T> Next { get; set; }
        public T Value
        {
            get
            {
                return _value;
            }
            set 
            {
                _value = value;
                HasValue = true;
            }
        }
        public bool HasValue { get; private set; } = false;
    }
}