using System;

namespace Bank_Practice.Application_Exceptions
{
    public class ClientDidNotFoundException : ApplicationException
    {
        private readonly string _message = "Client did not found.";
        public override string Message => _message;

        public ClientDidNotFoundException() {}
        public ClientDidNotFoundException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }


}
