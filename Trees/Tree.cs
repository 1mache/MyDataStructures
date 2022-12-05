namespace MyDataStructures;

class Tree<T>
{
    private TreeNode<T>? _root;
    private DynArray<TreeNode<T>> _nodeList;

    public int Count
    {
        get => _nodeList.Length;
    }

    public Tree()
    {   
        _nodeList = new DynArray<TreeNode<T>>();
    }
    
    public void Add(int parentId, T value)
    {
        TreeNode<T>? node;

        //id validation
        if(parentId == -1 && _nodeList.Length == 0)
        {
            _root = new TreeNode<T>(value);
            node = _root;
        }

        if(parentId > _nodeList.Length-1 || parentId<0)
            throw new Exception("<temp>");
        
        node = new TreeNode<T>(value);
        //Temp
        if(_nodeList[parentId] is null) 
            throw new Exception("parent node null");
        //Temp
        _nodeList[parentId]!.Children!.Add(node);

        _nodeList!.Add(node);
    }    
}