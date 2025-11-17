using KodaISal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodaISal.Services
{
    internal class StockHandler
        //Klass för att hantera listan med produkter på olika sätt.
    {
        private List<Product> products;

        public StockHandler()
        {
            products = new List<Product>
            {
            };
        }

        /// <summary>
        /// Metod för att lägga till ny produkt i listan. Låter användaren skapa en ny produkt för att därefter få välja om hen vill lägga in den i lagret.
        /// </summary>
        public void AddProduct()
        {
            Console.WriteLine("---- LÄGG TILL NY PRODUKT ----");
            Product product = Product.NewProduct();
            CheckName(product);
            AddToStock(product);
        }
        /// <summary>
        /// Kontrollerar så inte produkter får samma namn. Ber användaren om ett nytt namn om namnet redan finns.
        /// </summary>
        /// <param name="product"></param>
        private void CheckName(Product product)
        {
            while (products.Any(p => p.Name.ToLower().Equals(product.Name.ToLower())))
            {
                Console.WriteLine($"Det finns redan en produkt med namnet {product.Name.ToLower()}.");
                string newName = InputHandler.StringInput("Ange ett nytt namn:", "Namnet kan inte vara blankt.");
                product.Name = newName;
            }
        }
        /// <summary>
        /// Bekräftar att produkten har skapats och vilket id den får samt bekräftar att den ska läggas till i lagret.
        /// </summary>
        /// <param name="product"></param>
        private void AddToStock(Product product)
        {
            Console.WriteLine($"Produkt {product.Name} skapades och tilldelades id {product.ProductID}");
            bool wishToAdd = InputHandler.BoolInput("Vill du lägga till produkten på lagret?", "Du måste ange ja/j eller nej/n", "ja", 'j', "nej", 'n');
            if (wishToAdd)
            {
                products.Add(product);
                Console.WriteLine($"Produkten {product.Name} lades till i lagret.");
            }
            if (!wishToAdd)
            {
                Console.WriteLine($"Produkten {product.Name} lades inte till och kommer nu tas bort ur systemet.");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Visar alla produkter som finns i listan, sorterade på id-nummer.
        /// </summary>
        public void ShowProducts()
        {
            products.OrderBy(p => p.ProductID);
            if(products.Count > 0)
            {
                foreach(var item in products)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Inga produkter i lager.");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Metod för att ta bort produkt i listan.
        /// </summary>
        private void DeleteProduct()
        {
            
                int maxIdNumb = products.Max(p => p.ProductID);
                int IDToDelete = InputHandler.IntInput("Ange produktid för produkt du önskar ta bort:", "Du måste ange en siffra. Om du ångrar dig, skriv 0.", maxIdNumb, "Finns inget id som är så högt.");
                if (IDToDelete == 0)
                    return;
                var productToDelete = products.FirstOrDefault(p => p.ProductID.Equals(IDToDelete));
                Console.WriteLine("Är du säker på att du vill ta bort");
                Console.WriteLine(productToDelete.ToString());
                bool ifSureToDelete = InputHandler.BoolInput("Ange ja/j eller nej/n:", "Du måste ange ja/j eller nej/n för att bekräfta ditt val.", "ja", 'j', "nej", 'n');
                if (ifSureToDelete)
                {
                    if (products.Remove(productToDelete))
                    {
                        Console.WriteLine("Borttagning genomförd, återvänder till huvudmeny");
                        Console.ReadLine();
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("Borttagning ångrad, återvänder till huvudmeny.");
                    Console.ReadLine();
                    return;
                }
            
        }
        /// <summary>
        /// Hanterar om det inte finns några produkter tillagda. Skickar annars vidare användaren för att ta bort produkt.
        /// </summary>
        public void WantToDeleteProduct()
        {
            Console.WriteLine("---- TA BORT PRODUKT ----");
            if (products.Count > 0)
            {
                ShowProducts();
                DeleteProduct();
            }
            else
            {
                Console.WriteLine("Det finns inga produkter i lager, borttagning är inte möjlig.");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Visar sökalternativ och skickar användaren vidare till valt alternativ.
        /// </summary>
        public void FindProduct()
        {
            Console.WriteLine("---- SÖK PRODUKT ----");
            if (products.Count > 0)
            {
                
                Console.WriteLine("1 - Sök på namn");
                Console.WriteLine("2 - Sök på kategori");
                Console.WriteLine("3 - Filtrera på pris");
                int searchChoice = InputHandler.IntInput("Vad vill du söka på (1-3, 0 för att backa)?", "Du måste ange en siffra mellan 1-3.");
                if (searchChoice == 0)
                    return;
                switch (searchChoice)
                {
                    case 1:
                        Console.Clear();
                        SearchForName();
                        break;
                    case 2:
                        Console.Clear();
                        SearchForCategory();
                        break;
                    case 3:
                        Console.Clear();
                        SearchForMaxPrice();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, återvänder till huvudmeny");
                        return;
                }
            }
            else
            {
                Console.WriteLine("Det finns inga produkter i lager, sökning är inte möjlig.");
                Console.ReadLine();
            }

}
        /// <summary>
        /// Metod för att söka efter produkt på produktnamn.
        /// </summary>
        private void SearchForName()
        {
            string searchForName = InputHandler.StringInput("Ange namn att söka efter:", "Du måste ange något att söka på.");
            var foundProductsMatchingName = products.Where(p => p.Name.ToLower().Contains(searchForName.ToLower()))
                                            .OrderBy(p => p.Name)
                                            .ToList();
            if (foundProductsMatchingName.Count < 0)
                Console.WriteLine($"Inga produkter matchande \"{searchForName}\" hittades.");
            else
            {
                Console.WriteLine($"Funna produkter matchande \"{searchForName}\":");
                foreach (var item in foundProductsMatchingName)
                { Console.WriteLine(item.ToString()); }
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Metod för filtrera produkter på maxpris.
        /// </summary>
        private void SearchForMaxPrice()
        {
            decimal maxprice = InputHandler.DecimalInput("Ange maxpris att visa:", "Du måste ange ett pris med siffror och kommatecken");
            var foundProductsWithMaxPrice = products.Where(p => p.Price <= maxprice)
                                                    .OrderBy(p => p.Price)
                                                    .ToList();
            if (foundProductsWithMaxPrice.Count < 0)
            {
                Console.WriteLine($"Inga produkter med maxpris under eller lika med {maxprice}.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Funna produkter med maxpris under eller lika med \"{maxprice}\":");
                foreach (var item in foundProductsWithMaxPrice)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Metod för att söka och gruppera produkter efter kategori.
        /// </summary>
        private void SearchForCategory()
        {
            string searchForCategory = InputHandler.StringInput("Ange kategori att söka efter:", "Du måste ange något att söka på.");
            var foundProductsMatchingCategory = products.Where(p => p.Category.ToLower().Contains(searchForCategory.ToLower()))                          .GroupBy(p => p.Category)
                                            .ToList();
            if (foundProductsMatchingCategory.Count < 0)
                Console.WriteLine($"Inga produkter matchande \"{searchForCategory}\" hittades.");
            else
            {
                Console.WriteLine($"Funna produkter matchande \"{searchForCategory}\":");
                foreach (var group in foundProductsMatchingCategory)
                {
                    Console.WriteLine(group.Key+ ":");
                    foreach (var item in group)
                    { Console.WriteLine(item.ToString()); }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Hanterar om användaren vill ändra lagersaldo men inga produkter är inlagda samt skickar användaren vidare till UpdateStockCount om produkter finns.
        /// </summary>
        public void ChangeStockCount()
        {
            Console.WriteLine("---- ÄNDRA LAGERSALDO ----");
            if (products.Count > 0)
            {
                UpdateStockCount();
            }
            else
            {
                Console.WriteLine("Det finns inga produkter i lager att ändra.");
                Console.ReadLine();
            }

        }
        /// <summary>
        /// Låter användaren ändra lagersaldo på produkt.
        /// </summary>
        private void UpdateStockCount()
        {
          
                
                ShowProducts();
                int maxIdNumb = products.Max(p => p.ProductID);
                Console.WriteLine("Ange 0 för att komma tillbaka till huvudmenyn");
                int idToChange = InputHandler.IntInput("Ange id för produkten du vill uppdatera lagersaldo för:", "Ogiltigt id, försök igen", maxIdNumb, "Finns inget id som är så högt.");
                if (idToChange == 0)
                    return;
                var productToChange = products.FirstOrDefault(p => p.ProductID.Equals(idToChange));
                bool confirmProduct = InputHandler.BoolInput($"Är det {productToChange.Name} du önskar ändra lagersaldo för? Ange ja/j eller nej/n.", "Ogiltigt val, du måste skriva ja/j eller nej/n", "ja", 'j', "nej", 'n');
                if (confirmProduct)
                {
                    int newStockCount = InputHandler.IntInput("Ange nytt lagersaldo:", "Ogiltig inmatning, saldo måste vara minst 0", 0);
                    productToChange.StockCount = newStockCount;
                    Console.WriteLine($"Nytt lagersaldo för {productToChange.Name} är {productToChange.StockCount}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Återvänder till huvudmeny.");
                    Console.ReadLine();
                    return;
                }


        }


    }
}
