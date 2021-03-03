using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Homework5.Models
{
    public class ShopAssistant
    {
        public ShopAggregator ShopAggregator;

        public ShopAssistant(ShopAggregator shopAggregator)
        {
            ShopAggregator = shopAggregator;
        }

        private List<SmartphonePosition> FindSmartphone(string searchPhrase)
        {
            var tempList = new List<SmartphonePosition>();
            var searchArray = searchPhrase.Split(new char [] {' ', ',', '.', ':', '\t' });
 
            // foreach (var s in searchArray)
            //     Console.WriteLine(s);

            foreach (var shopItem in ShopAggregator.Shops)
            {
                foreach (var  smartphoneItem in shopItem.Smartphones)
                {
                    foreach (var searchWord in searchArray)
                    {
                        if (smartphoneItem.Model.ToLower().Contains(searchWord) && !tempList.Contains(smartphoneItem))
                        {
                            tempList.Add(smartphoneItem);
                        }
                    }
                }
            }
            
            return tempList;
        }

        private List<SmartphonePosition> FindAvailableSmartphone(List<SmartphonePosition> smartphoneList)
        {
            return
                (from smartphoneItem in smartphoneList
                    where smartphoneItem.IsAvailable.Equals(true)
                    select smartphoneItem).ToList();
        }

        private void SmartphoneDisplayByShop(List<SmartphonePosition> smartphoneList)
        {
            // List of all shops that contains sought-for smartphones
            List<int> shopList = new List<int> {};
            foreach (var smartphoneItem in smartphoneList)
            {
                if (!shopList.Contains(smartphoneItem.ShopId))
                {
                    shopList.Add(smartphoneItem.ShopId);
                }
            }

            var counter = 0;
            foreach (var shopIdItem in shopList)
            {
                foreach (var shopItem in ShopAggregator.Shops)
                {
                    if (shopItem.Id == shopIdItem)
                    {
                        shopItem.Display();
                        foreach (var smartphoneItem in smartphoneList)
                        {
                            if (smartphoneItem.ShopId == shopIdItem)
                            {
                                if (smartphoneItem.IsAvailable)
                                {
                                    Console.WriteLine($"\t{++counter}. {smartphoneItem.Model}");
                                    Console.WriteLine($"\tActual price: ${smartphoneItem.Price}\n");
                                }
                                else
                                {
                                    Console.WriteLine($"\t{++counter}. {smartphoneItem.Model}");
                                    Console.WriteLine("\tOut of stock!");
                                    Console.WriteLine($"\tLast price: ${smartphoneItem.Price}\n");
                                }
                            }
                        }
                        counter = 0;
                        Console.WriteLine();
                    }
                }
            }
        }

        // Check if the stores have smartphones from the list and if the store name matches the desired one
        private bool IsTrueShopChoice(List<SmartphonePosition> smartphoneList, string shopName)
        {
            foreach (var shop in ShopAggregator.Shops)
            {
                foreach (var smartphone in smartphoneList)
                {
                    if (shop.Id == smartphone.ShopId && shop.Name.ToLower().Equals(shopName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        private void Communicate()
        {
            Console.WriteLine("What smartphone you want to buy?");
            
            // ToLower() method use to make the case insensitive search  
            var soughtForSmartphone = Console.ReadLine()?.ToLower();
            Console.WriteLine();
            var foundedSmartphoneList = FindSmartphone(soughtForSmartphone);
            var availableSmartphoneList = FindAvailableSmartphone(foundedSmartphoneList);
            
            while (foundedSmartphoneList.Count == 0 || availableSmartphoneList.Count == 0)
            {
                if (foundedSmartphoneList.Count == 0)
                {
                    Console.WriteLine("The product you entered was not found. Please, enter smartphone model one more time.");
                }
                
                if (foundedSmartphoneList.Count != 0 && availableSmartphoneList.Count == 0)
                {
                    Console.WriteLine("This item is out of stock");
                }
                
                soughtForSmartphone = Console.ReadLine();
                Console.WriteLine();
                foundedSmartphoneList = FindSmartphone(soughtForSmartphone);
                availableSmartphoneList = FindAvailableSmartphone(foundedSmartphoneList);
            }
            
            SmartphoneDisplayByShop(foundedSmartphoneList);

            Console.WriteLine("Choose the shop.");
            var shopChoice = Console.ReadLine()?.ToLower();
            var shopFlag = IsTrueShopChoice(foundedSmartphoneList, shopChoice);
            
            while (!shopFlag)
            {
                Console.WriteLine("Shop not found. Choose the shop one more time.");
                shopChoice = Console.ReadLine()?.ToLower();
                shopFlag = IsTrueShopChoice(foundedSmartphoneList, shopChoice);
            }

            Console.WriteLine("Choose the smartphone.");
            var smartphoneChoice = Console.ReadLine()?.ToLower();
            
        }

        public void Start()
        {
            Communicate();
        }
    }
}