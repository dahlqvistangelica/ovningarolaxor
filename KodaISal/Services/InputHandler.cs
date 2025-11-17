using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodaISal.Services
{//Klass för att hantera användarinmatning på ett säkert sätt.
    internal static class InputHandler
    {
     /// <summary>
     /// Hanterar inmatning av strängar från användaren.
     /// </summary>
     /// <param name="msg">Fråga som visas för användaren</param>
     /// <param name="errorMsg">Felmeddelandet som visar för användaren.</param>
     /// <returns></returns>
        public static string StringInput(string msg, string errorMsg)
        {
            Console.Write(msg + " ");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                { return userInput; }
                Console.WriteLine(errorMsg);
                Console.Write(msg + " ");

            }
        }

        /// <summary>
        /// Metod för säker hantering av inmatning och konvertering till int.
        /// </summary>
        /// <param name="msg">Fråga som visas för användaren</param>
        /// <param name="errorMsg">Felmeddelandet som visar för användaren.</param>
        /// <returns></returns>
        public static int IntInput(string msg, string errorMsg)
        {
            int result;
            Console.Write(msg + " ");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out result))
                {
                        return result;
                }
                Console.WriteLine(errorMsg);
                Console.Write(msg + " ");
            }
        }
        /// <summary>
        /// Metod för säker hantering av inmatning och konvertering till int med ett minimumvärde.
        /// </summary>
        /// <param name="msg">Fråga som visas för användaren</param>
        /// <param name="errorMsg">Felmeddelandet som visar för användaren.</param>
        /// <param name="minvalue">Minsta värdet användaren får mata in.</param>
        /// <returns></returns>
        public static int IntInput(string msg, string errorMsg, int minvalue)
        {
            int result;
            Console.Write(msg + " ");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out result))
                {
                    if (result >= minvalue)
                        return result;
                }
                Console.WriteLine(errorMsg);
                Console.Write(msg + " ");
            }
        }
        /// <summary>
        /// Metod för säker hantering av inmatning och konvertering till int med maxvärde på inmatningen
        /// </summary>
        /// <param name="msg">Fråga som visas för användaren</param>
        /// <param name="errorMsg">Felmeddelandet som visar för användaren.</param>
        /// <param name="maxvalue">Maxvärdet användaren får mata in.</param>
        /// <param name="errorMsg2">Felmeddelande som visas om användaren matar in ett värde högre än maxvärdet.</param>
        /// <returns></returns>
        public static int IntInput(string msg, string errorMsg, int maxvalue, string errorMsg2)
        {
            int result;
            Console.Write(msg + " ");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out result))
                {
                    if (result <= maxvalue)
                        return result;
                }
                if (result > maxvalue)
                {
                    Console.WriteLine(errorMsg2);
                    Console.Write(msg + " ");
                }
                else
                {
                    Console.WriteLine(errorMsg);
                    Console.Write(msg + " ");
                }
            }
        }
        /// <summary>
        /// Metod för säker hantering av inmatning och konvertering till decimal.
        /// </summary>
        /// <param name="msg">Fråga som visas för användaren</param>
        /// <param name="errorMsg">Felmeddelandet som visar för användaren.</param>
        /// <returns></returns>
        public static decimal DecimalInput(string msg, string errorMsg)
        {
            decimal result;
            Console.Write(msg + " ");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (decimal.TryParse(userInput, out result))
                {
                    if (result > 0)
                        return result;
                }
                Console.WriteLine(errorMsg);
                Console.Write(msg + " ");
            }
        }
        /// <summary>
        /// Metod för att omvandla användarens inmatning till en bool.
        /// </summary>
        /// <param name="msg">Fråga som visas för användaren</param>
        /// <param name="errorMsg">Felmeddelandet som visar för användaren.</param>
        /// <param name="sForTrue">String alternativ som ska accepteras som true</param>
        /// <param name="cForTrue">Char alternativ som ska accepteras som true</param>
        /// <param name="sForFalse">String alternativ som ska accepteras som false</param>
        /// <param name="cForFalse">Char alternativ som ska accepteras som false</param>
        /// <returns></returns>
        public static bool BoolInput(string msg, string errorMsg, string sForTrue, char cForTrue, string sForFalse, char cForFalse)
        {
            Console.Write(msg + " ");
            while(true)
            {
                string userInput = Console.ReadLine().ToLower().Trim();

                if (userInput == sForTrue || userInput == cForTrue.ToString())
                    return true;
                if (userInput == sForFalse || userInput == cForFalse.ToString())
                    return false;

                Console.WriteLine(errorMsg);
                Console.Write(msg + " ");
            }
        }
    }
}
