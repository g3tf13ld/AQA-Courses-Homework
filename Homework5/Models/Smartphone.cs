using System;
using Newtonsoft.Json;
using NLog;
using static Homework5.Models.SmartphoneOS;

namespace Homework5.Models
{
    public class Smartphone
    {
        public string Model { get; set; }
        [JsonProperty("OperationSystemType")]
        public SmartphoneOS Os { get; set; }
        private string MarketLaunchDate { get; set; }
        private Logger _logger = LogManager.GetCurrentClassLogger();

        protected virtual void Display()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"OperationSystemType: {Os}");
            Console.WriteLine($"MarketLaunchDate: {MarketLaunchDate}");
            _logger.Info($"Model: {Model}");
            _logger.Info($"OperationSystemType: {Os}");
            _logger.Info($"MarketLaunchDate: {MarketLaunchDate}");
        }
    }
}