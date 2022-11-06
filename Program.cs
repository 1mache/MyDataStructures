namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new BinaryHeap<int>(MinMax.MIN);
            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(2);
            heap.Insert(4);
            heap.Insert(1);
            heap.Insert(6);
            heap.Insert(7);
            System.Console.WriteLine($"Max is: {heap.Extract()}");

            System.Console.WriteLine($"Max is: {heap.Extract()}");

            System.Console.WriteLine($"Max is: {heap.Extract()}");
        }
    }  
}