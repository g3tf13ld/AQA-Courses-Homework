using Homework5.Models;
using JsonReader = Homework5.Utils.JsonReader;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            var aggregator = Utils.JsonConverter.GetShopAggregator(new JsonReader().ReadFile());
            new ShopAssistant(aggregator).Start();
        }
    }
}