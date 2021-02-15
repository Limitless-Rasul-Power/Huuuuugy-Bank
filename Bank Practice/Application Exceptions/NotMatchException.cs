using System;

namespace Bank_Practice.Application_Exceptions
{
    public class NotMatchException : ApplicationException
    {
        private readonly string _message = "Not match.";
        public override string Message => _message;

        public NotMatchException() { }
        public NotMatchException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }
}
