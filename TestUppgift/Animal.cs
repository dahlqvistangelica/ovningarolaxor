using System;

public enum Species { Katt, Hund, Kanin, Marsvin, Guldfisk, Hamster, Papegoja, Gerbil, Okänt };
public class Animal
{
    private static int nextId;
    public int idNumb;
    public string Name { get; set; }
    public Species species { get; set; }
    public int Age { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; set; }

    public Animal(string name, Species animalSpecies, int age, double price, bool available)
    {
        nextId++;
        Name = name;
        idNumb = nextId;
        species = animalSpecies;
        Age = age;
        Price = price;
        IsAvailable = available;
    }
}
