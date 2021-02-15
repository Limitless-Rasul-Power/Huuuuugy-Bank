using System;

namespace Bank_Practice.Application_Exceptions
{
    public class AlreadyFullPaidException : ApplicationException
    {
        private readonly string _message = "Your credit is already paid.";
        public override string Message => _message;

        public AlreadyFullPaidException() { }
        public AlreadyFullPaidException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }


}
