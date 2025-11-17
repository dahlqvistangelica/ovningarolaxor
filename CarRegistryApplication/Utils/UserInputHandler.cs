using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRegistryApplication.Models;

namespace CarRegistryApplication.Utils
{
    internal static class UserInputHandler
    {
        internal static string StringInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            string userInput = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal static int IntInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            bool userInput = int.TryParse(Console.ReadLine(), out int result);
            while (!userInput)
            {
                Console.WriteLine(errorMsg);
                userInput = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
        internal static int IntInputValues(string msg, string errorMsg, string errorMsg2, int maxValue, int minValue)
        {
            Console.Write(msg + " ");
            bool userInput = int.TryParse(Console.ReadLine(), out int result);
            while (!userInput)
            { if (result >= maxValue && result <= minValue)
                { Console.WriteLine(errorMsg2); }
                else
                { Console.WriteLine(errorMsg); }
                int.TryParse(Console.ReadLine(), out result);
            }

            return result;
        }
        internal static double DoubleInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            bool userInput = double.TryParse(Console.ReadLine(), out double result);
            while (!userInput)
            {
                Console.WriteLine(errorMsg);
                userInput = double.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
        internal static bool BoolInput(string msg, string errorMsg, string validOne, string validTwo)
        {
            validOne = validOne.ToLower();
            validTwo = validTwo.ToLower();
            Console.Write(msg + " ");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == validOne)
                return true;
            while (userInput != validOne && userInput != validTwo)
            {
                Console.WriteLine(errorMsg);
                userInput = Console.ReadLine().ToLower();
            }
            return false;

        }
        
    }
}
