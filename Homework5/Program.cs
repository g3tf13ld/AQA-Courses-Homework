using Homework5.Models;
using NLog;

namespace Homework5
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Logger.Info(" ----------------- APPLICATION START ----------------- ");
            var aggregator = Utils.JsonConverter.GetShopAggregator(new Utils.JsonReader().ReadFile());
            new ShopAssistant(aggregator).Start();
            Logger.Info(" ------------------ APPLICATION END ------------------ \n");

        }
    }
}