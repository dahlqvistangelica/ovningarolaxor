using Lektion14.Models;
using Lektion14.Services;
using static Lektion14.Models.Person;
using static Lektion14.Services.PersonServices;
namespace Lektion14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ange tid (HH:MM): ");
            string inputTime = Console.ReadLine();
            TimeOnly.TryParse(inputTime, out TimeOnly time);
            while (!TimeOnly.TryParse(inputTime, out time))
            {
                Console.WriteLine($"Felaktig inmatning av tid, försök igen.");
                inputTime = Console.ReadLine();
                TimeOnly.TryParse(inputTime, out time);
            }
            
                Console.WriteLine(time);
            Console.ReadLine();
            //Person person1 = new Person("Anna");
            //Person person2 = new Person("Emil");
            //List<Person> people = new List<Person> { person1, person2 };
            //PersonServices.PrintPersons(people);
            //var personInfo = ("Erik", 30, "Göteborg");
            //var namn = personInfo.Item1;
            //var age = personInfo.Item2;
            //var stad = personInfo.Item3;
            //Console.WriteLine(namn + age + stad);
            //Console.ReadLine();
        }
    }
}
