using System;
using Newtonsoft.Json;
using static Homework5.Models.SmartphoneOS;

namespace Homework5.Models
{
    public class Smartphone
    {
        public string Model { get; set; }
        [JsonProperty("OperationSystemType")]
        public SmartphoneOS OS { get; set; }
        public string MarketLaunchDate { get; set; }

        // установка os через конструктор()
        public virtual void Display()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"OperationSystemType: {OS}");
            Console.WriteLine($"MarketLaunchDate: {MarketLaunchDate}");
        }
    }
}