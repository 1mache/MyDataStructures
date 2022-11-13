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
            var ht = new HashTable<string, int>(StringHash);
            ht.Add("Dima", 19);
            System.Console.WriteLine(ht["Mama"]);
        }
    }  
}