using PasswordManager.Services;
using PasswordManager.UI;

namespace PasswordManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountRepository repository = new AccountRepository();
            Menu.MainMenu(repository);
        }
    }
}
