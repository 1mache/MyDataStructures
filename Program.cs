namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DynArray<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool found;
            System.Console.WriteLine(list.Find(n => n>2, out found));

            //var listModel = new List<int>();
        }
    }
}