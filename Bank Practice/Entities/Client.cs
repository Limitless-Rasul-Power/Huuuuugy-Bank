using Bank_Practice.Abstract_Classes;
using Bank_Practice.Interfaces;

namespace Bank_Practice.Entities
{
    public class Client : Person, IGetPaid
    {        
        public string LiveAddress { get; set; }
        public string WorkAddress { get; set; }
        public double Salary { get; set; }

        public Client(in string name, in string surname, in int age, in double salary, in string liveAddress, in string workAddress)
            : base(name, surname, age)
        {
            Salary = salary;
            LiveAddress = liveAddress;
            WorkAddress = workAddress;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nAge: {Age}\nSalary: {Salary}\nLive Address: {LiveAddress}\nWork Address: {WorkAddress}\n\n";
        }

    }
}