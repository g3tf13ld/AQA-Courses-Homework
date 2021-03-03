using System.Collections.Generic;
using Homework5.Models;
using Newtonsoft.Json;

namespace Homework5.Utils
{
    public static class JsonConverter
    {
        public static ShopAggregator GetShopAggregator(string jsonString)
        {
            return JsonConvert.DeserializeObject<ShopAggregator>(jsonString);
        }
    }
}