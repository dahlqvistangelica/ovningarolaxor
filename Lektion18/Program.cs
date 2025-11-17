namespace Lektion18
{

    // Abstrakt basklass för djur
    abstract class Animal
    {
        public string Name { get; set; }
        public abstract void MakeSound();
    }

    // Lejonklass som ärver från Animal
    class Lion : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Roar!");
        }
    }

    // Elefantklass som ärver från Animal
    class Elephant : Animal
    {
        public int TrunkLength { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Trumpet!");
        }
    }

    // Apklass som ärver från Animal
    class Monkey : Animal
    {
        public bool CanClimb { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Ooh ooh ah ah!");
        }
    }

    // Giraffklass som ärver från Animal
    class Giraffe : Animal
    {
        public int NeckLength { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Hum!");
        }
    }

    // Tigerklass som ärver från Animal
    class Tiger : Animal
    {
        public bool HasStripes { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Roar!");
        }
    }

    // Leopardklass som ärver från Animal
    class Leopard : Animal
    {
        public int SpotCount { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Roar!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[]
            {
            new Lion { Name = "Simba" },
            new Elephant { Name = "Dumbo", TrunkLength = 60 },
            new Monkey { Name = "Rafiki", CanClimb = true },
            new Giraffe { Name = "Melman", NeckLength = 200 },
            new Tiger { Name = "Shere Khan", HasStripes = true },
            new Leopard { Name = "Bagheera", SpotCount = 50 }
            };

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Djur: {animal.Name}");
                animal.MakeSound();

                // Pattern matching för att hantera specifika djurtyper
                switch (animal)
                {
                    case Lion lion: Console.WriteLine($"{lion.Name} är huvudkaraktären i Lejonkungen.");
                        break;
                    // Typmönster: Matchar ett uttryck till en specifik typ

                    case Giraffe giraffe when giraffe.Name == "Melman" && giraffe.NeckLength > 150: Console.WriteLine($"{giraffe.Name} är en hypokondrisk giraff som medverkar i Madagaskar.");
                        break;
                    // AND-mönster: Matchar ett uttryck om alla angivna mönster matchar  

                    case Elephant elephant when elephant.TrunkLength > 40:
                        Console.WriteLine($"{animal.Name} kan flyga med sina stora öron!");
                        break;
                    // Egenskapsmönster: Matchar ett uttryck baserat på dess egenskaper

                    case Leopard leopard when (leopard.SpotCount < 65 && leopard.Name == "Bagheera"):
                        Console.WriteLine($"{leopard.Name} är egentligen en panter och har inga fläckar.");
                        break;
                    // Parentesmönster: Grupperar mönster och tillåter tillämpning av operatorer på gruppen  

                    case Tiger tiger when tiger.HasStripes || tiger.Name == "Shere Khan":
                        Console.WriteLine($"{tiger.Name} är den onda i Djungelboken!");
                        break;
                    // ELLER-mönster: Matchar ett uttryck om något av de angivna mönstren matchar

                    case Monkey monkey when monkey.CanClimb:
                        Console.WriteLine($"{animal.Name} kan klättra!");
                        break;
                    // Konstant-mönster: Matchar ett uttryck till ett konstant värde  

                    case var unknownAnimal:
                        Console.WriteLine($"Okänd djurtyp av typen {unknownAnimal.GetType().Name}");
                        break;
                    // Var-mönster: Matchar alla uttryck och tilldelar dem till en variabel
                }

                Console.WriteLine();
            }
        }
    }
}
