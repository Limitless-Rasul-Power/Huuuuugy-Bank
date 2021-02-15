using System;

namespace Bank_Practice.Application_Exceptions
{
    public class CreditedClientNullException : ApplicationException
    {
        private readonly string _message = "Credited Client is null.";
        public override string Message => _message;

        public CreditedClientNullException() {}
        public CreditedClientNullException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }

}
