using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Services;

namespace PasswordManager.UI
{
    internal static class Menu
    {
        internal static void MainMenu(AccountRepository repo)
        {
            Console.WriteLine("Välkommen till lösenordshanteraren.");
            int userChoice = 0;
            int exitNumber = 4;
            while (userChoice != exitNumber)
            {
                Console.WriteLine("1 - Lägg till konto");
                Console.WriteLine("2 - Visa alla konton");
                Console.WriteLine("3 - Ta bort konto");
                Console.WriteLine("4 - Avsluta program");
                userChoice = InputManager.IntInput("Välj (1-4):", "Du måste skriva en siffra.");
                switch(userChoice)
                {
                    case 1:
                        Console.Clear();
                        repo.AddAccount();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        repo.ShowAccounts();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        repo.PublicDelete();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Programmet avslutas..");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
