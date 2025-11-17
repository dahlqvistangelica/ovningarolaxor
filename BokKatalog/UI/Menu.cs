using BokKatalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokKatalog.UI
{
    internal static class Menu
    {
        internal static void ShowMenu(BookCatalog catalog)
        {
            Console.WriteLine("Välkommen till bokkatalogen.");
            int input = 0;
            int exitnumb = 7;
            while (input != exitnumb)
            {
                
                Console.WriteLine("1 - Lägg till bok");
                Console.WriteLine("2 - Ta bort bok");
                Console.WriteLine("3 - Ändra bok");
                Console.WriteLine("4 - Såld bok");
                Console.WriteLine("5 - Visa alla böcker");
                Console.WriteLine("6 - Sök efter bok/böcker");
                Console.WriteLine("7 - Avsluta programmet");
                input = UserInputHandler.intInput("Gör ett val (1-7):", "Ogiltigt val, prova igen.");
                switch(input)
                {
                    case 1:catalog.AddBook();
                        Console.Clear();
                        break;
                    case 2:catalog.DeleteBook();
                        Console.Clear();
                        break;
                    case 3:catalog.UpdateBook();
                        Console.Clear();
                        break;
                    case 4:catalog.SellBook();
                        Console.Clear();
                        break;
                    case 5: Console.Clear();
                        catalog.ShowBooks();
                        Console.Clear();
                        break;
                    case 6: catalog.BookSearch();
                        Console.Clear();
                        break;
                    case 7: Console.WriteLine("Programmet kommer avslutas.");
                        Console.ReadLine();
                        break;
                    default: Console.WriteLine("Ogiltigt val, prova igen.");
                        break;
                }
            }
        }
    }
}
