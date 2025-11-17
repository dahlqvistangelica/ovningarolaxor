using CarRegistryApplication.Services;
using CarRegistryApplication.Models;

namespace CarRegistryApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarHandler carHandler = new CarHandler();
            UI.ShowMenu(carHandler);
        }
    }
}
