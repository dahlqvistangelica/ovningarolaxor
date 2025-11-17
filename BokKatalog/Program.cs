using BokKatalog.Services;
using BokKatalog.UI;

namespace BokKatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookCatalog bookCatalog = new BookCatalog();
            Menu.ShowMenu(bookCatalog);
        }
    }
}
