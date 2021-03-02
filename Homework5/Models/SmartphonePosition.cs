using System;

namespace Homework5.Models
{
    public class SmartphonePosition : Smartphone
    {
        
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int ShopId { get; set; }
        
        public override void Display()
        {
            base.Display();
            if (IsAvailable)
                Console.Write($"Available now!\nPrice: ${Price}\n");
            else
                Console.Write($"Not available now =(\nLast price: ${Price}\n");
        }
    }
}