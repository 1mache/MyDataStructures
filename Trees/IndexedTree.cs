namespace MyDataStructures;

class IndexedTree<T> : ITree<T>
{
    private const int MIN_ID=1000;

    private IndexedTreeNode<T>? _root;
    private HashTable<int, IndexedTreeNode<T>> _nodeTable;
    private int _nextIdx = MIN_ID;

    public int Count
    {
        get => _nodeTable.Length;
    }

    public IndexedTree()
    {   
        _nodeTable = new HashTable<int, IndexedTreeNode<T>>();
    }
    
    public void Add(int parentId, T value)
    {
        //executed first time
        if(_nodeTable.Length == 0)
        {
            _root = new IndexedTreeNode<T>(_nextIdx,value);
            _nodeTable.Add(_nextIdx,_root);
            _nextIdx ++;
            return;
        }

        //id validation
        if( (parentId > MIN_ID + _nodeTable.Length-1) || (parentId<0))
            throw new IndexOutOfRangeException("parentId is not valid");
        
        IndexedTreeNode<T> node = new IndexedTreeNode<T>(_nextIdx,value);

        if(!_nodeTable.Contains(parentId))
            throw new KeyNotFoundException("Tree does not contain a node with such id");

        if(_nodeTable[parentId] is null) 
            throw new Exception("parent node null");

        _nodeTable[parentId].AddChild(node);

        _nodeTable.Add(_nextIdx,node);
        _nextIdx++;
    }

    public ITreeNode<T>? GetRoot()
    {
        return _root;
    }
}