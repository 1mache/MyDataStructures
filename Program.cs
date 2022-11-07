namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<int, string>();
            //Dima, Mamba, Nikita, Jeka, Jamal
            queue.Enqueue(4, "Jeka");
            queue.Enqueue(2, "Mamba");
            queue.Enqueue(3, "Jamal");
            queue.Enqueue(2, "Nikita");
            queue.Enqueue(0, "Dima");

            while(true)
            {
                try
                {
                    System.Console.WriteLine(queue.Dequeue());
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
        }
    }  
}