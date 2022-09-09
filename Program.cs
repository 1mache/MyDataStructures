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

            foreach (var item in ll)
            {
                System.Console.WriteLine(item.ToString());
            }
        }
    }
}