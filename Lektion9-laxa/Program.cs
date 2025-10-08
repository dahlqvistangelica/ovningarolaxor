namespace Lektion9_laxa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

        }
       
        
        #region Fråga 3 kodexempel
        //Open/Closed principle, inga ändringar i electronic utan enbart tillägg av subklasser. 
        public abstract class Electronic
        {
            public abstract void TurnOn();
        }

        public class Light : Electronic
        {
            public override void TurnOn()
            {
                Console.WriteLine("Lampan är tänd");
            }
        }
        public class Fan : Electronic
        {
            public override void TurnOn()
            {
                Console.WriteLine("Fläkten är på");
            }
        }
        public class TV : Electronic
        {
            public override void TurnOn()
            {
                Console.WriteLine("TVn är startad.");
            }
        }
        #endregion
        #region Fråga 4 inkorrekt
        //Inkorrekt användning av LSP. Flodhästen simmar inte och passar inte in i watercreature eftersom de simmar. 
        public class WaterCreature
        {
            public virtual void Swim() { Console.WriteLine("Simmar!"); }
        }
        public class Hippo : WaterCreature
        {
            public override void Swim()
            {
                throw new Exception("Flodhästar kan inte simma, de går på botten!");
            }
        }
        #endregion
        #region Fråga 4 korrekt
        //korrekt användning av LSP. Alla subklasser fungerar att köra utan att det kastas några undantag.
        public class Mammal
        {
            public virtual void Move() { }
        }
        public abstract class WalkingMammal : Mammal
        {
            public abstract void Run();
            public override void Move()
            {
                Run();
            }
        }
        public abstract class SwimmingMammal : Mammal
        {
            public abstract void Swim();
            public override void Move()
            {
                Swim();
            }
        }
        public class Hippopotamus : WalkingMammal
        {
            public override void Run()
            {
                Console.WriteLine("Hippos run under water!");
            }
        }
        public class Dolphin : SwimmingMammal
        {
            public override void Swim()
            {
                Console.WriteLine("Dolphin swim in the water!");
            }
        }
        #endregion
        #region Fråga 9 exempel på inkapsling och abstraktion.
        public class SaveMyMoney
        {
            private int _savedMoney; //Inkapsling
            public int SavedMoney { get => _savedMoney; private set => _savedMoney = value; }
            public SaveMyMoney(int startMoney)
            {
                SavedMoney = startMoney;
            }
            public void Deposit(int amount) //Abstraktion
            {
                AddMoney(amount);
            }
            public void Withdraw(int amount) //Abstraktion
            {
                WithdrawMoney(amount);
            }
            private int AddMoney(int amount) //Inkapsling
            { 
                _savedMoney += amount;
                return _savedMoney;
            }
            private bool ValidateBalance(int value) //Inkapsling
            {
                if (_savedMoney < value)
                    return false;
                return true;
            }
            private int WithdrawMoney(int amount) //Inkapsling
            {
                if (!ValidateBalance(amount))
                { Console.WriteLine("Det finns inte tillräckligt med pengar.");
                    return _savedMoney;
                }
                return _savedMoney -= amount;
            }
        }
        #endregion
        #region Fråga 10 kodexempel som demonstrerar polymorfism med method override och interface implementation.
        interface IAnimal
        {
            public void MakeSound();
            
        }
        public abstract class Animal
        {
            public virtual void Describe()
            { Console.WriteLine("");
            }
        }
        public class Dog : Animal, IAnimal
        {
            public override void Describe()
            {
                Console.WriteLine("Det här är en hund.");
            }
            public void MakeSound()
            {
                Console.WriteLine("Hunden säger voff!");
            }
        }
        public class Cat : Animal, IAnimal
        {
            public override void Describe()
            {
                Console.WriteLine("Det här är en katt.");
            }
            public void MakeSound()
            {
                Console.WriteLine("Katten säger mjau.");
            }
        }
        public class Bird : Animal, IAnimal
        {
            public override void Describe()
            {
                Console.WriteLine("Det här är en fågel.");
            }
            public void MakeSound()
            {
                Console.WriteLine("Fågeln säger pip, pip.");
            }
        }
        #endregion
    }
}

