using PasswordManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    internal class Account
    {
        internal string Name;
        private string _userName;
        private const string PasswordPattern = @"^(?=.*[A-Z])(?=.*[\W])(?=.*\d).{6,}$";
        public string Password
        {
            get => _password; set
            {
                if (!Regex.IsMatch(value, PasswordPattern))
                {
                    throw new ArgumentException("Lösenord måste innehålla vissa typer av tecken.");
                }
                _password = value;
            }
        }
        private string _password;
        public string UserName
        {
            get => _userName; set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Användarnamn kan inte vara tomt.");
                }
                _userName = value;
            }
        }

        public Account(string name, string uName, string password)
        {
            Name = name;
            UserName = uName;
            Password = password;
        }
        internal static Account CreateAccount()
        {
            Console.WriteLine("--- SPARA NYTT KONTO ---");
            string name = InputManager.StringInput("Vart används lösenord och användarnamn:", "Felaktig inmatning, det kan inte vara tomt");
            string username = InputManager.StringInput("Ange användarnamn:", "Ogiltigt användarnamn, det kan inte vara tomt.");
            string password = InputManager.PassWordInput("Ange lösenord:", "Lösenord måste innehålla minst:\n- 1 stor bokstav\n- 1 siffra\n- 1 specialtecken.");
            Account account = new Account(name, username, password);
            return account;
        }
    }
}
