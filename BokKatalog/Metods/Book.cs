using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokKatalog.Metods
{
    internal class Book
    {
        private string ISBN;
        internal string OpenISBN { get => ISBN; init
            {
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException("ISBN måste vara längre än 4 tecken.");
                ISBN = value;
            }
            }
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal int PublicationYear { get; set; }
        internal decimal Price { get; set; }
        internal int StockCount { get; set; }

        public Book(string isbn, string title, string author, int pubyear, decimal price, int stock)
        {
            OpenISBN = isbn;
            Title = title;
            Author = author;
            PublicationYear = pubyear;
            Price = price;
            StockCount = stock;
        }

        public override string ToString()
        {
            return $"Titel: {Title}, Författare: {Author}, Publiseringsår:{PublicationYear}, Pris:{Price}, Antal i lager:{StockCount} " +
                $"\nISBN: {ISBN}";
        }
    }
}
