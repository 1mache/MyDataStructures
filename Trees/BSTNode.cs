namespace MyDataStructures
{
    internal class BSTNode<T> : ITreeNode<T> where T: IComparable<T>
    {
        public T? Value {get; set;}
        public BSTNode<T>? Left {get; set;} 
        public BSTNode<T>? Right {get; set;}

        public BSTNode(T value)
        {
            Value = value;
        }

        public ITreeNode<T>[] GetChildren()
        {
            var list = new DynArray<BSTNode<T>?>();
            if(Left is not null)
                list.Add(Left);
            if(Right is not null)
                list.Add(Right);

            return list.ToArray()!;
        }
    }
}