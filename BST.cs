namespace MyDataStructures
{
    class BST<T> where T:IComparable<T>
    {
        private BSTNode<T> _root;

        public BST(T root)
        {
            _root = new BSTNode<T>();
            _root.Value = root;
        }

        public void Insert(T item)
        {
            var inserted = new BSTNode<T>();
            inserted.Value = item;
            
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