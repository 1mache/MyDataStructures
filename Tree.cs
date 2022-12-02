namespace MyDataStructures;

class Tree<T>
{
    private TreeNode<T>? _root;
    private HashTable<int, TreeNode<T>>? _nodeTable;
    private int _lastID = -1;

    public int Count
    {
        get => _lastID +1;
    }
    
    public void Add(int parentId, T value)
    {
        TreeNode<T>? node;

        if(parentId == -1 && _lastID == -1)
        {
            _root = new TreeNode<T>(value);
            node = _root;
            _nodeTable = new HashTable<int, TreeNode<T>>();
        }

        if(parentId > _lastID || parentId<0)
            throw new Exception("<temp>");
        
        node = new TreeNode<T>(value);
        _nodeTable![parentId].Children!.Add(node);

        _lastID++;
        _nodeTable!.Add(_lastID, node);
    }    
}