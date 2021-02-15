using System;
using Bank_Practice.Abstract_Classes;
using Bank_Practice.Application_Exceptions;
using Bank_Practice.Inside_Bank;

namespace Bank_Practice.Entities
{
    public class Worker : Employee
    {
        private const int _workingHour = 8;
        private readonly DateTime _startTime = DateTime.Now;
        private readonly DateTime _endTime = DateTime.Now.AddHours(_workingHour);
        private Operation[] _operations = default;

        public Worker(in string name, in string surname, in int age, in string position, in double salary)
            : base(name, surname, age, position, salary)
        {
        }

        public void AddOperation(in Operation operation)
        {
            if (operation != null)
            {
                int length = (_operations == null) ? 0 : _operations.Length;

                Operation[] temp = new Operation[length + 1];

                if (_operations != null)
                {
                    _operations.CopyTo(temp, 0);
                }
                temp[temp.Length - 1] = operation;
                _operations = temp;
            }
            else
                throw new OperationNullException("Operation is invalid state.(means null)");
        }

        public void ShowOperations()
        {
            if (_operations != null)
            {
                foreach (var operation in _operations)
                {
                    Console.WriteLine(operation);
                    Console.WriteLine("\n========================");
                }
            }
            else
                Console.WriteLine("There is no operation");
        }
        public void Show()
        {
            Console.WriteLine($"Worker Name: {Name}");
            Console.WriteLine($"Worker Surname: {Surname}");
            Console.WriteLine($"Worker Age: {Age}");
            Console.WriteLine($"Worker Position: {Position}");
            Console.WriteLine($"Worker Salary: {Salary}");
            Console.WriteLine();
        }

    }
}
