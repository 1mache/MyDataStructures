namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BST<int>();
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(10);

            System.Console.WriteLine("Done");
        }
    }  
}