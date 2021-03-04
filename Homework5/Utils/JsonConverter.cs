using System;
using System.Collections.Generic;
using Homework5.Models;
using Newtonsoft.Json;
using NLog;

namespace Homework5.Utils
{
    public static class JsonConverter
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static ShopAggregator GetShopAggregator(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<ShopAggregator>(jsonString);
            }
            catch (Exception ex)
            {
                Logger.Info($"Json deserialize exception: {ex}");
                throw;
            }
        }
    }
}