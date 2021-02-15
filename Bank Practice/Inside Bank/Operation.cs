using System;
using Bank_Practice.Abstract_Classes;

namespace Bank_Practice.Inside_Bank
{
    public class Operation : UniqueId
    {        
        private readonly DateTime _creationTime = DateTime.Now;
        public string Name { get; set; }

        public Operation(in string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Operation Name: {Name}\nCreation Time: {_creationTime:F}";
        }

    }
}