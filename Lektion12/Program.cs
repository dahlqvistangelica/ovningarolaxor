namespace Lektion12
{
    internal class Program
    {
        static void Main(string[] args)
            
        {   //Övning 2 - programkod int.
            var intStorage = new Storage<int>();
            Console.WriteLine(intStorage.IsEmpty());
            intStorage.Store(32);
            Console.WriteLine(intStorage.Retrive());
            Console.WriteLine(intStorage.IsEmpty());
           
            //Övning 2 - programkod string.
            var stringStorage = new Storage<string>();
            Console.WriteLine(stringStorage.IsEmpty());
            stringStorage.Store("Hej");
            Console.WriteLine(stringStorage.Retrive());
            Console.WriteLine(stringStorage.IsEmpty());

            //Övning 3
            string a = "Hej";
            string b = "då";
            Swap<string>(ref a, ref b);
            Console.WriteLine(a + b);
            int c = 10;
            int d = 5;
            Swap<int>(ref c, ref d);
            Console.WriteLine(d);
            Console.WriteLine(c);
            double ett = 2.0;
            double två = 1.0;
            Swap<double>(ref ett, ref två);
            Console.WriteLine(ett);
            Console.WriteLine(två); 
           
            //Övning 5
            SimpleList<int> intList = new SimpleList<int>(10);
           
            //Övning 6
            Duck duck = new Duck();
            Fish fish = new Fish();
            Airplane airplane = new Airplane();
            FlyingSwimmer(duck);
            FlyingSwimmer(airplane);
            //FlyingSwimmer(fish); kastar error.
            
        }
        #region Övning 6
        public interface IFlyable
        {
            void Fly();
        }
        interface ISwimmable
        {
            void Swim();
        }
        public class Duck : IFlyable, ISwimmable
        {
            public void Fly()
            {
                Console.WriteLine("Ducks can fly");
            }

            public void Swim()
            {
                Console.WriteLine("Ducks can swim.");
            }
        }
        public class Airplane : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Airplanes fly.");
            }
        }
        public class Fish: ISwimmable
        {
            public void Swim()
            {
                Console.WriteLine("Fishes swim.");
            }
        }
        public static void FlyingSwimmer(IFlyable flyswimmer)
        {
            if(flyswimmer is ISwimmable swimmer)
            {
                flyswimmer.Fly();
                swimmer.Swim();
            }
            else
            { Console.WriteLine($"{flyswimmer.GetType().Name} can't swim."); 
            }
        }
        #endregion

        #region Övning 5
        class SimpleList<T>
        {
            public T[] items { get; set; }
            public int count = 0;
            public int Count => count;
            public SimpleList(int amount)
            { items = new T[amount]; }
            public void Add(T item)
            {
                if(count >= items.Length)
                {
                    Console.WriteLine("Listan är full.");
                }
                items[count] = item;
                count++;
            }
            public T Get(int index)
            {
                return items[index];
            }
            public bool Contains(T item)
            {
                for (int index = 0; index < count; index++)
                {
                    if (Equals(items[index], item))
                        return true;
                }
                return false;
                
            }
        }
        #endregion
        #region Övning 4
        interface IEmployee
        {
            string Name { get; set; }
            double Salary { get; set; }
            double GetAnnualSalary();
            double GiveRaise(double percentage);
        }
        class FullTimeEmployee : IEmployee
        {
            public string Name { get; set; }
            public double Salary { get; set; }

            public double GetAnnualSalary()
            {
                double annualSalary = Salary * 12;
                return annualSalary;
            }

            public double GiveRaise(double percentage)
            {
                double newSalary = Salary *= 1 + percentage;
                return newSalary;
            }
        }
        #endregion

        #region Övning 3

        public static void Swap<T>(ref T first, ref T second)
        { T temp = first;
             first = second;
            second = temp;
        }
        #endregion
        #region Övning 2
        class Storage<T>
        {
            private T _storeT;
            public T Store(T item)
            {
                return _storeT = item;
            }
            public T Retrive()
            {
                return _storeT;
            }
            public bool IsEmpty()
            {
                if (_storeT == null)
                    return true;
                else return false;
            }
        }
        #endregion
        #region Övning 1
        public interface IVehicle
        {
            void Start();
            void Stop();
            int GetMaxSpeed();
        }
        public class Car : IVehicle
        {
            public int GetMaxSpeed()
            {
                return 120;
            }
            public void Start()
            { }
            public void Stop()
            { }
        }
        public class Bicycle : IVehicle
        {
            public int GetMaxSpeed()
            {
                return 30;
            }

            public void Start()
            {
            }

            public void Stop()
            {
            }
        }
        #endregion
    }
}
