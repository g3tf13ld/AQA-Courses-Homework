using System;

namespace Homework5.Exceptions
{
    public class SmartphoneOutOfStockException : Exception
    {
        public SmartphoneOutOfStockException(){}

        public SmartphoneOutOfStockException(string message) : base(message)
        {
            
        }

        public SmartphoneOutOfStockException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}