namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var ll = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                ll.Add(i);
            }

            bool removed = ll.Remove(n => n==5);
            System.Console.WriteLine(removed);
            System.Console.WriteLine(ll.ToString());
        }
    }
}