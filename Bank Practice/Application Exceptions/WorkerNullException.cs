using System;

namespace Bank_Practice.Application_Exceptions
{
    public class WorkerNullException : ApplicationException
    {
        private readonly string _message = "Worker is null.";
        public override string Message => _message;

        public WorkerNullException() {}
        public WorkerNullException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }


}
