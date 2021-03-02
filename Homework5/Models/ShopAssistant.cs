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
            var searchArray = searchPhrase.ToLower().Split(new char [] {' ', ',', '.', ':', '\t' });
 
            // foreach (var s in searchArray)
            //     Console.WriteLine(s);

            var tempList = new List<SmartphonePosition>();
            
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
            // Rebuild with shop differentiation
            List<int> shopList = new List<int> {};
            foreach (var smartphoneItem in smartphoneList)
            {
                if (!shopList.Contains(smartphoneItem.ShopId))
                {
                    shopList.Add(smartphoneItem.ShopId);
                }
            }

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
                                    Console.WriteLine($"\t{smartphoneItem.Model}\n\tActual price: ${smartphoneItem.Price}\n");
                                }
                                else
                                {
                                    Console.WriteLine($"\t{smartphoneItem.Model}\n\tOut of stock!\n\tLast price: ${smartphoneItem.Price}\n");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        private void Communicate()
        {
            Console.WriteLine("What smartphone you want to buy?");
            var soughtForSmartphone = Console.ReadLine();
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
                foundedSmartphoneList = FindSmartphone(soughtForSmartphone);
                availableSmartphoneList = FindAvailableSmartphone(foundedSmartphoneList);
            }
            
            SmartphoneDisplayByShop(foundedSmartphoneList);
            
        }

        public void Start()
        {
            Communicate();
        }
    }
}