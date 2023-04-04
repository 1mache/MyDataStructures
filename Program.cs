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

        static string ArrayPrinter<T>(T[] arr)
        {
            var res = "";

            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i]!.ToString();
                if(i != (arr.Length-1))
                    res += ", ";
            }

            res+= ";";

            return res;
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

            // var graph = new Graph<string>();
            // graph.AddVertex("Ohio");
            // graph.AddVertex("North Carolina");
            // graph.AddVertex("NY");
            // graph.AddVertex("Florida");
            // graph.AddEdge("NY", "Ohio");
            // graph.AddEdge("NY", "North Carolina");
            // graph.AddEdge("Ohio", "Florida");
            // graph.AddEdge("Florida", "North Carolina");
            // System.Console.WriteLine(graph.ToString());

            // System.Console.WriteLine(ArrayPrinter(graph.DepthFirstTraversal()));
            // System.Console.WriteLine(ArrayPrinter(graph.BreathFirstTraversal()));

            var weightedGraph = new WeightedGraph<string>();
            weightedGraph.AddVertex("TLV");
            weightedGraph.AddVertex("RLZ");
            weightedGraph.AddVertex("PT");
            weightedGraph.AddVertex("NTN");
            weightedGraph.AddVertex("HF");
            
            weightedGraph.AddEdge("TLV", "PT", 10);
            weightedGraph.AddEdge("PT", "NTN", 30);
            weightedGraph.AddEdge("TLV", "RLZ", 15);
            weightedGraph.AddEdge("PT", "RLZ", 25);
            weightedGraph.AddEdge("HF", "RLZ", 40);
            weightedGraph.AddEdge("NTN", "HF", 30);

            System.Console.WriteLine(weightedGraph.ToString());
            System.Console.WriteLine(weightedGraph.DijkstrasShortest("TLV", "HF"));
        }
    }  
}