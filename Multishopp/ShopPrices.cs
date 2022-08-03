using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop
{
    public class ShopPrices
    {
        public int[] ClothesShopPrices { get; set; }
        public int[] ElectronicsPrices { get; set; }
        public int[] FoodPrices { get; set; }
        Random random { get; set; } = new Random();

        public ShopPrices()
        {
            ClothesShopPrices = new int[5];
            ElectronicsPrices = new int[4];
            FoodPrices = new int[5];

            for (int i = 0; i < 5; i++)
            {
                FoodPrices[i] = random.Next(25, 100);
                if (i < 4)
                {
                    ElectronicsPrices[i] = random.Next(3000, 13000);
                }
                
                ClothesShopPrices[i] = random.Next(100, 899);
            }
        }
    }
}
