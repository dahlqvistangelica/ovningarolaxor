using KodaISal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodaISal.Models
{ //Klass för produkten. Innehåller enbart metod för att skapa ny produkt samt ToString().
    internal class Product
    {
        private static int idCounter; //Räknar skapade produkter, ökar med ett för varje produkt.
        private int _productID; //Håller id för produkten.
        public int ProductID { get => _productID; }
        private string _name;
        public string Name { get => _name; set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Namn kan inte vara tomt");

                _name = value;
            }
        }
        private int _stockCount;
        public int StockCount { get => _stockCount; set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Lagervärdet kan inte vara negativt.");
                _stockCount = value;
            } }

        private decimal _price;
        public decimal Price { get => _price; set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Pris kan inte vara negativt.");
                _price = value;
            } }
        public string Category { get; set; }
        public Product(string name, int stock, decimal price, string category)
        {
            idCounter++;
            _productID = idCounter;
            Name = name;
            StockCount = stock;
            Price = price;
            Category = category;
        }
        /// <summary>
        /// Skapar en ny produkt på ett säkert sätt. 
        /// </summary>
        /// <returns></returns>
        internal static Product NewProduct()
        {
            string name = InputHandler.StringInput("Produktnamn:", "Du måste ange ett namn på produkten.");
            
            string category = InputHandler.StringInput("Produktkategori:", "Du måste ange en kategori produkten tillhör");
            decimal price = InputHandler.DecimalInput("Ange pris:", "Du måste ange pris med siffor och kommatecken.");
            int stock = InputHandler.IntInput("Ange lagersaldo:", "Du måste ange saldo med siffror.", 0);

            Product product = new Product(name, stock, price, category);
            
            return product;
            
        }
        public override string ToString()
        {
            return $"ID:{ProductID}, Namn:{Name}, Kategori:{Category}, Pris:{Price:C2}, Lagersaldo:{StockCount}";
        }
    }
}
