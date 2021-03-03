using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Homework5.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [JsonProperty("Phones")]
        public List<SmartphonePosition> Smartphones;

        public void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Id: {Id}");
        }

        public int AvailableSmartphoneModelsCountByOS(SmartphoneOS os)
        {
            var count = 0;
            foreach (var item in Smartphones)
            {
                if (item.OS == os && item.IsAvailable) count++;
            }

            return count;
        }

        public void ShopInfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine($"Available Android smartphones: {AvailableSmartphoneModelsCountByOS(SmartphoneOS.Android)}");
            Console.WriteLine($"AvailableIOS smartphones: {AvailableSmartphoneModelsCountByOS(SmartphoneOS.IOS)}");
            Console.WriteLine($"Available smartphones with unknown OS: {AvailableSmartphoneModelsCountByOS(SmartphoneOS.Unknown)}");
            Console.WriteLine();
        }
    }
}