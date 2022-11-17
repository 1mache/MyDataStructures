namespace MyDataStructures{
    class Program
    {
        static int StringHash(string str)
        {
            int total = 0;
            foreach (var chr in str)
            {
                total += (int)chr;
            }

            return total * str.Length * 13;
        }
        static void Main(string[] args)
        {
            // var ht = new HashTable<string, int>();
            // ht.Add("Dima", 19);
            // ht.Add("Dimon", 29);
            // ht.Add("Dlinnopop", 1);
            // ht.Add("Mama", 45);
            // ht.Add("Dobrre", 15);
            // ht.Add("Vovma", 9);
            // ht.Add("Bobaa", 99);
            // ht.Add("Lalo", 89);
            // ht.Add("Lily", 9);
            // ht.Remove("Mama");
            // System.Console.WriteLine(ht["Lalo"]);
            // System.Console.WriteLine(ht.Contains("Mama"));
            // ht.Keys();
            // ht.Values();

            var graph = new Graph<string>();
            graph.AddVertex("Ohio");
            graph.AddVertex("North Carolina");
            graph.AddVertex("NY");
            graph.AddVertex("Florida");
            graph.AddEdge("NY", "Ohio");
            graph.AddEdge("Ohio", "Florida");
            graph.RemoveVertex("NY");
            System.Console.WriteLine(graph.ToString());

        }
    }  
}