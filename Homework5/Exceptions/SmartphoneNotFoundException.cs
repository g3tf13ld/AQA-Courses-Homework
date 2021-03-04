using System;

namespace Homework5.Exceptions
{
    public class SmartphoneNotFoundException : Exception
    {
        public SmartphoneNotFoundException(){}

        public SmartphoneNotFoundException(string message) : base(message)
        {
            
        }

        public SmartphoneNotFoundException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}