namespace MyDataStructures
{
    class BST<T> where T:IComparable<T>
    {
        private BSTNode<T> _root;

        public void Insert(T item)
        {
            var inserted = new BSTNode<T>();
            inserted.Value = item;

            if(_root is null)
            {
                _root = inserted;
                return; 
            }
            
            void internalInsert(BSTNode<T> node)
            {
                //item is smaller
                if(node.Value.CompareTo(item) == 1)
                {
                    if(node.Left is null)
                    {
                        node.Left = inserted;
                    }
                    else internalInsert(node.Left);
                }
                else
                {
                    if(node.Right is null)
                    {
                        node.Right = inserted;
                    }
                    else internalInsert(node.Right);
                }
            }

            internalInsert(_root);
        }
    }
}