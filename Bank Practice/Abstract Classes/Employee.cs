using Bank_Practice.Interfaces;

namespace Bank_Practice.Abstract_Classes
{
    public abstract class Employee : Person, IGetPaid
    {
        public Employee(in string name, in string surname, in int age, in string position, in double salary) 
            : base(name, surname, age)
        {
            Position = position;
            Salary = salary;
        }

        public string Position { get; set; }
        public double Salary { get; set; }
    }
}
