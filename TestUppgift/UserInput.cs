using System;

public class UserInput
{
	public static string UserStringInput(string text, string errorMsg)
	{
		Console.Write(text);
        string input = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(errorMsg);
            input = Console.ReadLine();
        }
        return input;
    }
    public static double UserDoubleInput(string text, string errorMsg)
    {
        Console.Write(text);
        string input = Console.ReadLine();
        double result;
        while (!double.TryParse(input, out result))
        {
            Console.WriteLine(errorMsg);
            input = Console.ReadLine();
        }
        return result;
    }
    public static int UserIntInput(string text, string errorMsg)
    {
        Console.Write(text);
        string input = Console.ReadLine();
        int result;
        while (!int.TryParse(input, out result))
        {
            Console.WriteLine(errorMsg);
            input = Console.ReadLine();
        }
        return result;
    }
    public static int UserIntInput(string text, string errorMsg, int min, int max)
    {
        Console.Write(text);
        string input = Console.ReadLine();
        int result;
        while (!int.TryParse(input, out result))
        {
            if (result < min && result > max)
            {
                Console.WriteLine($"Siffran får inte vara högre än {max} och mindre än {min}");
            }
            Console.WriteLine(errorMsg);
            input = Console.ReadLine();
        }
        return result;
    }
    public static bool UserInputBool(string text, string errorMsg, string validOne, string validTwo)
    {
        Console.Write(text);
        string input = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(errorMsg);
            input = Console.ReadLine();
        }
        if (input.Equals(validOne))
            return true;
        if(input.Equals(validTwo))
            return false;
        return false;
    }
    public static Species UserSpeciesInput(string text, string errorMsg)
    {
        Console.WriteLine("Välj djurart med siffra:");
        Console.WriteLine("[1] Hund");
        Console.WriteLine("[2] Katt");
        Console.WriteLine("[3] Kanin");
        Console.WriteLine("[4] Marsvin");
        Console.WriteLine("[5] Hamster");
        Console.WriteLine("[6] Papegoja");
        Console.WriteLine("[7] Gerbil");
        Console.WriteLine("[8] Guldfisk");
        int userChoice = UserIntInput(text, errorMsg);
            return userChoice switch
            {
                1 => Species.Hund,
                2 => Species.Katt,
                3 => Species.Kanin,
                4 => Species.Marsvin,
                5 => Species.Hamster,
                6 => Species.Papegoja,
                7 => Species.Gerbil,
                8 => Species.Guldfisk,
                _ => Species.Okänt
            };
    }

}
