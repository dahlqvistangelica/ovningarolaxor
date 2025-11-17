using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    internal class AccountRepository
    {
        private List<Account> accounts;
        public AccountRepository()
        {
            accounts = new List<Account>();
        }

        internal void AddAccount()
        {
            Account account = Account.CreateAccount();
            accounts.Add(account);
            Console.WriteLine($"Uppgifter för {account.Name} har sparats.");
        }
        public void PublicDelete()
        {
            Console.WriteLine("--- TA BORT KONTO ---");
            if (accounts.Count > 0)
            {
                string nameToFind = InputManager.StringInput("Ange namnet på tjänsten där du vill ta bort användaruppgifterna:", "Felaktig inmatning, det kan inte vara tomt");
                DeleteAccount(nameToFind);
            }
            else
            {
                Console.WriteLine("Det finns inga sparade konton att ta bort.");
            }
        }
        private void DeleteAccount(string nameToFind)
        {
            var foundAccounts = accounts.Where(a => a.Name.ToLower().Contains(nameToFind.ToLower()))
                                       .OrderBy(a => a.Name)
                                       .ToList();
            if (foundAccounts.Count > 0)
            {
                Console.WriteLine($"Funna konton på sökningen: \"{nameToFind}\"");

                foreach (var account in foundAccounts)
                {
                    Console.WriteLine($"{account.Name}");
                }
                Console.WriteLine();
                string nameToDelete = InputManager.StringInputToLower("1. Ange namn på tjänst du önskar ta bort:", "Felaktig inmatning, namn kan inte vara tomt");
                string userNameToDelete = InputManager.StringInput("2. Ange korrekt användarnamn på tjänsten för att bekräfta borttagning:", "Felaktig inmatning, användarnamn kan inte vara tomt");
                var accountToDelete = accounts.FirstOrDefault(a => a.Name.ToLower().Equals(nameToDelete) && a.UserName.Equals(userNameToDelete));
                if(accounts.Remove(accountToDelete))
                    Console.WriteLine($"De sparade uppgifterna för {nameToDelete} har tagits bort.");
                else
                    Console.WriteLine("Något gick fel, försök igen.");
            }
            else
            {
                Console.WriteLine("Inga konton hittades, prova igen");
                return;
            }
                
        }
        public void ShowAccounts()
        {
            Console.WriteLine("--- VISA ALLA KONTON ---");
            if (accounts.Count > 0)
            {
                bool userChoice = InputManager.BoolInputYoN("Vill du visa alla konton med synliga lösenord? (ja/nej)", "Du måste skriva in ja/j eller nej/n.", "ja", 'j', "nej", 'n');
                if (userChoice)
                { AccessAccounts(); }
                else
                { ShowOnlyNameAndUserName(); }
            }
            else
            {
                Console.WriteLine("Det finns inga konton sparade.");
            }

        }
        private void AccessAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Name}, {account.UserName}, {account.Password}");
            }
        }
        private void ShowOnlyNameAndUserName()
        {
            
            foreach (var account in accounts)
            {
                int passlength = account.Password.Length;
                string replacePass = new string('*', passlength);
                Console.WriteLine($"{account.Name}, {account.UserName}, {replacePass}");
            }
        }
    }
}
