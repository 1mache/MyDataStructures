namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DynArray<LLNode<int>?>();
            list.Add(new LLNode<int>{Value = 3});
            list.Add(new LLNode<int>{Value = 5});
            list.Add(new LLNode<int>{Value = 6});
            list.Add(null);
            list.Add(new LLNode<int>{Value = 2});

            System.Console.WriteLine(list.ToString());
            list.Remove(null);
            System.Console.WriteLine(list.ToString());
        }
    }  
}