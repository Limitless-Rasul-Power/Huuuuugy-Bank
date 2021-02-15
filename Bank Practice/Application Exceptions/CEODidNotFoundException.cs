using System;

namespace Bank_Practice.Application_Exceptions
{
    public class CEODidNotFoundException : ApplicationException
    {
        private readonly string _message = "CEO did not found.";
        public override string Message => _message;

        public CEODidNotFoundException() { }
        public CEODidNotFoundException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }

}
