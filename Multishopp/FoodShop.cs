using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop
{
    public class FoodShop
    {    
        public string[] Ids { get; set; }
        Random random { get; set; } = new Random();
        ShopPrices Prices { get; set; }
        public FoodShop(ShopPrices prices)
        {
            Prices = prices;
            Ids = new string[5];
        }
        public void AddItemsToShop()
        {
            for (int i = 0; i < 5; i++)
            {
                Ids[i] = $"{i+1}";
            }
        }

        public void PrintItems()
        {
            var itemNames = Enum.GetValues((typeof(FoodNames)));
            int i = 0;
            foreach(var itemName in itemNames)
            {
                var itemNameString = Convert.ToString(itemName);
                PrintItem(Ids[i], itemNameString, Prices.FoodPrices[i]);
                i++;
            } 
        }

        public void PrintItem(string itemId, string itemName, int itemPrice)
        {            
           Console.WriteLine($"item: {itemId} {itemName} costs {itemPrice}.");          
        }

        public void PrintItemsInCart(Customer customer)
        {
            Console.WriteLine("ShoppingCart now has: ");
            var totalPrice = 0;

            if (customer.FoodShoppingCartIds.Count == 0 && customer.ClothesCartIds.Count == 0 && customer.ElectronicCartIds.Count == 0)
            {
                Console.WriteLine("No items in cart!");
                return;
            }

            var foodNames = Enum.GetValues((typeof(FoodNames)));
         
            foreach (var Item in customer.FoodShoppingCartIds)
            {
                var itemNum = Convert.ToInt32(Item);
                var index = itemNum - 1;
                var itemPrice = Prices.FoodPrices[index];
                var itemType = foodNames.GetValue(index);
                string itemName = Convert.ToString(itemType);
                PrintItem(itemNum.ToString(), itemName, itemPrice);
                totalPrice += itemPrice;
            }
            //foreach (var Item in customer.ClothesCartIds)
            //{
            //    var itemNum = Convert.ToInt32(Item);
            //    var index = itemNum - 1;
            //    var itemPrice = Prices.ClothesShopPrices[index];
            //    var itemType = clothesNames.GetValue(index);
            //    string itemName = Convert.ToString(itemType);
            //    PrintItem(itemNum.ToString(), itemName, itemPrice);
            //    totalPrice += itemPrice;
            //}
            //foreach (var Item in customer.ElectronicCartIds)
            //{
            //    var itemNum = Convert.ToInt32(Item);
            //    var index = itemNum - 1;
            //    var itemPrice = Prices.ElectronicsPrices[index];
            //    var itemType = electronicNames.GetValue(index);
            //    string itemName = Convert.ToString(itemType);
            //    PrintItem(itemNum.ToString(), itemName, itemPrice);
            //    totalPrice += itemPrice;
            //}
            Console.WriteLine("total price is: " + totalPrice);
            Console.WriteLine("******************");
            Console.WriteLine();
        }

        public bool CheckOut(Customer customer)
        {
            var totalPrice = 0;
            var itemNames = Enum.GetValues((typeof(FoodNames)));
            foreach (var Item in customer.FoodShoppingCartIds)
            {
                var itemNum = Convert.ToInt32(Item);
                var index = itemNum - 1;
                var itemPrice = Prices.FoodPrices[index];
           
                totalPrice += itemPrice;
            }

            if (customer.Balance >= totalPrice)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You dont have enough funds");
                return false;
            }
           
        }

    }
}
