namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            // var list = new DynArray<int>();
            // list.Add(1);
            // list.Add(2);
            // list.Add(3);

            // System.Console.WriteLine(list.ToString());

            var listModel = new List<int>();
            listModel.Add(1);

            listModel.Remove(2);
        }
    }
}