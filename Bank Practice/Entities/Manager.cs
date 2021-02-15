using Bank_Practice.Abstract_Classes;
using Bank_Practice.Interfaces;
using System;

namespace Bank_Practice.Entities
{
    public class Manager : Employee, IOrganizable
    {
        public Manager(in string name, in string surname, in int age, in string position, in double salary)
            : base(name, surname, age, position, salary)
        {
        }


        public void Organize(in Worker[] workers)
        {
            if (workers != null)
            {

                for (int i = 0; i < workers.Length - 1; i++)
                    Console.Write(workers[i].Name + ", ");

                Console.Write($"{workers[workers.Length - 1].Name} come to CEO's office right now\n");
            }
        }

        public double CalculateSalaries(in Worker[] workers)
        {
            double salaries = 0.0;
            if (workers != null)
            {
                foreach (var worker in workers)
                {
                    salaries += worker.Salary;
                }
            }
            return salaries;
        }

        public void Show()
        {
            Console.WriteLine($"Manager Name: {Name}");
            Console.WriteLine($"Manager Surname: {Surname}");
            Console.WriteLine($"Manager Age: {Age}");
            Console.WriteLine($"Manager Position: {Position}");
            Console.WriteLine($"Manager Salary: {Salary}");
            Console.WriteLine();
        }

    }
}
