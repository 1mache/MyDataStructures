namespace MyDataStructures
{
    internal class BSTNode<T> where T: IComparable<T>
    {
        public T Value {get; set;}
        public BSTNode<T>? Left {get; set;} 
        public BSTNode<T>? Right {get; set;}

        public BSTNode(T value)
        {
            Value = value;
        }
    }
}