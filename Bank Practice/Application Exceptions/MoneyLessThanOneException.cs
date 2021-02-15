using System;

namespace Bank_Practice.Application_Exceptions
{
    public class MoneyLessThanOneException : ApplicationException
    {
        private readonly string _message = "Money is less than 1.";
        public override string Message => _message;

        public MoneyLessThanOneException() { }
        public MoneyLessThanOneException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }

}
