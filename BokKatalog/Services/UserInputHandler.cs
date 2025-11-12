using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokKatalog.Services
{
    internal static class UserInputHandler
    {
        internal static string StringInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal static string StringInput(string msg, string errorMsg, int minLength)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || userInput.Length < minLength)
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal static string StringInput(string msg, string errorMsg, char mustContain)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || !userInput.Contains(mustContain))
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal static int intInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            bool parseWorked = int.TryParse(userInput, out int result);
            while (!parseWorked)
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
                parseWorked = int.TryParse(userInput, out result);
            }
            return result;
        }
        internal static int intInput(string msg, string errorMsg, int minChar)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            bool parseWorked = int.TryParse(userInput, out int result);
            while (!parseWorked || userInput.Length < minChar)
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
                parseWorked = int.TryParse(userInput, out result);
            }
            return result;
        }
        internal static decimal decimalInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            bool parseWorked = decimal.TryParse(userInput, out decimal result);
            while (!parseWorked)
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
                parseWorked = decimal.TryParse(userInput, out result);
            }
            return result;
        }
    }
}
