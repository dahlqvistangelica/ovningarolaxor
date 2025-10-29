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
            Person person1 = new Person("Anna");
            Person person2 = new Person("Emil");
            List<Person> people = new List<Person> { person1, person2 };
            PersonServices.PrintPersons(people);
        }
    }
}
