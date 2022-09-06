namespace MyDataStructures{
    class Program
    {
        static void Main(string[] args)
        {
            // var dogList = new DynArray<Dog>(
            //     new Dog(12, "Gerald"),
            //     new Dog(3, "Petro"),
            //     new Dog(5, "Lalo"),
            //     new Dog(7, "Kartofel")
            // );
            
            var dogList = new DynArray<Dog>();

            dogList.Add(new Dog(13,"John"));
            System.Console.WriteLine(dogList.Length);
            dogList.Add(new Dog(14,"Joe"));
            System.Console.WriteLine(dogList.Length);
            dogList.Add(new Dog(3,"Ohn"));
            System.Console.WriteLine(dogList.Length);
            dogList.Add(new Dog(1,"Jon"));
            System.Console.WriteLine(dogList.Length);
            dogList.Add(new Dog(18,"Joh"));
            System.Console.WriteLine(dogList.Length);
            dogList.Add(new Dog(83,"Lebediah"));
            System.Console.WriteLine(dogList.Length);
        }
    }
}