namespace MyDataStructures;

class IndexedTreeNode<T> : ITreeNode<T>
{
    public T? Value{get; set;}
    private DynArray<IndexedTreeNode<T>> _children { get; }

    public IndexedTreeNode(T? value)
    {
        Value = value;
        _children = new DynArray<IndexedTreeNode<T>>();
    }

    public IndexedTreeNode()
        :this(default(T))
    {}

    public void AddChild(IndexedTreeNode<T> child)
    {
        if(child is null)
            throw new ArgumentNullException();
        _children.Add(child);
    }

    public ITreeNode<T>[] GetChildren()
    {
        return _children.ToArray()!;
    }
}