using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Homework5.Models;
using Newtonsoft.Json;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = $"{basePath}{Path.DirectorySeparatorChar}appsettings.json";

            string str = null;
            var aggregator = new ShopAggregator();
            
            try
            {
                StreamReader sr = new StreamReader(fullPathToFile);
                str = sr.ReadToEnd();
                sr.Close();
                Console.WriteLine("File read successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            
            aggregator = JsonConvert.DeserializeObject<ShopAggregator>(str);

            var assistant = new ShopAssistant(aggregator);
            assistant.Start();

        }
    }
}