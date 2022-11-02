namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BST<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(12);
            tree.Insert(4);
            tree.Insert(7);
            foreach (var item in tree.InOrder())
            {
                System.Console.WriteLine(item);
            }
        }
    }  
}