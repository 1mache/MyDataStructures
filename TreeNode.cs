namespace MyDataStructures;

class TreeNode<T>
{
    public T? Value{get; set;}
    public DynArray<TreeNode<T>>? Children { get; }

    public TreeNode(T? value)
    {
        Value = value;
        Children = new DynArray<TreeNode<T>>();
    }

    public TreeNode()
        :this(default(T))
    {}
}