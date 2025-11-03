using System.Security.Cryptography.X509Certificates;

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
            try
            {

            }
            catch(FormatException ex)
            {

            }
            catch(DivideByZeroException ex)
            { }

             
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
