using System;
using System.Text;
using System.Windows.Forms;
using Bank_Practice.Application_Exceptions;
using Bank_Practice.Entities;
using Bank_Practice.Inside_Bank;
using Bank_Practice.Static_Classes;

namespace Bank_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            CEO ceo = new CEO("Ilon", "Musk", 35, "Chief Executice Order", 500_000);
            Credit[] credits = Configuration.GetCreditedClients();
            Worker[] workers = Configuration.GetWorkers();
            Manager[] managers = Configuration.GetManagers();
            Bank bank = new Bank("One day", ceo, managers, workers, credits);

            string[] ceoMenu = Configuration.GetCEOMenu();
            string[] clientMenu = Configuration.GetClientMenu();
            string[] monthMenu = Configuration.GetMonthMenu();
            string[] clientHeadMenu = Configuration.GetClientHeadMenu();
            string[] firstMenu = Configuration.GetFirstMenu();
            string[] managerMenu = Configuration.GetManagerMenu();
            string[] workerMenu = Configuration.GetWorkerMenu();

            string choice, name = null, surname = null;


            while (true)
            {
                Configuration.PrintMenu(firstMenu);
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();

                while (!Verify.IsChoiceCorrect(choice, firstMenu.Length))
                {
                    Console.WriteLine("\nEnter one this choices(1, 2, 3, 4): ");
                    choice = Console.ReadLine();
                }
                Console.Clear();

                if (Convert.ToChar(choice) == FirstMenuChoices.Exit)
                {
                    MessageBox.Show("See you next time goodbye.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                    break;
                }
                else if (Convert.ToChar(choice) == FirstMenuChoices.CEO)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("Surname: ");
                        surname = Console.ReadLine();

                        StringBuilder nameAndSurname = new StringBuilder();
                        nameAndSurname.Append(name).Append(' ').Append(surname);

                        try
                        {
                            bank.IsCEOCredentialCorrect(nameAndSurname.ToString());

                            while (true)
                            {
                                Configuration.PrintMenu(ceoMenu);
                                Console.Write("Enter one of this choice: ");
                                choice = Console.ReadLine();

                                while (!Verify.IsChoiceCorrect(choice, ceoMenu.Length))
                                {
                                    Console.WriteLine("\nEnter one of this choices(1, 2, 3, 4, 5, 6, 7, 8, 9, 10): ");
                                    choice = Console.ReadLine();
                                }

                                Console.Clear();

                                if (choice == CEOMenuChoices.Back)
                                {
                                    MessageBox.Show("See you next time goodbye.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                    break;
                                }

                                switch (Convert.ToChar(choice))
                                {
                                    case CEOMenuChoices.Organize:
                                        {
                                            ceo.Organize((Worker[])bank.GetWorkers());
                                            Console.Write("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case CEOMenuChoices.ShowAllCreditedClients:
                                        {
                                            bank.ShowAllCreditedClient();
                                            Console.Write("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case CEOMenuChoices.ShowBankInfo:
                                        {
                                            bank.ShowOnlyBankAndCEOInformation();
                                            Console.Write("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case CEOMenuChoices.ShowAllManagers:
                                        {
                                            bank.ShowAllManagers();
                                            Console.Write("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case CEOMenuChoices.ShowAllWorkers:
                                        {
                                            bank.ShowAllWorkers();
                                            Console.Write("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case CEOMenuChoices.ChangePercentage:
                                        {
                                            Console.Write("Enter how to change percentage: ");
                                            string percentage = Console.ReadLine();

                                            while (!Verify.IsNumberFloatinPoint(percentage))
                                            {
                                                Console.WriteLine("\nEnter number please: ");
                                                percentage = Console.ReadLine();
                                            }
                                            ceo.ChangePercentage(double.Parse(percentage));
                                        }
                                        break;
                                    case CEOMenuChoices.MakeMeeting:
                                        {
                                            ceo.MakeMeeting(DateTime.Now);
                                            Console.Write("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case CEOMenuChoices.IncreaseManagerSalary:
                                        {
                                            Console.Clear();
                                            bank.ShowAllManagers();
                                            Console.Write("\nName: ");
                                            name = Console.ReadLine();
                                            Console.Write("Surname: ");
                                            surname = Console.ReadLine();

                                            try
                                            {
                                                Manager manager = bank.FindManagerWithNameAndSurname(name, surname);
                                                Console.Write("Salary: ");
                                                string salary = Console.ReadLine();

                                                while (!Verify.IsFloatingPointNumberPositive(salary))
                                                {
                                                    Console.WriteLine("\nEnter positive number: ");
                                                    salary = Console.ReadLine();
                                                }

                                                manager.Salary += double.Parse(salary);
                                                Console.Clear();
                                                MessageBox.Show($"Manager {name} {surname}'s salary successfully changes.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                            }
                                            catch (ManagerNullException caption)
                                            {
                                                Console.Clear();
                                                MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                            }
                                        }
                                        break;
                                    case CEOMenuChoices.IncreaseWorkerSalary:
                                        {
                                            Console.Clear();
                                            bank.ShowAllWorkers();
                                            Console.Write("\nName: ");
                                            name = Console.ReadLine();
                                            Console.Write("Surname: ");
                                            surname = Console.ReadLine();

                                            try
                                            {
                                                Worker worker = bank.FindWorkerWithNameAndSurname(name, surname);
                                                Console.Write("Salary: ");
                                                string salary = Console.ReadLine();

                                                while (!Verify.IsFloatingPointNumberPositive(salary))
                                                {
                                                    Console.WriteLine("\nEnter positive number: ");
                                                    salary = Console.ReadLine();
                                                }

                                                worker.Salary += double.Parse(salary);
                                                Console.Clear();
                                                MessageBox.Show($"Worker {name} {surname}'s salary successfully changes.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                            }
                                            catch (WorkerNullException caption)
                                            {
                                                Console.Clear();
                                                MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        catch (CEODidNotFoundException caption)
                        {
                            Console.Clear();
                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                            break;
                        }

                        if (choice == CEOMenuChoices.Back)
                            break;
                    }

                }
                else if (Convert.ToChar(choice) == FirstMenuChoices.Manager)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Clear();
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Surname: ");
                            surname = Console.ReadLine();

                            Manager manager = bank.FindManagerWithNameAndSurname(name, surname);

                            while (true)
                            {
                                Configuration.PrintMenu(managerMenu);
                                Console.Write("Enter choice: ");
                                choice = Console.ReadLine();

                                while (!Verify.IsChoiceCorrect(choice, managerMenu.Length))
                                {
                                    Console.WriteLine("\nEnter one this choices(1, 2, 3, 4): ");
                                    choice = Console.ReadLine();
                                }
                                Console.Clear();

                                if (Convert.ToChar(choice) == ManagerMenuChoices.Back)
                                {
                                    MessageBox.Show("See you next time goodbye.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                    break;
                                }

                                switch (Convert.ToChar(choice))
                                {
                                    case ManagerMenuChoices.CalculateSalaries:
                                        {
                                            MessageBox.Show($"All Workers Salary is { manager.CalculateSalaries((Worker[])bank.GetWorkers()):C} $", "MANAGER OPTION", MessageBoxButtons.OK);
                                        }
                                        break;
                                    case ManagerMenuChoices.Organize:
                                        {
                                            manager.Organize((Worker[])bank.GetWorkers());
                                            Console.WriteLine("Press \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case ManagerMenuChoices.AddWorker:
                                        {
                                            Console.Write("Name: ");
                                            name = Console.ReadLine();
                                            Console.Write("Surname: ");
                                            surname = Console.ReadLine();

                                            Console.Write("Age: ");
                                            string age = Console.ReadLine();

                                            while (true)
                                            {
                                                if (Verify.IsChoiceNumber(age))
                                                {
                                                    try
                                                    {
                                                        Verify.IsNumberMoreThan17(int.Parse(age));
                                                        break;
                                                    }
                                                    catch (InvalidOperationException caption)
                                                    {
                                                        Console.Clear();
                                                        MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                                    }
                                                }
                                                Console.WriteLine("\nEnter age: ");
                                                age = Console.ReadLine();
                                            }

                                            Console.Write("Position: ");
                                            string position = Console.ReadLine();

                                            Console.Write("Salary: ");
                                            string salary = Console.ReadLine();

                                            while ((!Verify.IsFloatingPointNumberPositive(salary)) || (!Verify.IsNumberFloatinPoint(salary)))
                                            {
                                                Console.WriteLine("\nEnter salary: ");
                                                salary = Console.ReadLine();
                                            }

                                            bank.AddWorker(new Worker(name, surname, int.Parse(age), position, double.Parse(salary)));

                                            Console.Clear();
                                            MessageBox.Show($"Worker {name} {surname} Successfully Added", $"{bank.Name} inc ©", MessageBoxButtons.OK);

                                        }
                                        break;
                                }


                            }

                            if (Convert.ToChar(choice) == ManagerMenuChoices.Back)
                                break;

                        }
                        catch (ManagerNullException caption)
                        {
                            Console.Clear();
                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                            break;
                        }


                    }
                }
                else if(Convert.ToChar(choice) == FirstMenuChoices.Worker)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("Surname: ");
                        surname = Console.ReadLine();

                        try
                        {
                            Worker worker = bank.FindWorkerWithNameAndSurname(name, surname);

                            while (true)
                            {
                                Configuration.PrintMenu(workerMenu);
                                Console.Write("Enter choice: ");
                                choice = Console.ReadLine();

                                while (!Verify.IsChoiceCorrect(choice, workerMenu.Length))
                                {
                                    Console.WriteLine("\nEnter one this choices(1, 2): ");
                                    choice = Console.ReadLine();
                                }
                                Console.Clear();

                                if (Convert.ToChar(choice) == WorkerMenuChoices.AddOperation)
                                {
                                    Console.Write("Enter operation: ");
                                    string operation = Console.ReadLine();

                                    worker.AddOperation(new Operation(operation));
                                    Console.Clear();
                                    MessageBox.Show("Operation added successfully", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                }
                                else if (Convert.ToChar(choice) == WorkerMenuChoices.ShowAddedOperations)
                                {
                                    worker.ShowOperations();
                                    Console.WriteLine("Press \"Enter\" to continue...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    MessageBox.Show("See you next time", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                    break;
                                }

                            }

                            if (Convert.ToChar(choice) == WorkerMenuChoices.Back)
                                break;
                        }
                        catch (WorkerNullException caption)
                        {
                            Console.Clear();
                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                            break;
                        }


                    }
                }
                else
                {
                    while (true)
                    {
                        StringBuilder nameAndSurname = new StringBuilder();

                        while (true)
                        {
                            Configuration.PrintMenu(clientHeadMenu);
                            Console.Write("Enter: ");
                            choice = Console.ReadLine();

                            while (!Verify.IsChoiceCorrect(choice, clientHeadMenu.Length))
                            {
                                Console.WriteLine("\nEnter one of this choices(1, 2, 3): ");
                                choice = Console.ReadLine();
                            }
                            Console.Clear();

                            if (Convert.ToChar(choice) == ClientMenuChoices.Exit)
                            {
                                MessageBox.Show("See you next time", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                break;
                            }

                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Surname: ");
                            surname = Console.ReadLine();

                            nameAndSurname.Append(name).Append(' ').Append(surname);

                            if (Convert.ToChar(choice) == ClientMenuChoices.Register)
                            {
                                Console.Write("Age: ");
                                string age = Console.ReadLine();

                                while (true)
                                {

                                    if (Verify.IsChoiceNumber(age))
                                    {
                                        try
                                        {
                                            Verify.IsNumberMoreThan17(int.Parse(age));
                                            break;
                                        }
                                        catch (InvalidOperationException caption)
                                        {
                                            Console.Clear();
                                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                        }
                                    }
                                    Console.WriteLine("\nEnter age: ");
                                    age = Console.ReadLine();
                                }

                                Console.Write("Salary: ");
                                string salary = Console.ReadLine();

                                while (!Verify.IsFloatingPointNumberPositive(salary))
                                {
                                    Console.WriteLine("\nEnter salary: ");
                                    salary = Console.ReadLine();
                                }

                                Console.Write("Live Address: ");
                                string liveAddress = Console.ReadLine();

                                Console.Write("Work Address: ");
                                string workAddress = Console.ReadLine();
                                Console.Clear();

                                Client client = new Client(name, surname, Convert.ToInt32(age), Convert.ToDouble(salary), liveAddress, workAddress);
                                Credit credit = new Credit(client, 0, 0);
                                bank.AddCreditedClient(credit);

                                Console.Clear();
                                MessageBox.Show("You registered successfully.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                break;
                            }

                            else
                            {
                                try
                                {
                                    bank.FindCreditedClient(name, surname);
                                    break;
                                }
                                catch (ClientDidNotFoundException caption)
                                {
                                    Console.Clear();
                                    MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                    nameAndSurname.Clear();
                                }
                            }
                        }

                        if (Convert.ToChar(choice) == ClientMenuChoices.Exit)
                            break;

                        while (true)
                        {
                            Configuration.PrintMenu(clientMenu);
                            Console.Write("Enter one of this choice: ");
                            choice = Console.ReadLine();

                            while (!Verify.IsChoiceCorrect(choice, clientMenu.Length))
                            {
                                Console.WriteLine("\nEnter one of this choices(1, 2, 3, 4): ");
                                choice = Console.ReadLine();
                            }
                            Console.Clear();

                            if (Convert.ToChar(choice) == ClientMenuChoices.Back)
                                break;


                            switch (Convert.ToChar(choice))
                            {
                                case ClientMenuChoices.GetCredit:
                                    {

                                        try
                                        {
                                            Credit credit = bank.FindCreditedClient(name, surname);
                                            if (credit.IsClientHasCredit)
                                                throw new InvalidOperationException("Client has credit !!!");

                                            Console.Write($"{name} {surname} how many amount of credit do you want, Enter: ");
                                            string amount = Console.ReadLine();

                                            while ((!Verify.IsFloatingPointNumberPositive(amount)) || (!Verify.IsNumberFloatinPoint(amount)))
                                            {
                                                Console.WriteLine("\nEnter amount: ");
                                                amount = Console.ReadLine();
                                            }

                                            Verify.IsSalaryLessThanGivenCreditAmount(Convert.ToDouble(credit.Client.Salary) * BankHelper.OneYearWithMonths,
                                                                                     Convert.ToDouble(amount));

                                            Configuration.PrintMenu(monthMenu);
                                            Console.Write("Enter: ");
                                            choice = Console.ReadLine();

                                            while (!Verify.IsChoiceCorrect(choice, monthMenu.Length))
                                            {
                                                Console.WriteLine("\nEnter one of this numbers(1, 2, 3): ");
                                                choice = Console.ReadLine();
                                            }

                                            int months;
                                            if (Convert.ToChar(choice) == MonthMenuChoices.TwelveMonth) months = 12;
                                            else if (Convert.ToChar(choice) == MonthMenuChoices.TwentyFourMonth) months = 24;
                                            else months = 36;

                                            Console.Clear();                                            

                                            if(Convert.ToDouble(amount) != 0)
                                            {
                                                credit.Amount = Convert.ToDouble(amount);
                                                credit.Months = months;
                                                credit.IsClientHasCredit = true;
                                                MessageBox.Show($"Credit successfully get.", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                            }
                                        }
                                        catch (Exception caption)
                                        {
                                            Console.Clear();
                                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                        }

                                    }
                                    break;

                                case ClientMenuChoices.PayCredit:
                                    {
                                        try
                                        {
                                            bank.PayCredit(nameAndSurname.ToString());
                                        }
                                        catch (ApplicationException caption)
                                        {
                                            Console.Clear();
                                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                        }
                                    }
                                    break;

                                case ClientMenuChoices.ShowCreditInfo:
                                    {
                                        try
                                        {
                                            bank.ShowClientCredit(nameAndSurname.ToString());
                                            Console.WriteLine("\nPress \"Enter\" key to continue...");
                                            Console.ReadLine();
                                        }
                                        catch (ClientDidNotFoundException caption)
                                        {
                                            Console.Clear();
                                            MessageBox.Show($"{caption.Message}", $"{bank.Name} inc ©", MessageBoxButtons.OK);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}