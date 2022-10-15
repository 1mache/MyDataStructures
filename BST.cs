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
            
            //recursive internal function which takes a node and tries to insert the item as 
            //one of the children, if place is occupied moves down to the child that occupies the place.
            //could be done with a while loop
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

        public BSTNode<T> GetNode(T value)
        {
            //could be done with a recursive internal function as well but now
            //Ill use a while loop :)
            var node = _root;
            while (node is not null)
            {
                //equals
                if(node.Value.CompareTo(value) == 0) return node;
                //value is smaller
                else if(node.Value.CompareTo(value) == 1)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return null;
        }
    }
}