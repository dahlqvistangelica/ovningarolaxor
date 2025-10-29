using Lektion14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lektion14.Models.Person;

namespace Lektion14.Services
{
    internal class PersonServices
    {

        public static void PrintPersons(List<Person> list)
        {
            foreach(Person person in list)
            {
                Console.WriteLine(person.Name);
            }
        }
    }
}
