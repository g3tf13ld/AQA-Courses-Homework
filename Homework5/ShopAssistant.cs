using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Homework5.Models
{
    public class ShopAssistant
    {
        private readonly ShopAggregator _shopAggregator;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ShopAssistant(ShopAggregator shopAggregator)
        {
            _shopAggregator = shopAggregator;
        }

        private List<SmartphonePosition> SearchSmartphone()
        {
            var soughtForSmartphone = DisplayMessageAndReadline("What smartphone you want to buy?");
            Console.WriteLine();
            
            var foundedSmartphoneList = _shopAggregator.FindSmartphone(soughtForSmartphone);
            var availableSmartphoneList = _shopAggregator.FindAvailableSmartphone(foundedSmartphoneList);
            
            while (foundedSmartphoneList.Count == 0 || availableSmartphoneList.Count == 0)
            {
                if (foundedSmartphoneList.Count == 0)
                {
                    soughtForSmartphone = DisplayMessageAndReadline("The product you entered was not found. Please, enter smartphone model one more time.");
                }
                
                if (foundedSmartphoneList.Count != 0 && availableSmartphoneList.Count == 0)
                {
                    soughtForSmartphone = DisplayMessageAndReadline("This item is out of stock");
                }
                
                Console.WriteLine();
                foundedSmartphoneList = _shopAggregator.FindSmartphone(soughtForSmartphone);
                availableSmartphoneList = _shopAggregator.FindAvailableSmartphone(foundedSmartphoneList);
            }
            
            _shopAggregator.SmartphoneDisplayByShop(availableSmartphoneList);

            return foundedSmartphoneList;
        }

        private Shop ChooseShop(List<SmartphonePosition> foundedSmartphoneList)
        {
            var shopChoice = DisplayMessageAndReadline("Choose the shop.");
            var choosedShop = _shopAggregator.ShopBySmartphoneAndName(foundedSmartphoneList, shopChoice);
            Console.WriteLine();
            
            while (choosedShop == null)
            {
                shopChoice = DisplayMessageAndReadline("Shop not found. Choose the shop one more time.");
                choosedShop = _shopAggregator.ShopBySmartphoneAndName(foundedSmartphoneList, shopChoice);
                Console.WriteLine();
            }

            return choosedShop;
        }

        public void PlaceTheOrder(Shop choosedShop)
        {
            var smartphoneChoice = DisplayMessageAndReadline("Choose the smartphone (type full smartphone model).");
            // Check for smartphone existence and availability
            var choosedSmartphone = _shopAggregator.FindSmartphoneByFullMatch(choosedShop, smartphoneChoice);
            Console.WriteLine();
            
            var selectionFlag = true;
            
            while (selectionFlag)
            {
                if (choosedSmartphone != null)
                {
                    DisplayMessageAboutOrder(choosedSmartphone);
                    selectionFlag = false;
                }
                else
                {
                    smartphoneChoice = DisplayMessageAndReadline("Wrong smartphone model. Please, try again.");
                    Console.WriteLine();
                    choosedSmartphone = _shopAggregator.FindSmartphoneByFullMatch(choosedShop, smartphoneChoice);
                }
            }
        }
        
        // Main communication method.
        public void Start()
        {
            PlaceTheOrder(ChooseShop(SearchSmartphone()));
        }

        private void DisplayMessageAboutOrder(SmartphonePosition choosedSmartphone)
        {
            Console.WriteLine($"Order {choosedSmartphone.Model} for the amount of " +
                              $"${choosedSmartphone.Price} has been successfully completed.");
            _logger.Info($"Order {choosedSmartphone.Model} for the amount of " +
                         $"${choosedSmartphone.Price} has been successfully completed.");
        }
        
        private string DisplayMessageAndReadline(string message)
        {
            Console.WriteLine(message);
            _logger.Info(message);
            
            // ToLower() method using to make the case insensitive search
            return Console.ReadLine()?.ToLower();
        }
    }
}