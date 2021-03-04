using System;

namespace Homework5.Exceptions
{
    public class WrongSmartphoneChoiceException : Exception
    {
        public WrongSmartphoneChoiceException(){}

        public WrongSmartphoneChoiceException(string message) : base(message)
        {
            
        }

        public WrongSmartphoneChoiceException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}