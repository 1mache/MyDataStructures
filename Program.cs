namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            var dogList = new DynArray<Dog>(
                new Dog(12, "Gerald"),
                new Dog(3, "Petro"),
                new Dog(5, "Lalo"),
                new Dog(7, "Kartofel")
            );
            
            // bool found;
            // var dog = dogList.Find(d => d.Name.Equals("Laloo"), out found);
            
            // if(found)
            //     System.Console.WriteLine(dog.Age);
            // else
            //     System.Console.WriteLine("Not Found");
        }
    }
}