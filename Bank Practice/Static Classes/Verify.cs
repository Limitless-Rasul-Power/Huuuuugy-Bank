using System;
using System.Text.RegularExpressions;
using Bank_Practice.Application_Exceptions;

namespace Bank_Practice.Static_Classes
{
    public static class Verify
    {
        public static void IsNumberMoreThan17(in double number)
        {
            if (number < 18)
                throw new InvalidOperationException("Number must be more than 17.");
        }
        public static void IsContainsOnlyCharacter(in string sentence)
        {
            if(!String.IsNullOrWhiteSpace(sentence))
            {
                if (!Regex.IsMatch(sentence, @"^[a-zA-Z ]+$"))
                    throw new NotMatchException("Sentence did not match.");                    
            }
        }
        public static void IsNumberLessThanOne(in double number)
        {
            if (number <= 0)
                throw new MoneyLessThanOneException();
        }
        public static void IsAmountLessThanBankBudget(in double amount)
        {
            if (amount > BankHelper.BankBudget)
                throw new NotEnoughBudgetException();
        }
        public static void IsSalaryLessThanGivenCreditAmount(in double salary, in double amount)
        {
            if (salary < amount)
                throw new SalaryLessThanGivenAmountException("One year salary is less than given amount.");
        }
        public static bool IsNumberFloatinPoint(in string choice)
        {
            return double.TryParse(choice, out _);
        }

        public static bool IsFloatingPointNumberPositive(in string number)
        {
            bool flag = double.TryParse(number, out double result);
            return flag && result >= 0;
        }

        public static bool IsChoiceNumber(in string choice)
        {
            return int.TryParse(choice, out _);
        }
        public static bool IsChoiceCorrect(in string choice, in int maxChoice)
        {
            if ((!String.IsNullOrWhiteSpace(choice)) &&  IsChoiceNumber(choice))
            {
                return int.Parse(choice) <= maxChoice && int.Parse(choice) > 0;
            }

            return false;
        }


    }
}
