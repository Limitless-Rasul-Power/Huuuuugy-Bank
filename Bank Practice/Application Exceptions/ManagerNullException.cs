using System;

namespace Bank_Practice.Application_Exceptions
{
    public class ManagerNullException : ApplicationException
    {
        private readonly string _message = "Manager is null.";
        public override string Message => _message;

        public ManagerNullException() {}
        public ManagerNullException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }

}
