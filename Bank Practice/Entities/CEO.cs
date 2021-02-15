using System;
using System.Windows.Forms;
using Bank_Practice.Abstract_Classes;
using Bank_Practice.Application_Exceptions;
using Bank_Practice.Interfaces;
using Bank_Practice.Static_Classes;

namespace Bank_Practice.Entities
{
    public class CEO : Employee, IOrganizable
    {
        public CEO(in string name, in string surname, in int age, in string position, in double salary)
            : base(name, surname, age, position, salary)
        {
        }

        public void Control(in Manager manager)
        {
            if (manager == null)
                throw new ManagerNullException();

            Console.WriteLine($"CEO {Name} {Surname} changes position with Manager {manager.Name} {manager.Surname} and take control of workers.");
        }
        public void Organize(in Worker[] workers)
        {
            if (workers != null)
            {
                for (int i = 0; i < workers.Length - 1; i++)
                    Console.Write(workers[i].Name + ", ");

                Console.Write($"{workers[workers.Length - 1].Name} come to work tomorrow at 5:00 PM\n");
            }
        }

        public void MakeMeeting(in DateTime date)
        {
            if (date != null)
                Console.WriteLine($"We make meeting {date.AddHours(5):F}");
        }

        public void ChangePercentage(in double changeNumber)
        {
            if ((changeNumber < 0 && Math.Abs(changeNumber) <= BankHelper.BankPercentage) ||
                (changeNumber > 0 && changeNumber <= 100 - BankHelper.BankPercentage))
            {
                MessageBox.Show($"Bank Percentage { BankHelper.BankPercentage} % change to { BankHelper.BankPercentage += changeNumber} % ", "CEO OPTION", MessageBoxButtons.OK);
            }
        }

        public override string ToString()
        {
            return $"CEO Name:{Name}\nCEO Surname: {Surname}\nCEO Age: {Age}\nCEO Position: {Position}\nCEO Salary: {Salary}";
        }
    }
}
