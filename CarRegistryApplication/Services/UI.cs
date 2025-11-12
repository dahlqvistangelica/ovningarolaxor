using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistryApplication.Services
{
    internal static class UI
    {
        internal static void ShowMenu(CarHandler carHandler)
        {
            int input = 0;

            while (input != 6)
            {
                Console.Clear();
                Console.WriteLine("Car Registry Application");
                Console.WriteLine("[1] Add car.");
                Console.WriteLine("[2] Remove car.");
                Console.WriteLine("[3] Edit car details.");
                Console.WriteLine("[4] Show all cars.");
                Console.WriteLine("[5] Search cars.");
                Console.WriteLine("[6] End program.");
                Console.WriteLine("Make your choice: ");
                int.TryParse(Console.ReadLine(), out input);

                switch(input)
                {
                    case 1:
                        //Add car
                        carHandler.AddCar();

                        break;
                    case 2:
                        //Remove car
                        carHandler.RemoveCar();

                        break;
                    case 3:
                        //Edit car
                        carHandler.ChangeCar();
                        break;
                    case 4:
                        //Show cars
                        carHandler.ShowCars();
                        Console.ReadLine();
                        break;
                    case 5:
                        //Search cars
                        carHandler.SearchCar();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
