using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDrivenAccountingApp.Model
{
    internal class Account
    {
        private const double MIN_BALANCE = 500;

        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(int accNumber, string name)
        {
            AccountNumber = accNumber;
            Name = name;
            Balance = MIN_BALANCE;
        }

        public Account(int accNumber, string name, double balance) : this(accNumber, name) 
        {
            if (balance < MIN_BALANCE)
                Balance = MIN_BALANCE;
            else
                Balance = balance;
        }

        public bool Deposit(double amount)
        {
            Balance += amount;
            return true;
        }
        public bool Withdraw(double amount)
        {
            if (Balance - amount < MIN_BALANCE)
                return false;
            Balance -= amount;
            return true;
        }

        public static Account AccountWithMaxBalance(Account[] accounts)
        {
            Account accountWithMaxBalance = null;
            double maxBalance = MIN_BALANCE;
            foreach (Account account in accounts)
            {
                if (account.Balance > maxBalance)
                {
                    maxBalance = account.Balance;
                    accountWithMaxBalance = account;
                }
            }
            return accountWithMaxBalance;
        }

        public override string ToString()
        {
            return $"Account no: {AccountNumber} \n" +
                $"Account holder's name: {Name} \n" +
                $"Balance: {Balance} \n" +
                $"-----------------------------------------------------------";
        }
    }
}
