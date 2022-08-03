using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiShop
{
    class Program
    {
        static void Main(string[] args)
        {           
          
            bool inShop = true;
            ShopPrices prices = new ShopPrices();
            var customer = new Customer(prices);
            while (inShop)
            {
                Console.WriteLine("*************************");
                Console.WriteLine("Welcome to the Multishop, what kind of shop do you want to enter?");
                Console.WriteLine("Food shop = f");
                Console.WriteLine("Clothes shop = c");
                Console.WriteLine("Electronics shop = e");
                Console.WriteLine("Exit shop = x");
                var x = Console.ReadLine();
                switch(x)
                {
                    case "f":
                        var canAfford = OpenFoodShop(customer,prices);
                        if (canAfford)
                        {
                            customer.BuyItemsInCart("f");
                        }                        
                        break;
                    case "c":
                        var canAffordClothes = OpenClothesShop(customer, prices);
                        if (canAffordClothes)
                        {
                            customer.BuyItemsInCart("c");
                        }
                        break;
                    case "e":
                        var canAffordElectrics = OpenElectricsShop(customer, prices);
                        if (canAffordElectrics)
                        {
                            customer.BuyItemsInCart("e");
                        }                        
                        break;
                    default:
                        inShop = false;
                        break;
                }
            }
        }

        private static bool OpenFoodShop(Customer customer, ShopPrices prices)
        {
            var foodShop = new FoodShop(prices);
            foodShop.AddItemsToShop();           
            foodShop.PrintItems();
            Console.WriteLine("*************************");
            Console.WriteLine("What do you want to buy?");
   
            var itemNumber = Console.ReadLine();           
            var itemIdInt = Convert.ToInt32(itemNumber);
            customer.AddItemToShoppingCart(itemIdInt,"f");
            string[] itemIds = new string[customer.FoodShoppingCartIds.Count];
            for (int i = 0; i < customer.FoodShoppingCartIds.Count; i++)
            {
                itemIds[i] = customer.FoodShoppingCartIds[i].ToString();
            }
            foodShop.PrintItemsInCart(customer);
            return foodShop.CheckOut(customer);
        }

        private static bool OpenClothesShop(Customer customer, ShopPrices prices)
        {
            var clothesShop = new ClothesShop(prices);
            clothesShop.AddItemsToShop();
            clothesShop.PrintItems();
            Console.WriteLine("*************************");
            Console.WriteLine("What do you want to buy?");

            var itemNumber = Console.ReadLine();           
            var itemIdInt = Convert.ToInt32(itemNumber);
            customer.AddItemToShoppingCart(itemIdInt,"c");
            string[] itemIds = new string[customer.ClothesCartIds.Count];
            for (int i = 0; i < customer.ClothesCartIds.Count; i++)
            {
                itemIds[i] = customer.ClothesCartIds[i].ToString();
            }
            clothesShop.PrintItemsInCart(customer);
            return clothesShop.CheckOut(customer);
        }
        private static bool OpenElectricsShop(Customer customer, ShopPrices prices)
        {
            var electronics = new ElectronicsShop(prices);
            electronics.AddItemsToShop();
            electronics.PrintItems();
            Console.WriteLine("*************************");
            Console.WriteLine("What do you want to buy?");

            var itemNumber = Console.ReadLine();           
            var itemIdInt = Convert.ToInt32(itemNumber);
            customer.AddItemToShoppingCart(itemIdInt,"e");
            string[] itemIds = new string[customer.ElectronicCartIds.Count];
            for (int i = 0; i < customer.ElectronicCartIds.Count; i++)
            {
                itemIds[i] = customer.ElectronicCartIds[i].ToString();
            }
            electronics.PrintItemsInCart(customer);
            return electronics.CheckOut(customer);
        }
    }
}
