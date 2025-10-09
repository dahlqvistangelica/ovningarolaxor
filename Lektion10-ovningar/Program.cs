namespace Lektion10_ovningar
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            PersonStruct personStruct = new PersonStruct("Anna", 10);
            PersonRecord personRecord = new PersonRecord("Erik", 12);
            var copyStruct = personStruct;
            var copyRecord = personRecord;
            personRecord = personRecord with { Name = "Daniel" };
            personStruct.Name = "Emma"; //Funkar enbart eftersom jag satt propertyn till set, annars hade det inte fungerat. 
            Console.WriteLine(personStruct.ToString()); // Skriver inte ut det vi vill veta.
            Console.WriteLine(personRecord.ToString()); // Skriver ut alla variabelnamn med innehåll.
        }

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
        public record Movie(string Title, string Director, double ReleaseYear, double Rating);

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
        public record Coordinate(double X, double Y, double Z);
        public static double Distance(Coordinate a, Coordinate b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            double dz = a.Z - b.Z;
            double result = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            return result;
        }
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
