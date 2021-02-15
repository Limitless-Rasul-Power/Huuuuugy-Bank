using System;
using System.Collections;
using System.Windows.Forms;
using Bank_Practice.Application_Exceptions;
using Bank_Practice.Inside_Bank;
using Bank_Practice.Static_Classes;

namespace Bank_Practice.Entities
{
    public partial class Bank
    {
        public IEnumerable GetManagers()
        {
            return _managers;
        }
        public IEnumerable GetWorkers()
        {
            return _workers;
        }
        public IEnumerable GetCreditedClients()
        {
            return _creditClients;
        }


        public void AddManager(in Manager manager)
        {
            if (manager != null)
            {
                int length = (_managers == null) ? 0 : _managers.Length;

                Manager[] temp = new Manager[length + 1];

                if (_managers != null)
                {
                    _managers.CopyTo(temp, 0);
                }
                temp[temp.Length - 1] = manager;
                _managers = temp;
            }
            else
                throw new ManagerNullException("Manager is invalid state.");
        }
        public void AddWorker(in Worker worker)
        {
            if (worker != null)
            {
                int length = (_workers == null) ? 0 : _workers.Length;

                Worker[] temp = new Worker[length + 1];

                if (_workers != null)
                {
                    _workers.CopyTo(temp, 0);
                }
                temp[temp.Length - 1] = worker;
                _workers = temp;
            }
            else
                throw new WorkerNullException("Worker is invalid state.");
        }
        public void AddCreditedClient(in Credit creditedClient)
        {
            if (creditedClient != null)
            {
                if (creditedClient.Amount > BankHelper.BankBudget)
                    throw new NotEnoughBudgetException("Bank's budget is less than credit amount and we can not give you credit in this situation.");

                int length = (_creditClients == null) ? 0 : _creditClients.Length;

                Credit[] temp = new Credit[length + 1];

                if (_creditClients != null)
                {
                    _creditClients.CopyTo(temp, 0);
                }
                temp[temp.Length - 1] = creditedClient;
                _creditClients = temp;
            }
            else
                throw new CreditedClientNullException("Credited Client is invalid state.");
        }
        public void ShowClientCredit(in string fullName)
        {
            int index = FindCreditedClient(fullName);
            Console.WriteLine(_creditClients[index]);
        }
        public void PayCredit(in string fullName)
        {
            int index = FindCreditedClient(fullName);

            if (_creditClients[index].FinalPayment == 0) throw new AlreadyFullPaidException("Your credit did not exist you or you paid all.");

            if (_creditClients[index].PaymentPerMonth >= _creditClients[index].FinalPayment)
            {
                MessageBox.Show($"You pay your last credit it is {_creditClients[index].FinalPayment} $.", $"{Name} inc ©", MessageBoxButtons.OK);                
                BankHelper.BankBudget += _creditClients[index].FinalPayment;
                _creditClients[index].FinalPayment -= _creditClients[index].FinalPayment;
                _creditClients[index].IsClientHasCredit = false;
                _creditClients[index].PaymentPerMonth = 0;
            }
            else
            {
                _creditClients[index].FinalPayment -= _creditClients[index].PaymentPerMonth;
                BankHelper.BankBudget += _creditClients[index].PaymentPerMonth;
                MessageBox.Show($"Paid Successfully, now you have {_creditClients[index].FinalPayment} $ to done credit.", $"{Name} inc ©", MessageBoxButtons.OK);
            }
        }
        public double CalculateProfit()
        {
            double profit = 0.0;
            if (_creditClients != null)
            {
                foreach (var credited in _creditClients)
                {
                    profit += credited.FinalPayment;
                }

            }
            return profit;
        }
        public void ShowAllCreditedClient()
        {
            if (_creditClients != null)
            {
                foreach (var creditedClient in _creditClients)
                {
                    Console.WriteLine(creditedClient);
                    Console.WriteLine("\n==============================\n");
                }
            }
            else
                throw new CreditedClientNullException();
        }
        private int FindCreditedClient(in string fullName)
        {
            if (!String.IsNullOrWhiteSpace(fullName))
            {
                if (_creditClients != null)
                {
                    const int nameIndex = 0;
                    const int surnameIndex = 1;
                    string[] helper = fullName.Split(' ');

                    for (int i = 0; i < _creditClients.Length; i++)
                    {
                        if (_creditClients[i].Client.Name == helper[nameIndex] &&
                           _creditClients[i].Client.Surname == helper[surnameIndex])
                            return i;
                    }
                }
            }
            throw new ClientDidNotFoundException();
        }
        public Credit FindCreditedClient(in string name, in string surname)
        {
            if ((!String.IsNullOrWhiteSpace(name)) && (!String.IsNullOrWhiteSpace(surname)))
            {
                if (_creditClients != null)
                {
                    for (int i = 0; i < _creditClients.Length; i++)
                    {
                        if (_creditClients[i].Client.Name == name &&
                           _creditClients[i].Client.Surname == surname)
                            return _creditClients[i];
                    }
                }
            }
            throw new ClientDidNotFoundException();
        }
        public bool IsCEOCredentialCorrect(in string fullName)
        {
            if (!String.IsNullOrWhiteSpace(fullName))
            {
                if (CEO != null)
                {
                    const int nameIndex = 0;
                    const int surnameIndex = 1;
                    string[] helper = fullName.Split(' ');

                    if (CEO.Name == helper[nameIndex] &&
                       CEO.Surname == helper[surnameIndex])
                        return true;
                }
            }
            throw new CEODidNotFoundException("Ceo did not found, wrong credentials!");
        }

        public Manager FindManagerWithNameAndSurname(in string name, in string surname)
        {
            if ((!String.IsNullOrWhiteSpace(name)) && (!String.IsNullOrWhiteSpace(surname)))
            {
                if (_managers!= null)
                {
                    for (int i = 0; i < _managers.Length; i++)
                    {
                        if (_managers[i].Name == name &&
                           _managers[i].Surname == surname)
                            return _managers[i];
                    }
                }
            }
            throw new ManagerNullException("Manager did not found.");
        }

        public Worker FindWorkerWithNameAndSurname(in string name, in string surname)
        {
            if ((!String.IsNullOrWhiteSpace(name)) && (!String.IsNullOrWhiteSpace(surname)))
            {
                if (_workers != null)
                {
                    for (int i = 0; i < _workers.Length; i++)
                    {
                        if (_workers[i].Name == name &&
                           _workers[i].Surname == surname)
                            return _workers[i];
                    }
                }
            }
            throw new WorkerNullException("Worker did not found.");
        }

        public void ShowAllManagers()
        {
            if(_managers != null)
            {
                foreach (var manager in _managers)
                {
                    manager.Show();
                    Console.WriteLine("=============================");
                }
            }
        }

        public void ShowAllWorkers()
        {
            if (_workers != null)
            {
                foreach (var worker in _workers)
                {
                    worker.Show();
                    Console.WriteLine("=============================");
                }
            }
        }

        public void ShowOnlyBankAndCEOInformation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Bank Name: {Name}");
            Console.WriteLine($"Bank Budget: {BankHelper.BankBudget:C}");
            Console.WriteLine($"Bank Percentage: {BankHelper.BankPercentage}");
            Console.WriteLine($"Bank Profit: {CalculateProfit():C}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CEO);

            Console.ResetColor();
        }        

    }
}