using System.Collections.Generic;

namespace TestUppgift
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            int userChoice;
            do
            {
            Console.WriteLine("Välkommen! \n Var god välj vad du vill göra: ");
            Console.WriteLine("[1] Lägg till djur");
            Console.WriteLine("[2] Visa alla djur");
            Console.WriteLine("[3] Ta bort djur");
            Console.WriteLine("[4] Uppdatera info");
            Console.WriteLine("[5] Sök efter djur");
            Console.WriteLine("[6] Avsluta programmet.");

            int.TryParse(Console.ReadLine(), out userChoice);
            
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Lägg till djur");
                        animals.Add(AnimalManager.GetAnimal());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Visa alla djur");
                        AnimalManager.ShowAnimalsBig(animals);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Ta bort djur");
                        AnimalManager.ShowAnimalsShort(animals);
                        Console.WriteLine();
                        int deleteAnimalId = UserInput.UserIntInput("Ange ID på djuret du vill ta bort: ", "Ogiltigt id, försök igen.", -1, animals.Count);
                        int animaltoRemoveIndex = animals.FindIndex(a => a.idNumb == deleteAnimalId);
                        if(animaltoRemoveIndex != null)
                        {
                            animals.RemoveAt(animaltoRemoveIndex);
                            Console.WriteLine("Djuret borttaget");
                        }
                        else
                            Console.WriteLine("Djuret hittades inte. Återgår till huvudmenyn.");
                            Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Uppdatera djur");
                        Console.WriteLine();
                        AnimalManager.ShowAnimalsShort(animals);
                        int editAnimalId = UserInput.UserIntInput("Ange ID på djuret du vill ändra: ", "Ogiltigt id, försök igen.", -1, animals.Count);
                        int animalToEditIndex = animals.FindIndex(a => a.idNumb == editAnimalId);
                        if(animalToEditIndex != null)
                        {
                            Animal tempAnimal = AnimalManager.ChangeAnimal(animals[animalToEditIndex]);
                            animals[animalToEditIndex] = tempAnimal;
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Sök efter djur");
                        AnimalManager.FindAnimal(animals);
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Programmet avslutas");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen");
                        break;
                }
            } while (userChoice != 6);

        }
        
    }
}
