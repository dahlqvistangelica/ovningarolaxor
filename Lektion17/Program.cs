namespace Lektion17
{
    // LINQ och Query Expressions - Kodövningar
    // 8 övningar i olika svårighetsgrad

    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace LinqExercises
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Kör alla övningar
                Exercise1();
                Exercise2();
                Exercise3();
                Exercise4();
                Exercise5();
                Exercise6();
                Exercise7();
                Exercise8();
            }

            // ===== ÖVNING 1: GRUNDLÄGGANDE FILTRERING (Lätt) =====
            static void Exercise1()
            {
                Console.WriteLine("=== ÖVNING 1: Grundläggande filtrering ===");

                int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

                var evenNumbers = numbers
                                  .Where(n => n % 2 == 0);
                                  
                // TODO: Använd LINQ för att hitta alla jämna tal
                // TODO: Skriv ut resultatet

                Console.WriteLine();
                foreach (var numb in evenNumbers)
                { Console.WriteLine(numb); }

            }

            // ===== ÖVNING 2: ENKEL TRANSFORMATION (Lätt) =====
            static void Exercise2()
            {
                Console.WriteLine("=== ÖVNING 2: Enkel transformation ===");

                string[] words = { "hej", "världen", "detta", "är", "LINQ" };

                var wordsToUpper = words.Select(w => w.ToUpper());
                                   
                                   
                // TODO: Använd LINQ för att göra alla ord till versaler
                // TODO: Skriv ut resultatet
                foreach(var word in wordsToUpper)
                {
                    Console.Write(word + " ");
                    
                }
                Console.WriteLine();
            }

            // ===== ÖVNING 3: SORTERING OCH FILTRERING (Medel) =====
            static void Exercise3()
            {
                Console.WriteLine("=== ÖVNING 3: Sortering och filtrering ===");

                string[] cities = { "Stockholm", "Göteborg", "Malmö", "Uppsala", "Sundsvall", "Söderhamn", "Sala" };

                var citiesStartsWith = cities
                                       .Where(c => c.StartsWith("S"))
                                       .OrderBy(c => c);

                foreach(var city in citiesStartsWith)
                { Console.WriteLine(city); }

                Console.WriteLine();
            }

            // ===== ÖVNING 4: AGGREGERING (Medel) =====
            static void Exercise4()
            {
                Console.WriteLine("=== ÖVNING 4: Aggregering ===");

                int[] scores = { 85, 92, 78, 96, 88, 91, 84, 93, 87, 89 };

                Console.WriteLine("Antal betyg: " + scores.Count());
                Console.WriteLine("Högsta betyg: " + scores.Max());
                Console.WriteLine("Lägsta betyg: " + scores.Min());
                Console.WriteLine("Medelvärde: " + scores.Average());
                Console.Write("Betyg över 90: " + scores.Count(n=>n > 90));
                
                // TODO: Beräkna följande med LINQ:
                // - Antal betyg
                // - Högsta betyg
                // - Lägsta betyg
                // - Medelvärde
                // - Antal betyg över 90

                Console.WriteLine();
            }

            // ===== ÖVNING 5: ARBETA MED OBJEKT (Medel-Svår) =====
            static void Exercise5()
            {
                Console.WriteLine("=== ÖVNING 5: Arbeta med objekt ===");

                var students = new List<Student>
            {
                new Student { Name = "Anna", Age = 20, Grade = 85, Subject = "Matematik" },
                new Student { Name = "Erik", Age = 22, Grade = 92, Subject = "Fysik" },
                new Student { Name = "Lisa", Age = 19, Grade = 78, Subject = "Matematik" },
                new Student { Name = "Johan", Age = 21, Grade = 88, Subject = "Kemi" },
                new Student { Name = "Sara", Age = 20, Grade = 94, Subject = "Fysik" },
                new Student { Name = "Marcus", Age = 23, Grade = 82, Subject = "Matematik" }
            };
                var getSpecificStudent = students
                                        .Where(s => s.Age > 20)
                                        .Where(s => s.Grade > 85)
                                        .OrderBy(s => s.Grade);
                // TODO: Hitta alla studenter som är över 20 år och har betyg över 85
                // TODO: Sortera dem efter betyg (högst först)
                // TODO: Skriv ut namn och betyg för varje student
                foreach(var student in getSpecificStudent)
                { Console.WriteLine("Namn: " + student.Name + ", Betyg: " + student.Grade); }
                
                Console.WriteLine();
            }

            // ===== ÖVNING 6: QUERY SYNTAX (Medel-Svår) =====
            static void Exercise6()
            {
                Console.WriteLine("=== ÖVNING 6: Query syntax ===");

                var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 15000, Category = "Electronics" },
                new Product { Name = "Bok", Price = 299, Category = "Education" },
                new Product { Name = "Telefon", Price = 8500, Category = "Electronics" },
                new Product { Name = "Skrivbord", Price = 2500, Category = "Furniture" },
                new Product { Name = "Lampa", Price = 450, Category = "Furniture" },
                new Product { Name = "Kurs", Price = 1200, Category = "Education" }
            };

                var electronics = from p in products
                                  where p.Category == "Electronics"
                                  orderby p.Price 
                                  select new
                                  {
                                      Namn = p.Name,
                                      Pris = p.Price
                                  };
                // TODO: Använd QUERY SYNTAX för att:
                // 1. Hitta alla "Electronics" produkter under 10000 kr
                // 2. Sortera efter pris (lägst först)
                // 3. Välj endast namn och pris
                foreach(var e in electronics)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }

            // ===== ÖVNING 7: AVANCERAD FILTRERING OCH GRUPPERING (Svår) =====
            static void Exercise7()
            {
                Console.WriteLine("=== ÖVNING 7: Avancerad filtrering och gruppering ===");

                var orders = new List<Order>
            {
                new Order { Customer = "Anna", Amount = 1500, Date = new DateTime(2024, 1, 15) },
                new Order { Customer = "Erik", Amount = 2300, Date = new DateTime(2024, 1, 22) },
                new Order { Customer = "Anna", Amount = 800, Date = new DateTime(2024, 2, 5) },
                new Order { Customer = "Lisa", Amount = 1200, Date = new DateTime(2024, 2, 10) },
                new Order { Customer = "Erik", Amount = 3200, Date = new DateTime(2024, 2, 18) },
                new Order { Customer = "Anna", Amount = 950, Date = new DateTime(2024, 3, 2) }
            };



                var orderPerCustomer = from o in orders
                                       group o by o.Customer into c
                                       where c.Sum(c => c.Amount) > 2000
                                       orderby c.Sum(c => c.Amount) descending
                                       select new
                                       {
                                           Customer = c.Key,
                                           TotalSum = c.Sum(c => c.Amount),
                                           Orders = c.Count(),
                                       };
                // TODO: Gruppera orders per kund
                // TODO: För varje kund, beräkna total summa och antal orders
                // TODO: Visa endast kunder med total summa över 2000
                // TODO: Sortera efter total summa (högst först)
                foreach(var customer in orderPerCustomer)
                {
                    Console.WriteLine(customer);
                }
                Console.WriteLine();
            }

            // ===== ÖVNING 8: KOMPLEX DATAMANIPULATION (Mycket Svår) =====
            static void Exercise8()
            {
                Console.WriteLine("=== ÖVNING 8: Komplex datamanipulation ===");

                var employees = new List<Employee>
            {
                new Employee { Name = "Anna", Department = "IT", Salary = 45000, StartDate = new DateTime(2020, 3, 15) },
                new Employee { Name = "Erik", Department = "Sales", Salary = 38000, StartDate = new DateTime(2019, 8, 22) },
                new Employee { Name = "Lisa", Department = "IT", Salary = 52000, StartDate = new DateTime(2021, 1, 10) },
                new Employee { Name = "Johan", Department = "HR", Salary = 41000, StartDate = new DateTime(2018, 6, 5) },
                new Employee { Name = "Sara", Department = "IT", Salary = 48000, StartDate = new DateTime(2020, 11, 30) },
                new Employee { Name = "Marcus", Department = "Sales", Salary = 35000, StartDate = new DateTime(2022, 4, 12) }
            };

                var rapport = from e in employees
                              group e by e.Department into d
                              where d.Count() > 1
                              orderby d.Average(e => e.Salary) descending
                              select new
                              {
                                  Avdelning = d.Key,
                                  AntalAnställda = d.Count(),
                                  Genomsnittslön = d.Average(e => e.Salary),
                                  HögstaLön = d.Max(e => e.Salary),
                                  HögstBetald = d.OrderByDescending(e => e.Salary).First().Name
                              };

                foreach(var r in rapport)
                {
                    Console.WriteLine(r);
                }
                // TODO: Skapa en rapport som visar:
                // 1. För varje avdelning: antal anställda, genomsnittslön, högsta lön
                // 2. Visa endast avdelningar med fler än 1 anställd
                // 3. Sortera avdelningarna efter genomsnittslön (högst först)
                // 4. För varje avdelning, visa också den anställde med högst lön

                // BONUS: Hitta alla anställda som har jobbat mer än 3 år och tjänar över genomsnittet

                Console.WriteLine();
            }
        }

        // Hjälpklasser för övningarna
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Grade { get; set; }
            public string Subject { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }

        public class Order
        {
            public string Customer { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public DateTime StartDate { get; set; }
        }
    }
}
