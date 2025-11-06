using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Lektion16
{
    internal class Program

    {
        public void PrintList(string[] array)
        {
            foreach(string thing in array)
            { Console.WriteLine(thing); }
        }
       
        static void Main(string[] args)
        {
            #region Övning 4
            string pathNames = @"C:\Repos\ovningarolaxor\Lektion16\namn.txt";
            if (File.Exists(pathNames))
            {
                string[] namn = File.ReadAllLines(pathNames);
                Func<string, char, bool> startLetter = (a, l) => a.StartsWith(l);
                Func<string, bool> moreThanFiveLetters = a => a.Length > 5;
                Func<string, string> sortbyName = a => a;
                var sortedByName = namn.OrderBy(n => n).ToArray();
                var nameWithLetter = namn.Where(n => startLetter(n, 'A')).ToArray();
                var biggerThanFive = namn.Where(moreThanFiveLetters).ToArray();
                Console.WriteLine("Sorterat efter namn");
                PrintList(sortedByName);
                Console.WriteLine("Namn med startbokstav A");
                PrintList(nameWithLetter);
                Console.WriteLine("Namn längre än 5");
                PrintList(biggerThanFive);
            }
            #endregion

            #region Övning 3
            string pathFood = @"C:\Repos\ovningarolaxor\Lektion16\favoritmat.txt";
        if(File.Exists(pathFood))
        {
            string[] maträtter = File.ReadAllLines(pathFood);
            foreach(string rätt in maträtter)
            {
                Console.WriteLine(rätt);
            }
        }
        #endregion



             #region Övning 1
             Func<int, int> doubleValue = x => x * 2;
             Func<int, int, int> largestValue = (z, y) => Math.Max(z, y);
             Func<string, bool> capitolLetter = s => char.IsUpper(s[0]);
             #endregion

             #region Övning 2
             int[] arrayMedInts = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
             Func<int, bool> evenNumbers = h => h % 2 == 0;
             Func<int, int> threeTimes = c => c * 3;
             Func<int, bool> biggerThanSeven = d => d > 7;
             var isEven = arrayMedInts.Where(evenNumbers);
             var firstbiggerThanSeven = arrayMedInts.First(biggerThanSeven);
             var timesThree = arrayMedInts.Select(threeTimes);
             #endregion
        }
        
    }
}
