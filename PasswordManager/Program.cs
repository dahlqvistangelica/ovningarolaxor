namespace PasswordManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static class Menu
        {
            static void ShowMenu()
            {
                Console.WriteLine("Välkommen till lösenordshanteraren");
                Console.WriteLine("[1] Lägg till konto");
                Console.WriteLine("[2] Visa alla konton");
                Console.WriteLine("[3] Ta bort konto");
                Console.WriteLine("[4] Avsluta");
                int.TryParse(Console.ReadLine(), out int userChoice);
                while(userChoice != 4)
                {
                    switch (userChoice)
                    {
                        case 1: Console.WriteLine("Lägg till konto");
                            Console.ReadLine();
                            break;
                        case 2: Console.WriteLine("Visa alla konton");
                            Console.ReadLine();
                            break;
                        case 3: Console.WriteLine("Ta bort konto");
                            Console.ReadLine();
                            break;
                        case 4: Console.WriteLine("Programmet avslutas");
                            Console.ReadLine();
                            break;
                        default: Console.WriteLine("Ogiltigt val");
                            break;
                    }
                }
            }
        }
    }
}
