using Bank_Practice.Abstract_Classes;
using Bank_Practice.Entities;
using Bank_Practice.Application_Exceptions;
using Bank_Practice.Static_Classes;

namespace Bank_Practice.Inside_Bank
{
    public class Credit : UniqueId
    {        
        private double _amount;
        private int _month;     
        private readonly double _percentage = BankHelper.BankPercentage;
        public bool IsClientHasCredit = false;
        public Client Client { get; set; }        
        public double FinalPayment { get; set; }
        public double PaymentPerMonth { get; set; }
        public Credit(in Client client, in double amount, in int months)
        {
            Client = client;
            Amount = amount;
            Months = months;

            if (amount != 0)
            IsClientHasCredit = true;
        }

        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                try
                {
                    Verify.IsFloatingPointNumberPositive(value.ToString());
                    Verify.IsAmountLessThanBankBudget(value);
                    Verify.IsSalaryLessThanGivenCreditAmount(Client.Salary * BankHelper.OneYearWithMonths, value);

                    _amount = value;

                    if (BankHelper.BankBudget - value >= 0)
                    BankHelper.BankBudget -= value;
                }
                catch (NotEnoughBudgetException caption)
                {
                    System.Console.WriteLine(caption.Message);
                }
            }
        }

        public int Months
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
                FinalPayment = CalculateFinalPayment();
                PaymentPerMonth = CalculatePaymentPerMonth();
            }
        }


        private double CalculateFinalPayment()
        {            
            return (Amount * BankHelper.BankPercentage * Months) / 100;
        }

        private double CalculatePaymentPerMonth()
        {
            return FinalPayment / Months;
        }

        public override string ToString()
        {
            if (PaymentPerMonth.Equals(double.NaN))
                PaymentPerMonth = 0;

            return $"{Client}Credit Amount: {Amount}\nBank Percentage: {_percentage}\nMonth: {Months}\nPayment Per Month: {PaymentPerMonth}\nFinal Payment: {FinalPayment}";
        }
    }
}