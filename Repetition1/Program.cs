using System.Text.Json;
using System.Text.Json.Nodes;

namespace Repetition1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string path = @"C:\Repos\ovningarolaxor\Repetition1\people.json";
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string json = JsonSerializer.Serialize(people, options);
            var jsonfile = File.ReadAllText(path);
            if (File.Exists(path))
            {
                people.AddRange(JsonSerializer.Deserialize<List<Person>>(jsonfile));
                
            }
            foreach (var item in people)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("Language: " + item.language);
                Console.WriteLine("ID: " + item.id);
                Console.WriteLine("Version: " + item.version);
                Console.WriteLine("Bio: " + item.bio);
                Console.WriteLine("-----------------------------------------------------");
            }

        }
        public class Person
        {
            public string name { get; set; }
            public string language { get; set; }
            public string id { get; set; }
            public string bio { get; set; }
            public double version { get; set; }

            public Person()
            { }
        }
        
    }
}
