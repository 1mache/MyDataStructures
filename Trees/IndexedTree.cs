namespace MyDataStructures;

class IndexedTree<T> : ITree<T>
{
    private IndexedTreeNode<T>? _root;
    private DynArray<IndexedTreeNode<T>> _nodeList;

    public int Count
    {
        get => _nodeList.Length;
    }

    public IndexedTree()
    {   
        _nodeList = new DynArray<IndexedTreeNode<T>>();
    }
    
    public void Add(int parentId, T value)
    {

        //id validation
        if(parentId == -1 && _nodeList.Length == 0)
        {
            _root = new IndexedTreeNode<T>(value);
            _nodeList.Add(_root);
            return;
        }
        else if(parentId > _nodeList.Length-1 || parentId<0)
            throw new Exception("<temp>");
        
        IndexedTreeNode<T> node = new IndexedTreeNode<T>(value);
        //Temp
        if(_nodeList[parentId] is null) 
            throw new Exception("parent node null");
        //Temp
        _nodeList[parentId]!.AddChild(node);

        _nodeList!.Add(node);
    }

    public ITreeNode<T>? GetRoot()
    {
        return _root;
    }
}