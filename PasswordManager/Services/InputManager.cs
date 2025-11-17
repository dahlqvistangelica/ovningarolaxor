using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    internal static class InputManager
    {
        private const string PasswordPattern = @"^(?=.*[A-Z])(?=.*[\W])(?=.*\d).{6,}$";
        internal static int IntInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            int result;
            while(!int.TryParse(userInput, out result))
            {
                Console.WriteLine(errorMsg);
                Console.Write("Prova igen: ");
                userInput = Console.ReadLine();
            }
            return result;
        }
        internal static string StringInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(errorMsg);
                Console.Write("Prova igen: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal static string PassWordInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || !Regex.IsMatch(userInput, PasswordPattern))
            {
                Console.WriteLine(errorMsg);
                Console.Write("Prova igen: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal static string StringInputToLower(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(errorMsg);
                Console.Write("Prova igen: ");
                userInput = Console.ReadLine();
            }
            return userInput.ToLower();
        }
        internal static bool BoolInputYoN(string msg, string errorMsg, string sForTrue, char cForTrue, string sForFalse, char cForFalse)
        {
            Console.Write(msg + " ");
            while(true)
            {    string userInput = Console.ReadLine();

                string formattedInput = userInput.ToLower().Trim();
            
                if (formattedInput == sForTrue || formattedInput == cForTrue.ToString())
                    return true;
                if (formattedInput == sForFalse || formattedInput  == cForFalse.ToString())
                    return false;

                Console.WriteLine(errorMsg);
                Console.Write(msg + " ");
            }

           
        }
    }
}
