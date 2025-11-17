using KodaISal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodaISal.UI
{
    internal class Menu
    {
        /// <summary>
        /// Metod för huvudmenyn, tar emot Stockhandler för att kunna använda metoderna som finns där.
        /// </summary>
        /// <param name="handler"></param>
        public static void StartUpMenu(StockHandler handler)
        {
            int exitnumber = 6;
            int userChoice = 0;
            Console.WriteLine("VÄLKOMMEN TILL LAGERSYSTEMET.");
            while(userChoice != exitnumber)
            {
                Console.WriteLine("Tillgängliga val");
                Console.WriteLine("1 - Lägg till ny produkt");
                Console.WriteLine("2 - Ta bort produkt");
                Console.WriteLine("3 - Sök produkt");
                Console.WriteLine("4 - Ändra lagersaldo");
                Console.WriteLine("5 - Visa alla produkter");
                Console.WriteLine("6 - Avsluta programmet");
                userChoice = InputHandler.IntInput($"Ange val (1-{exitnumber}):", $"Du måste ange ett nummer mellan 1-{exitnumber}");
                switch(userChoice)
                {
                    case 1:
                        Console.Clear();
                        handler.AddProduct();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        handler.WantToDeleteProduct();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        handler.FindProduct();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        handler.ChangeStockCount();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("---- VISA ALLA PRODUKTER ----");
                        handler.ShowProducts();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("Programmet kommer nu avslutas.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
