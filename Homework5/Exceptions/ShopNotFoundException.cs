using System;

namespace Homework5.Exceptions
{
    public class ShopNotFoundException : Exception
    {
        public ShopNotFoundException(){}

        public ShopNotFoundException(string message) : base(message)
        {
            
        }

        public ShopNotFoundException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}