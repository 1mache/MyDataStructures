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

            bool found;
            var niganei = ll.Find(n => n == 0, out found);
            System.Console.WriteLine($"Find operation successful: {found}, found {niganei}");
        }
    }
}