using KodaISal.Services;
using KodaISal.UI;
using System;

namespace KodaISal
{
    internal class Program
    {
        static void Main(string[] args)
        { //Om eventuella fel skulle uppstå hanteras dessa här.
            //OBS! Jag har valt att lagersaldo kan vara 0, eftersom det kan vara det på riktigt. Det kan dock inte vara under noll och alltså inte negativt.    
            try
            {
                StockHandler handler = new StockHandler();
                Menu.StartUpMenu(handler);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
           catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
