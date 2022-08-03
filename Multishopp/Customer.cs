using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop
{
    public class Customer
    {
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }
        public int Balance { get; set; } = 50000;
        public List<int> FoodShoppingCartIds { get; set; }
        public List<int> ElectronicCartIds { get; set; }
        public List<int> ClothesCartIds { get; set; }
        public List<string> Inventory { get; set; }
        ShopPrices Prices { get; set; }
       

        public Customer(ShopPrices prices)
        {
            FoodShoppingCartIds = new List<int>();
            ElectronicCartIds = new List<int>();
            ClothesCartIds = new List<int>();
            Inventory = new List<string>();
            Prices = prices;
        }
               
        public void AddItemToShoppingCart(int itemId, string shopType)
        {
            switch(shopType)
            {
                case "f":
                    FoodShoppingCartIds.Add(itemId);
                    break;
                case "c":
                    ClothesCartIds.Add(itemId);
                    break;
                case "e":
                    ElectronicCartIds.Add(itemId);
                    break;
                default:
                    break;
            }
            
        }
        public void RemoveItemFromShoppingCart(int itemId, string shopType)
        {
            switch (shopType)
            {
                case "f":
                    FoodShoppingCartIds.Remove(itemId);
                    break;
                case "c":
                    ClothesCartIds.Remove(itemId);
                    break;
                case "e":
                    ElectronicCartIds.Remove(itemId);
                    break;
                default:
                    break;
            }
        }
       
        public void BuyItemsInCart(string shopType)
        {
            var totalPrice = 0;
            switch(shopType)
            {
                case "f":
                    var itemNames = Enum.GetValues((typeof(FoodNames)));

                    foreach (var Item in FoodShoppingCartIds)
                    {
                        var index = Item - 1;
                        var itemType = itemNames.GetValue(index);
                        string itemName = Convert.ToString(itemType);
                        totalPrice += Prices.FoodPrices[index];
                        Inventory.Add(itemName);
                    }
                    Console.WriteLine("Items bought");
                    break;
                case "c":
                    var clothesNames = Enum.GetValues((typeof(ClothesNames)));

                    foreach (var Item in ClothesCartIds)
                    {
                        var index = Item - 1;
                        var itemType = clothesNames.GetValue(index);
                        string itemName = Convert.ToString(itemType);
                        totalPrice += Prices.ClothesShopPrices[index];
                        Inventory.Add(itemName);
                    }
                    Console.WriteLine("Items bought");
                    break;
                case "e":
                    var electronicsNames = Enum.GetValues((typeof(Electronics)));

                    foreach (var Item in ElectronicCartIds)
                    {
                        var index = Item - 1;
                        var itemType = electronicsNames.GetValue(index);
                        string itemName = Convert.ToString(itemType);
                        totalPrice += Prices.ElectronicsPrices[index];
                        Inventory.Add(itemName);
                    }
                    Console.WriteLine("Items bought");
                    break;
                default:
                    break;
            }

            FoodShoppingCartIds = new List<int>();
            ElectronicCartIds = new List<int>();
            ClothesCartIds = new List<int>();
            Balance -= totalPrice;
            Console.WriteLine($"Balance is now: {Balance}");
            Console.WriteLine("Inventory now contains: ");

            foreach(var item in Inventory)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
