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
            var ht = new HashTable<string, int>();
            ht.Add("Dima", 19);
            ht.Add("Dimon", 29);
            ht.Add("Dlinnopop", 1);
            ht.Add("Mama", 45);
            ht.Add("Dobrre", 15);
            ht.Add("Vovma", 9);
            ht.Add("Bobaa", 99);
            ht.Add("Lalo", 89);
            ht.Add("Lily", 9);
            System.Console.WriteLine(ht["Dima"]);
        }
    }  
}