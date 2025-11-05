

namespace Lektion15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MinEgenException
            try
            {
                string name = "Angeliqa";
                if (name != "Angelica")
                    throw new MinException("Fel namn!", name);
            }
            catch(MinException ex)
            {
                Console.WriteLine(ex.Message + ex.Name);
            }
            //ArgumentNullException
            try
            {
                string name = "";
                IfNameIsNull(name);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Uppgift 12
            try
            {
                string siffror = "123";
                string bokstäver = "abc";
                int.Parse(siffror);
                int.Parse(bokstäver);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Kan inte konvertera bokstäver");
                Console.WriteLine(ex.Message);
            }
            //Uppgift 14
            try
            {
                Console.WriteLine("Det här är en try, här provar man.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Här är en catch, den ska fånga felen.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Den här skrivs alltid ut.");
            }
            //Uppgift 16 & 18
            try
            {
                int text = int.Parse("abc");
                int division = 10/0
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Man kan inte parsa bokstäver.");
                Console.WriteLine(ex.Message);
            }
            catch(DivideByZeroException ex)
            { Console.WriteLine("Du kan fortfarande inte dela med noll...");
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Den här fångar alla exceptions för den är generell.");
                Console.WriteLine(ex.Message);
            }
            //Uppgift 20.
            try
            {
                Console.WriteLine("Den här provningen har ingen catch...");
            }
            finally
            {
                Console.WriteLine("Så den kunde jag inte lägga något fel i eftersom då startade inte programmet..");
            }

            //TryParse
            int.TryParse("123", out int enkelt);
            double.TryParse("32,32", out double dubbel);
            bool.TryParse("true" out bool sant);
            float.TryParse("320.32", out float flytande);
            long.TryParse("435430011", out long långtresultat);
            Console.WriteLine(enkelt);
            Console.WriteLine(dubbel);
            Console.WriteLine(sant);
            Console.WriteLine(flytande);
            Console.WriteLine(långtresultat);
        }
        //DivideByZeroException
        public static int IntDivide(int täljare, int nämnare)
        {
            if (nämnare == 0)
                throw new DivideByZeroException("Du kan fan inte dela med noll.");
            int kvot = täljare / nämnare;
            return kvot;
        }
        //IndexOutOfRangeException
        public static void IndexIsWrong(string[] arr, int index)
        {
            if (index > arr.Length)
                throw new IndexOutOfRangeException("Index är utanför gränserna.");

             Console.WriteLine($"{arr[index]}");

        }
        //FormatException
        public static int StringToInt(string input)
        {
            try 
            {
                int result = int.Parse(input);
                return result;
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Konverteringen lyckades inte.");
                Console.WriteLine(ex.Message);
                return 0;
                
            }
        }
        //IfNameIsNull
        public static void IfNameIsNull(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Namn får inte vara tomt.");
            }
            else
            {
                Console.WriteLine($"Välkommen {name}");
            }
        }
        public class MinException : Exception
        {
            public string Name { get; }
            public MinException(string msg, string invalidName) : base(msg)
            {
                Name = invalidName;
            }
        }
    }
}
