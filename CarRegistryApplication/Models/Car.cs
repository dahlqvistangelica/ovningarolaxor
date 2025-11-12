using CarRegistryApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistryApplication.Models
{
    internal class Car
    {
        private static int idNum;
        public int IdNumb { get; init; }
        public Brand Brand { get; set; }
        public string Model { get; set; } = "Unknown";

        public MainColor Color { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }

        public Car(Brand brand, string model, MainColor color, double price, bool available)
        {
            idNum++;
            IdNumb = idNum;
            Brand = brand;
            Model = model;
            Color = color;
            Price = price;
            IsAvailable = available;
        }
        internal static MainColor GetMainColor()
        {
            Console.WriteLine("Available colors:");
            Console.WriteLine("1 - White");
            Console.WriteLine("2 - Black");
            Console.WriteLine("3 - Grey");
            Console.WriteLine("4 - Yellow");
            Console.WriteLine("5 - Green");
            Console.WriteLine("6 - Blue");
            Console.WriteLine("7 - Purple");
            Console.WriteLine("8 - Red");
            Console.WriteLine("9 - Pink");
            Console.WriteLine("10 - Orange");
            Console.WriteLine("11 - None/Other");
            int inputColor = UserInputHandler.IntInputValues("Choose color(1-10):", "Invalid input, try again.", "Input must be a number between 1-11", 11, 1);
            return inputColor switch
            {
                1 => MainColor.White,
                2 => MainColor.Black,
                3 => MainColor.Grey,
                4 => MainColor.Yellow,
                5 => MainColor.Green,
                6 => MainColor.Blue,
                7 => MainColor.Purple,
                8 => MainColor.Red,
                9 => MainColor.Pink,
                10 => MainColor.Orange,
                _ => MainColor.None
            };
        }
        internal static Brand GetBrand()
        {
            Console.WriteLine("Available carbrands:");
            Console.WriteLine("1 - Audi");
            Console.WriteLine("2 - BMW");
            Console.WriteLine("3 - Citroen");
            Console.WriteLine("4 - Dodge");
            Console.WriteLine("5 - Mercedes");
            Console.WriteLine("6 - Nissan");
            Console.WriteLine("7 - Subaru");
            Console.WriteLine("8 - Toyota");
            Console.WriteLine("9 - Volkswagen");
            Console.WriteLine("10 - Volvo");
            Console.WriteLine("11 - Unknown");
            int inputBrand = UserInputHandler.IntInputValues("Choose carbrand (1-10):", "Invalid input, try again.", "Input must be a number between 1-11", 11, 1);
            return inputBrand switch
            {
                1 => Brand.Audi,
                2 => Brand.BMW,
                3 => Brand.Citroen,
                4 => Brand.Dodge,
                5 => Brand.Mercedes,
                6 => Brand.Nissan,
                7 => Brand.Subaru,
                8 => Brand.Toyota,
                9 => Brand.Volkswagen,
                10 => Brand.Volvo,
                _ => Brand.Unknown
            };
        }

        public override string ToString()
        {
            return $"Brand:{this.Brand}, Model:{this.Model}, Color:{this.Color}, Price:{this.Price:C2}, Available:{(this.IsAvailable ? "Yes" : "No")}";
        }

    }
    enum Brand { Audi, BMW, Citroen, Dodge, Subaru, Mercedes, Nissan, Toyota, Volvo, Volkswagen, Unknown };
    enum MainColor { White, Pink, Black, Blue, Red, Purple, Grey, Green, Yellow, Orange, None};

}
