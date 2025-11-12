using CarRegistryApplication.Models;
using CarRegistryApplication.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistryApplication.Services
{
    internal class CarHandler
    {
        internal List<Car> cars;

        public CarHandler()
        {
            cars = new List<Car> { new Car(Brand.BMW, "X5", MainColor.Purple, 45000, true),
            new Car(Brand.Subaru, "Impreza", MainColor.Blue, 35000, true),
            new Car(Brand.Dodge, "Import", MainColor.Black, 55000, true),
            new Car(Brand.Volvo, "XC90", MainColor.Grey, 42000, true)};
           
        }

        internal void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Add new car");
            Brand brand = Car.GetBrand();
            string model = UserInputHandler.StringInput("Enter model:", "You must enter a model name.");
            Console.Clear();
            MainColor color = Car.GetMainColor();
            Console.Clear();
            double price = UserInputHandler.DoubleInput("Enter price:", "Invalid input, try again.");
            bool available = UserInputHandler.BoolInput("Is the car for sale now? (yes/no)", "You must enter yes or no.", "yes", "no");
            Console.Clear();
            Console.WriteLine($"The car you want to add: ");
            Console.WriteLine($"Brand: {brand}, Model: {model}, Color: {color}, Price: {price}, For sale: {(available ? "Yes" : "No" )}");
            bool add = UserInputHandler.BoolInput("Do you want to add this car to the registry?", "You must enter yes or no.", "yes", "no");
            if(add)
            {
                Car car = new Car(brand, model, color, price, available);
                cars.Add(car);
                Console.WriteLine("The car has been added to the registry.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Returning to menu.");
                Console.ReadLine();
                return;
            }

        }
            
        internal void ShowCars()
        {
            Console.Clear();
            Console.WriteLine("Show all cars.");
            cars.OrderBy(c => c.IdNumb);
            if(cars.Count <= 0)
            { Console.WriteLine("No cars in registry.");
                Console.ReadLine(); return; }    
            foreach(Car car in cars)
            {
                Console.WriteLine($"Id: {car.IdNumb}, Brand:{car.Brand}, Model:{car.Model}, Color:{car.Color}, Price:{car.Price:C2}, Available:{(car.IsAvailable ? "Yes" : "No")}");
            }
            
        }
        internal void RemoveCar()
        {
            Console.Clear();
            Console.WriteLine("Remove car from registry");
            if (cars.Count <= 0)
            {
                Console.WriteLine("No cars in registry.");
                Console.ReadLine(); 
                return;
            }
            else
            {
                ShowCars();
                Console.WriteLine();
                int idToRemove = UserInputHandler.IntInput("Which car do you want to remove? Enter id:", "Invalid input. Try again.");
                var carToRemove = cars.FirstOrDefault(c => c.IdNumb == idToRemove);
                if (carToRemove is null)
                {
                    Console.WriteLine("Car could not be found. Returning to menu.");
                    Console.ReadLine();
                    return;
                }
                if (cars.Remove(carToRemove))
                {
                    Console.WriteLine("Car was successfully removed from registry");
                    Console.WriteLine("Returning to menu.");
                    Console.ReadLine();
                    return;
                }
            }
        }
        internal void ChangeCar()
        {
            Console.Clear();
            Console.WriteLine("Available cars in registry");
            if (cars.Count <= 0)
            {
                Console.WriteLine("No cars in registry.");
                Console.ReadLine();
                return;
            }
            else
            {
                ShowCars();
                Console.WriteLine();
                int idToChange = UserInputHandler.IntInput("Which car do you want to change? Enter id:", "Invalid input, try again.");
                var carToChange = cars.FirstOrDefault(c => c.IdNumb == idToChange);
                if (carToChange is null)
                {
                    Console.WriteLine("Car could not be found. Returning to menu.");
                    Console.ReadLine();
                    return;
                }
                Console.Clear();
                Console.WriteLine("Chosen car:\n" + carToChange.ToString());
                Console.WriteLine();
                int whatToChange = UserInputHandler.IntInput("Options: \n" +
                    "1 - Brand\n" +
                    "2 - Model\n" +
                    "3 - Color\n" +
                    "4 - Price\n" +
                    "5 - Available\n" +
                    "What do you want to edit (1-5):", "Invalid input, try again.");
                switch (whatToChange)
                {
                    case 1:
                        Brand brand = Car.GetBrand();
                        carToChange.Brand = brand;
                        Console.WriteLine("Brand changed successfully.");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine($"Old Model: {carToChange.Model}");
                        string newModel = UserInputHandler.StringInput("Enter new model:", "Invalid input, try again.");
                        carToChange.Model = newModel;
                        Console.WriteLine("Model changed successfully.");
                        Console.ReadLine();
                        break;
                    case 3:
                        MainColor color = Car.GetMainColor();
                        carToChange.Color = color;
                        Console.WriteLine("Color changed successfully.");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine($"Old price: {carToChange.Price}");
                        double newPrice = UserInputHandler.DoubleInput("Enter new price:", "Invalid price, try again.");
                        carToChange.Price = newPrice;
                        Console.WriteLine("Price changed successfully.");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine();
                        bool newStatus = UserInputHandler.BoolInput($"Do you want to set the car to {(carToChange.IsAvailable ? "unavailable" : "for sale")}?", "Invalid input, you must enter yes or no", "yes", "no");
                        if (newStatus)
                        {
                            if (carToChange.IsAvailable)
                            {
                                carToChange.IsAvailable = false;
                                Console.WriteLine("Car is now marked as unavailable.");
                            }
                            else
                            {
                                carToChange.IsAvailable = true;
                                Console.WriteLine("Car is now marked as for sale.");
                            }
                        }
                        break;
                        default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }


        }

        internal void SearchCar()
        {
            Console.Clear();
            Console.WriteLine("Search options:");
            Console.WriteLine("1 - Model");
            Console.WriteLine("2 - Color");
            Console.WriteLine("3 - Price");
            int searchChoice = UserInputHandler.IntInputValues("Search for 1-3:", "Invalid input", "Input must be a value between 1 - 3.", 4, 1);
            switch(searchChoice)
            {
                case 1:
                    string modelSearch = UserInputHandler.StringInput("Find model:", "You must enter a model");
                    var modelsMatching = cars.Where(c => c.Model.ToLower().Contains(modelSearch.ToLower()))
                        .OrderByDescending(c => c.Brand)
                        .ToList();
                    if (modelsMatching.Count <= 0)
                    {
                        Console.WriteLine("No matches found.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Found matches: ");
                        foreach (var model in modelsMatching)
                        {
                            Console.WriteLine(model.ToString());
                        }
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    MainColor colorSearch = Car.GetMainColor();
                    var colorMatching = cars.Where(c => c.Color == colorSearch)
                        .OrderBy(c => c.Brand)
                        .ToList();
                    if (colorMatching.Count <= 0)
                    {
                        Console.WriteLine("No matches found.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Found matches: ");
                        foreach (var car in colorMatching)
                        {
                            Console.WriteLine(car.ToString());
                        }
                        Console.ReadLine();
                    }
                        break;
                case 3:
                    Console.WriteLine("Filter by price: ");
                    double maxprice = UserInputHandler.DoubleInput("Maximum price:", "Input must contain numbers, try again");
                    double minprice = UserInputHandler.DoubleInput("Minimum price:", "Input must contain numbers, try again");
                    while (maxprice < minprice)
                    { Console.WriteLine("Maximum price can't be lower than minimum price!");
                        maxprice = UserInputHandler.DoubleInput("Enter new maximum price:", "Input must contain numbers, try again");
                    }
                    var priceMatching = cars.Where(c => (c.Price > minprice) && (c.Price < maxprice))
                        .OrderByDescending(c => c.Price)
                        .ToList();
                    if (priceMatching.Count <= 0)
                    {
                        Console.WriteLine("No matches found.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Found matches: ");
                        foreach (var car in priceMatching)
                        {
                            Console.WriteLine(car.ToString());
                        }
                        Console.ReadLine();
                        
                    }
                        break;
                    default: Console.WriteLine("Invalid choice, returning to menu."); 
                    return;
                    
            }

        }

    }
}
