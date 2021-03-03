using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NLog;

namespace Homework5.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private string Description { get; set; }
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        [JsonProperty("Phones")]
        public List<SmartphonePosition> Smartphones;

        public void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Id: {Id}");
            _logger.Info($"Name: {Name}");
            _logger.Info($"Description: {Description}");
            _logger.Info($"Id: {Id}");
        }

        private int AvailableSmartphoneModelsCountByOs(SmartphoneOS os)
        {
            var count = 0;
            foreach (var item in Smartphones)
            {
                if (item.Os == os && item.IsAvailable) count++;
            }

            return count;
        }

        public void ShopInfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine($"Available Android smartphones: {AvailableSmartphoneModelsCountByOs(SmartphoneOS.Android)}");
            Console.WriteLine($"AvailableIOS smartphones: {AvailableSmartphoneModelsCountByOs(SmartphoneOS.IOS)}");
            Console.WriteLine($"Available smartphones with unknown OS: {AvailableSmartphoneModelsCountByOs(SmartphoneOS.Unknown)}");
            Console.WriteLine();
            _logger.Info(Name);
            _logger.Info(Description);
            _logger.Info($"Available Android smartphones: {AvailableSmartphoneModelsCountByOs(SmartphoneOS.Android)}");
            _logger.Info($"AvailableIOS smartphones: {AvailableSmartphoneModelsCountByOs(SmartphoneOS.IOS)}");
            _logger.Info($"Available smartphones with unknown OS: {AvailableSmartphoneModelsCountByOs(SmartphoneOS.Unknown)}");
        }
    }
}