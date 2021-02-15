using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Practice.Application_Exceptions
{
    public class OperationNullException : ApplicationException
    {
        private readonly string _message = "Operation is null.";
        public override string Message => _message;

        public OperationNullException() {}
        public OperationNullException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }

    public class SalaryLessThanGivenAmountException : ApplicationException
    {
        private readonly string _message = "Salary is less than given amount of credit.";
        public override string Message => _message;

        public SalaryLessThanGivenAmountException() { }
        public SalaryLessThanGivenAmountException(in string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return $"Message: {Message}\n";
        }
    }


}
