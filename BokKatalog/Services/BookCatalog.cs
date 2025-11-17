using BokKatalog.Metods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokKatalog.Services
{
    internal class BookCatalog
    {
        private List<Book> books;

        public BookCatalog()
        {
            books = new List<Book>
            {
                new Book("32421233", "Den gröna milen", "Ingen aning", 1978, 320, 10),
                new Book("32211509", "Odla blommor", "Hanna Widlöf", 2020, 540, 10),
                new Book("12232434", "Forth Wing", "Rebecca Yarros", 2021, 430, 10),
                new Book("22211000", "Iron Flame", "Rebecca Yarros", 2023, 400, 10)
            }
               ;
        }
        internal void ShowBooks()
        {
            if(books.Count > 0)
            {
                Console.WriteLine("Tillgängliga böcker");
                foreach(Book book in books)
                {
                    Console.WriteLine(book.ToString());
                }
                
            }
            else
            {
                Console.WriteLine("Katalogen innehåller inga böcker.");
            }
            Console.ReadLine();
        }
        internal void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Lägg till ny bok");
            Console.WriteLine();
            string isbn = UserInputHandler.StringInput("Ange ISBN:", "Ogiltigt ISBN, försök igen.", 4);
            while(books.Exists(b => b.OpenISBN == isbn))
            {
                Console.WriteLine("ISBN finns redan och kan inte vara likadant som för en annan bok. Prova igen");
                isbn = UserInputHandler.StringInput("Ange ISBN:", "Ogiltigt ISBN, försök igen.", 4);
            }
            string title = UserInputHandler.StringInput("Ange bokens titel:", "Ogiltig titel, försök igen.");
            string author = UserInputHandler.StringInput("Ange författare:", "Du måste ha både för och efternamn på författaren", ' ');
            int pubYear = UserInputHandler.intInput("Ange utgivningsår:", "Du måste ange ett helt årtal (YYYY).", 4);
            decimal price = UserInputHandler.decimalInput("Ange pris:", "Du kan bara skriva siffor.");
            int stock = UserInputHandler.intInput("Ange lagerantal:", "Du kan bara skriva siffor.");
            Book book  = new Book(isbn, title, author, pubYear, price, stock);
            books.Add(book);
            Console.WriteLine($"{book.Title} tillagd i katalogen.");
            Console.ReadLine();
        }
        
        internal void DeleteBook()
        {
            Console.Clear();
            Console.WriteLine("Ta bort bok från katalogen");
            ShowBooks();
            Console.WriteLine();
            string bookchoice = UserInputHandler.StringInput("Ange ISBN på boken du vill ta bort:", "Ogiltigt ISBN.", 4);
            var chosenBook = books.FirstOrDefault(b => b.OpenISBN.Equals(bookchoice));
            if (books.Remove(chosenBook))
            { Console.WriteLine("Boken borttagen."); }
            else
            {
                Console.WriteLine("Boken kunde inte tas bort. Kontrollera att ISBN stämmer.");
            }
            Console.ReadLine();
            
        }
        internal void UpdateBook()
        {
            Console.Clear();
            Console.WriteLine("Ändra information om bok");
            ShowBooks();
            string bookchoice = UserInputHandler.StringInput("Ange ISBN på boken du vill ändra:", "Ogiltigt ISBN.", 4);
            var chosenBook = books.FirstOrDefault(b => b.OpenISBN.Equals(bookchoice));
            Console.Clear();
            Console.WriteLine("Vald bok:");
            Console.WriteLine(chosenBook.ToString());
            Console.WriteLine("Vad vill du ändra:");
            Console.WriteLine("1 - Titel");
            Console.WriteLine("2 - Författare");
            Console.WriteLine("3 - Publikationsår");
            Console.WriteLine("4 - Pris");
            Console.WriteLine("5 - Lagerantal");
            int userChoice = UserInputHandler.intInput("Välj ett alternativ 1-5:", "Ogiltigt val, försök igen.");
            switch(userChoice)
            {
                case 1:
                    string newTitle = UserInputHandler.StringInput("Skriv in ny titel:", "Du måste skriva en ny titel.");
                    chosenBook.Title = newTitle;
                    Console.WriteLine("Titel uppdaterades");
                    Console.ReadLine();
                    break;
                case 2:
                    string newAuthor = UserInputHandler.StringInput("Skriv in ny författare:", "Du måste skriva en ny författare med för och efternamn.", ' ');
                    chosenBook.Author = newAuthor;
                    Console.WriteLine("Författare uppdaterades");
                    Console.ReadLine();
                    break;
                case 3:
                    int newYear = UserInputHandler.intInput("Skriv in nytt publiceringsår:", "Du måste ange år med 4 siffror.", 4);
                    chosenBook.PublicationYear = newYear;
                    Console.WriteLine("Publikationsår uppdaterades");
                    Console.ReadLine();
                    break;
                case 4:
                    decimal newPrice = UserInputHandler.decimalInput("Skriv in nytt pris:", "Du måste pris med siffor.");
                    chosenBook.Price = newPrice;
                    Console.WriteLine("Pris uppdaterades");
                    Console.ReadLine();
                    break;
                case 5:
                    int newStock = UserInputHandler.intInput("Skriv in lagerantal:", "Du måste ange antal med siffor.");
                    chosenBook.StockCount = newStock;
                    Console.WriteLine("Lagerantal uppdaterades");
                    Console.ReadLine();
                    break;
                default: Console.WriteLine("Okänt val, återvänder till huvudmenyn.");
                    Console.ReadLine();
                     return;
            }
        }
        internal void SellBook()
        {
            Console.Clear();
            ShowBooks();
            string bookchoice = UserInputHandler.StringInput("Ange ISBN på boken du sålt:", "Ogiltigt ISBN.", 4);
            var chosenBook = books.FirstOrDefault(b => b.OpenISBN.Equals(bookchoice));
            Console.WriteLine("Såld bok:");
            Console.WriteLine(chosenBook.ToString());
            int soldAmount = UserInputHandler.intInput("Hur många ex har du sålt:", "Du måste ange antal med siffor");
            chosenBook.StockCount -= soldAmount;
            Console.WriteLine($"{soldAmount} har tagit borts från lagersaldot för bok \"{chosenBook.Title}\"");
            Console.ReadLine();
            
        }
        internal void BookSearch()
        {
            Console.Clear();
            Console.WriteLine("Vad önskar du filtrera på:");
            Console.WriteLine("1 - Titel");
            Console.WriteLine("2 - Författare");
            Console.WriteLine("3 - Publikationsår");
            int userChoice = UserInputHandler.intInput("Välj ett alternativ 1-3:", "Ogiltigt val, försök igen.");
            switch (userChoice)
            {
                case 1:
                    string titleSearch = UserInputHandler.StringInput("Skriv in hela eller delar av titeln du letar efter:", "Du måste skriva en något för att söka.");
                    var foundTitles = books.Where(b => b.Title.ToLower().Contains(titleSearch.ToLower()))
                                           .OrderBy(b => b.Title)
                                           .ToList();
                    if(foundTitles.Count > 0)
                    {
                        Console.WriteLine($"Funna titlar matchande {titleSearch}: ");
                        foreach(var book in foundTitles)
                        {
                            Console.WriteLine(book.ToString());
                            
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Inga titlar matchande {titleSearch} hittades.");
                        Console.ReadLine();
                        
                    }
                        break;
                case 2:
                    string authorSearch = UserInputHandler.StringInput("Skriv in hela eller delar av titeln du letar efter:", "Du måste skriva en något för att söka.");
                    var foundAuthors = books.Where(b => b.Author.ToLower().Contains(authorSearch.ToLower()))
                                           .OrderBy(b => b.Author)
                                           .ToList();
                    if (foundAuthors.Count > 0)
                    {
                        Console.WriteLine($"Funna titlar matchande {authorSearch}: ");
                        foreach (var book in foundAuthors)
                        {
                            Console.WriteLine(book.ToString());
                            
                            
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Inga titlar matchande {authorSearch} hittades.");
                        Console.ReadLine(); 
                    }
                    break;
                case 3:
                    int newestPublYear = UserInputHandler.intInput("Ange utgivningsårtal att söka från:", "Du måste skriva in årtal med 4 siffor", 4);
                    var fountPubYear = books.Where(b => b.PublicationYear >= newestPublYear)
                                            .OrderBy(b => b.PublicationYear)
                                            .ToList();
                    if (fountPubYear.Count > 0)
                    {
                        Console.WriteLine($"Funna titlar utgivna senast {newestPublYear}: ");
                        foreach (var book in fountPubYear)
                        {
                            Console.WriteLine(book.ToString());
                            
                            
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Inga böcker utgivna från {newestPublYear} och framåt.");
                        Console.ReadLine(); 
                    }
                    break;
                default: Console.WriteLine("Okänt val, återvänder till huvudmenyn."); Console.ReadLine();
                    return;
            }
        }
    }
}
