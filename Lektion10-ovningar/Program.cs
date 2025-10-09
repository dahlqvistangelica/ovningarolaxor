namespace Lektion10_ovningar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Övning 1 main
            Temperature temp = new Temperature(15);
            Console.WriteLine($"{temp.Celsius} C");
            Console.WriteLine($"{temp.ToFahrenheit()} F");

            //Övning 2 main
            Movie filmEtt = new Movie("Remember the Titans", "", 2001, 10);
            Movie filmTvå = new Movie("Hobbit", "Peter Jackson", 2002, 20);
            Movie filmTre = filmTvå with { ReleaseYear = 2012 };
            filmEtt = filmEtt with { Director = "Boaz Yakin" };
            Console.WriteLine(filmEtt);
            Console.WriteLine(filmTvå);
            Console.WriteLine(filmTre);

            //Övning 3 main
            Rectangle rectangle1 = new Rectangle(10, 10);
            Rectangle rectangle2 = new Rectangle(5, 15);
            Console.WriteLine(rectangle1.Area());
            Console.WriteLine(rectangle2.Area());
            Console.WriteLine(rectangle1.Perimeter());
            Console.WriteLine(rectangle2.Perimeter());
            Console.WriteLine(rectangle2.IsSquare());
            Console.WriteLine(rectangle1.IsSquare());
            
            //Övning fyra main
            Coordinate coord1 = new Coordinate(1, 2, 3);
            Coordinate coord2 = new Coordinate(2, 2, 2);
            Coordinate coord3 = new Coordinate(2, 4, 6);

            var (X, Y, Z) = coord1;
            Console.WriteLine($"X = {X}, Y = {Y}, Z = {Z}");
            (X, Y, Z) = coord2;
            Console.WriteLine($"X = {X}, Y = {Y}, Z = {Z}");
            (X, Y, Z) = coord3;
            Console.WriteLine($"X = {X}, Y = {Y}, Z = {Z}");
            Console.WriteLine(Distance(coord3, coord1));

            //Övning 5 main
            PersonStruct personStruct = new PersonStruct("Anna", 10);
            PersonRecord personRecord = new PersonRecord("Erik", 12);
            var copyStruct = personStruct;
            var copyRecord = personRecord;
            personRecord = personRecord with { Name = "Daniel" };
            personStruct.Name = "Emma"; //Funkar enbart eftersom jag satt propertyn till set, annars hade det inte fungerat. 
            Console.WriteLine(personStruct.ToString()); // Skriver inte ut det vi vill veta.
            Console.WriteLine(personRecord.ToString()); // Skriver ut alla variabelnamn med innehåll.
        }
        //Övning 1.
        public struct Temperature
        {
            public double Celsius { get; }
            public Temperature(double input)
            {
                Celsius = input;
            }
            public double ToFahrenheit()
            {
                double fahrenheit = Celsius * 9 / 5 + 32;
                return fahrenheit;

            }
        }
        //Övning 2
        public record Movie(string Title, string Director, double ReleaseYear, double Rating);
        //Övning 3
        struct Rectangle
        {
            double Width { get; }
            double Height { get; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public double Area()
            {
                double area = Width * Height;
                return area;
            }
            public double Perimeter()
            {
                double perimeter = (2 * Width) + (2 * Height);
                return perimeter;
            }
            public bool IsSquare()
            {
                if (Width == Height)
                    return true;
                return false;
            }
        }
        //Övning 4
        public record Coordinate(double X, double Y, double Z);
        public static double Distance(Coordinate a, Coordinate b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            double dz = a.Z - b.Z;
            double result = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            return result;
        }
        //Övning 5
        public record PersonRecord(string Name, int Age);
        public struct PersonStruct
        {
            public string Name { get; set; }
            public int Age { get; }
            public PersonStruct(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
}
