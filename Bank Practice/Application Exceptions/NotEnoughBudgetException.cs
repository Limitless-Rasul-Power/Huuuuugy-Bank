using System;

namespace Bank_Practice.Application_Exceptions
{
    public class NotEnoughBudgetException : ApplicationException
    {
        private readonly string _message = "Budget is less than credit amount.";
        public override string Message => _message;

        public NotEnoughBudgetException() {}
        public NotEnoughBudgetException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }


}
