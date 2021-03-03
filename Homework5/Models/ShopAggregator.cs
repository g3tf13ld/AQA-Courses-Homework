using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Homework5.Models
{
    public class ShopAggregator
    {
        public List<Shop> Shops;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        public void SmartphoneDisplayByShop(List<SmartphonePosition> smartphoneList)
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

            // The method can be used to display the assortment taking into account the availability
            var counter = 0;
            foreach (var shopIdItem in shopList)
            {
                foreach (var shopItem in Shops)
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
                                    _logger.Info($"\t{++counter}. {smartphoneItem.Model}");
                                    _logger.Info($"\tActual price: ${smartphoneItem.Price}\n");
                                }
                                else
                                {
                                    Console.WriteLine($"\t{++counter}. {smartphoneItem.Model}");
                                    Console.WriteLine("\tOut of stock!");
                                    Console.WriteLine($"\tLast price: ${smartphoneItem.Price}\n");
                                    _logger.Info($"\t{++counter}. {smartphoneItem.Model}");
                                    _logger.Info("\tOut of stock!");
                                    _logger.Info($"\tLast price: ${smartphoneItem.Price}\n");
                                }
                            }
                        }
                        counter = 0;
                        Console.WriteLine();
                    }
                }
            }
        }

        public Shop ShopBySmartphoneAndName(List<SmartphonePosition> smartphoneList, string shopName)
        {
            foreach (var shop in Shops)
            {
                foreach (var smartphone in smartphoneList)
                {
                    if (shop.Id == smartphone.ShopId && shop.Name.ToLower().Equals(shopName))
                    {
                        return shop;
                    }
                }
            }

            return null;
        }

        public List<SmartphonePosition> FindSmartphone(string searchPhrase)
        {
            var tempList = new List<SmartphonePosition>();
            var searchArray = searchPhrase.Split(new char [] {' ', ',', '.', ':', '\t' });
            
            // foreach (var s in searchArray)
            //     Console.WriteLine(s);

            foreach (var shopItem in Shops)
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

        public SmartphonePosition FindSmartphoneByFullMatch(Shop shop, string searchPhrase)
        {
            foreach (var smartphoneItem in shop.Smartphones)
            {
                if (smartphoneItem.Model.ToLower().Equals(searchPhrase) && smartphoneItem.IsAvailable)
                {
                    return smartphoneItem;
                }
            }

            return null;
        }
        
        public List<SmartphonePosition> FindAvailableSmartphone(List<SmartphonePosition> smartphoneList)
        {
            return
                (from smartphoneItem in smartphoneList
                    where smartphoneItem.IsAvailable.Equals(true)
                    select smartphoneItem).ToList();
        }
    }
}