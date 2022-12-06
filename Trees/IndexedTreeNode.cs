namespace MyDataStructures;

class IndexedTreeNode<T> : ITreeNode<T>
{
    public T? Value{get; set;}
    public int Idx{get;}
    private DynArray<IndexedTreeNode<T>> _children { get; }

    public IndexedTreeNode(int id, T? value)
    {
        Idx = id;
        Value = value;
        _children = new DynArray<IndexedTreeNode<T>>();
    }

    public IndexedTreeNode(int id)
        :this(id,default(T))
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