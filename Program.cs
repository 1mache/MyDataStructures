namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var ll = new LinkedList<int>();
            ll.Add(0);
            ll.Add(1);
            ll.Add(2);
            ll.Add(3);
            ll.Add(4);
            ll.Add(5);

            ll.Pop();
            System.Console.WriteLine(ll.ToString());
        }
    }
}