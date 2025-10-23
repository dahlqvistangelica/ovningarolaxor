using Microsoft.VisualBasic;
using System;
using System.Text;

namespace Lektion13
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            #region Övning 1
            
            int sum = 0;
            int tenThrows = 10;
            for (int throwCount = 0; throwCount < tenThrows; throwCount++)
            {
                int currentThrow = random.Next(1, 7);
                Console.WriteLine($"Kast {throwCount + 1}: {currentThrow}");
                sum += currentThrow;
            }
            Console.WriteLine($"Total summa: {sum}");
            #endregion

            #region Övning 2

            Console.Write("Ange ditt födelsedatum (yyyy-mm-dd): ");
            string inputBirthDate = Console.ReadLine();
            DateTime today = DateTime.Now;
            DateTime.TryParse(inputBirthDate, out DateTime birthDateDT);
            TimeSpan difference = today - birthDateDT;
            int yearsAge = GetAgeInYears(birthDateDT, today);
            int daysLeft = GetDaysTillBirthday(birthDateDT, today);
            Console.WriteLine($"Du är {yearsAge}");
            Console.WriteLine($"Du har levt {difference.Days}");
            Console.WriteLine($"Det är {daysLeft} dagar till din nästa födelsedag!");
            int GetAgeInYears(DateTime birthDate, DateTime today)
            {
                int age = today.Year - birthDateDT.Year;
                if (today < birthDateDT.AddYears(age))
                { age--; }
                return age;
            }
            int GetDaysTillBirthday(DateTime birthdate, DateTime today)
            {
                DateTime nextBirthDay = new DateTime(today.Year, birthdate.Month, birthdate.Day);
                    if (nextBirthDay < today)
                { nextBirthDay = nextBirthDay.AddYears(1); }
                int daysLeft = (nextBirthDay - today).Days;
                return daysLeft;
            }
            #endregion

            #region Övning 3
            string[] productName = { "Laptop", "Mus", "Tangentbord", "Hörlurar" };
            int[] productPrice = { 15990, 299, 899, 1200 };
            StringBuilder rapport = new StringBuilder();
            rapport.AppendLine(" ===== FÖRSÄLJNINGSRAPPORT =====");
            rapport.AppendLine("Produkt \t Pris");
            rapport.AppendLine("---------------------------------");
            int totalPrice = 0;
            for (int counter = 0; counter < productName.Length; counter++)
            {
                rapport.Append($"{productName[counter],-15} ");
                rapport.AppendLine($" {productPrice[counter],5:C}");
                totalPrice += productPrice[counter];
            }
            rapport.AppendLine("---------------------------------");
            rapport.AppendLine($"TOTAL: {totalPrice,22:C}");
            rapport.AppendLine("=================================");
            Console.WriteLine(rapport.ToString());
            #endregion

            #region Övning 4
            Console.Write("Mata in starttid (HH:mm): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime workStart);
            Console.Write("Mata in sluttid (HH:mm): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime workEnd);
            TimeSpan workTime = workEnd - workStart;
            Console.WriteLine($"Total arbetstid: {workTime.ToString("h' timmar, 'm' minuter.'")}");
            TimeSpan lunchTime = new TimeSpan(0, 30, 0);
            if (workTime.TotalHours > 6)
            { workTime -= lunchTime; }
            Console.WriteLine($"Avdrag för 30min lunch: {workTime.ToString("h' timmar, 'm' minuter.'")}");
            TimeSpan overTime = new TimeSpan(); //Ny timespan för övertid.

            if (workTime.TotalHours > 8) //om worktime är över 8h.
            {
                overTime = workTime - TimeSpan.FromHours(8); //Ta bort 8h och spara som övertid.
            }
            TimeSpan ordinaryHours = workTime - overTime; //Ta bort övertid från arbetstid för att få ordinarie tid. 
            double ordHourPay = 200;
            double overHourPay = 300;
            double totalOrdPay = ordinaryHours.TotalHours * ordHourPay;
            double totalOverPay = overTime.TotalHours * overHourPay;
            double totalPay = totalOrdPay + totalOverPay;

            Console.Write($"Ordinarie tid: {ordinaryHours.ToString("h' timmar 'm' minuter.'")}");
            Console.WriteLine($" ({totalOrdPay:C})");
            Console.Write($"Övertid: {overTime.ToString("h' timmar 'm' minuter.'")}");
            Console.WriteLine($" ({totalOverPay:C})");
            Console.WriteLine($"Total lön: {totalPay:C}");
            #endregion

        }


    }
}
