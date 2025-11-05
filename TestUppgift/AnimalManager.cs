using System;
using TestUppgift;

public static class AnimalManager
{
	public static Animal GetAnimal()
	{
		string name = UserInput.UserStringInput("Skriv in djurets namn: ", "Ogiligt namn, prova igen.");
		Species species = UserInput.UserSpeciesInput($"Vilken art är {name} (1-8): ", "Ogiltig inmatning, prova igen.");
		int age = UserInput.UserIntInput($"Skriv in {name}s ålder: ", "Ogiltig inmatning, prova igen.", 0, 25);
		double price = UserInput.UserDoubleInput($"Ange pris för {name}: ", "Ogilgig inmatning, prova igen");
		bool available = UserInput.UserInputBool($"Är {name} till salu nu? (ja/nej)", "Ogiltigt inmatning, prova igen", "ja", "nej");
		return new Animal(name, species, age, price, available);
    }
    public static void ShowAnimalsBig(List<Animal> animals)
    {
        if (animals.Count <= 0)
        {
            Console.WriteLine("Inga djur att visa.");
            Console.ReadLine();
        }
        else
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(AnimalManager.ShowSingleAnimal(animal));
                Console.WriteLine("-----------------------------------");

            }
        }
    }
    public static void ShowAnimalsShort(List<Animal> animals)
    {
        foreach (Animal animal in animals)
        { Console.WriteLine(AnimalManager.ShowShortSingleAnimal(animal)); }
    }
    public static string ShowSingleAnimal(Animal animal)
    {
        return $"Id: {animal.idNumb,3}\nNamn: {animal.Name} \nArt: {animal.species.ToString()}\nÅlder: {animal.Age,-5}\nPris: {animal.Price:F2}\nTill salu: {animal.IsAvailable}";
    }
    public static string ShowShortSingleAnimal(Animal animal)
    {
        return $"Id: {animal.idNumb,3} Namn: {animal.Name} Art: {animal.species.ToString()}";
    }
  
    public static Animal ChangeAnimal(Animal animal)
    {
        Console.Clear();
        Console.WriteLine("[1] Namn");
        Console.WriteLine("[2] Ålder");
        Console.WriteLine("[3] Art");
        Console.WriteLine("[4] Pris");
        int choice = UserInput.UserIntInput("Vad vill du ändra (1-4): ", "Ogiltig inmatning försök igen.");
        switch (choice)
        {
            case 1:
                string changename = UserInput.UserStringInput("Skriv in djurets namn: ", "Ogiligt namn, prova igen.");
                animal.Name = changename;
                break;
            case 2:
                int age = UserInput.UserIntInput($"Skriv in {animal.Name}s ålder: ", "Ogiltig inmatning, prova igen.", 0, 25);
                animal.Age = age;
                break;
            case 3:
                Species species = UserInput.UserSpeciesInput($"Vilken art är {animal.Name} (1-8): ", "Ogiltig inmatning, prova igen.");
                animal.species = species;
                break;
            case 4:
                double price = UserInput.UserDoubleInput($"Ange pris för {animal.Name}: ", "Ogilgig inmatning, prova igen");
                animal.Price = price;
                    break;
            default:
                Console.WriteLine("Ogiltigt val");
                break;
        }
        return animal;

    }

    public static void FindAnimal(List<Animal> animals)
    { Console.Clear();
        Console.WriteLine("Sök efter djur");
        Console.WriteLine("[1] Sök utifrån namn");
        Console.WriteLine("[2] Sök utifrån art");
        Console.WriteLine("[3] Sök utifrån maxpris");
        Console.WriteLine("[4] Backa");
        int searchChoice = UserInput.UserIntInput("Vad vill du söka efter (1-3): ", "Ogiltig inmatning, försök igen.");
        while(searchChoice != 4)
        {
            switch(searchChoice)
            {
                case 1:
                    Console.Clear();
                    string searchName = UserInput.UserStringInput("Vilket namn vill du söka på?", "Du måste skriva något");
                    searchName.ToLower();
                    List<Animal> foundAnimalsName = new List<Animal>();
                    foreach(Animal animal in animals)
                    {
                        if(animal.Name.ToLower().Equals(searchName))
                        {
                            foundAnimalsName.Add(animal);
                        }
                    }
                    if(foundAnimalsName.Count == 0)
                    {
                        Console.WriteLine("Inga djur hittades.");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Hittade dessa på din sökning av {searchName}");
                        ShowAnimalsShort(foundAnimalsName);
                        Console.ReadLine();
                        return;
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Species searchSpecies = UserInput.UserSpeciesInput("Vilken art vill du söka på?", "Du måste skriva något");
                    List<Animal> foundAnimalsSpecies = new List<Animal>();
                    foreach (Animal animal in animals)
                    {
                        if (animal.species.Equals(searchSpecies))
                        {
                            foundAnimalsSpecies.Add(animal);
                        }
                    }
                    if (foundAnimalsSpecies.Count == 0)
                    {
                        Console.WriteLine("Inga djur hittades.");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Hittade dessa på din sökning av {searchSpecies}");
                        ShowAnimalsShort(foundAnimalsSpecies);
                        Console.ReadLine();
                        return;
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    double searchprice = UserInput.UserDoubleInput("Maxpris på djur du vill visa? ", "Du måste skriva något");
                    List<Animal> foundAnimalsPrice = new List<Animal>();
                    foreach (Animal animal in animals)
                    {
                        if (animal.Price < searchprice)
                        {
                            foundAnimalsPrice.Add(animal);
                        }
                    }
                    if (foundAnimalsPrice.Count == 0)
                    {
                        Console.WriteLine("Inga djur hittades.");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Dessa djur kostar mindre än {searchprice}");
                        ShowAnimalsShort(foundAnimalsPrice);
                        Console.ReadLine();
                        return;
                    }
                    Console.ReadLine();
                    break;
                case 4:
                    return;
            }
        }
        
    }
}
