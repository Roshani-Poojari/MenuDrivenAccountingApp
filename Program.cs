using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MenuDrivenAccountingApp.Model;

namespace MenuDrivenAccountingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[] {
            new Account(101, "Allen", 10000),
            new Account(102, "Mary")};
            //Account account1 = new Account(101, "Allen", 10000);
            //Account account2 = new Account(102, "Mary");
            //Account[] accounts = new Account[] { account1, account2 };

            //DepositDetails(account1, 1250);
            // WithdrawalDetails(account1, 5000);

            // WithdrawalDetails(account2, 4600);
            //DepositDetails(account2, 2000);
            //WithdrawalDetails(account2, 1750);

            //Console.WriteLine(account1);
            //Console.WriteLine(account2);

            //Account maxBalanceAccount = Account.AccountWithMaxBalance(accounts);
            //Console.WriteLine("Account with max balance is:");
            //Console.WriteLine(maxBalanceAccount);
            DisplayMainMenu(accounts);
        }

        static void DepositDetails(Account account, double amount)
        {
            account.Deposit(amount);
            Console.WriteLine($"Account No.: {account.AccountNumber}\nDeposited Amount: Rs.{amount} successfully\n" +
                $"Updated Account Balance: Rs.{account.Balance}");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        static void WithdrawalDetails(Account account, double amount)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"Account No.: {account.AccountNumber}\nWithdrawed Amount: Rs.{amount} successfully\n" +
                $"Updated Account Balance: Rs.{account.Balance}");
            }
            else
                Console.WriteLine($"Account No.: {account.AccountNumber}\nWithdrawal uncsuccessful due to Insufficient Funds");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        static void DisplayMainMenu(Account[] accounts)
        {
            Console.WriteLine("................. Welcome .................");
            Console.WriteLine("Enter your Account No.: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            Account accountInUse = null;
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                    accountInUse = account;
            }
            Console.WriteLine($"Welcome {accountInUse.Name}");
            while (true)
            {
                Console.WriteLine("What do you wish to do:\n" +
                    $" 1.Deposit   2.Withdraw   3.View Account Details   4.Exit\n" +
                    $"Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                PerformTask(accountInUse, choice);
            }
        }
        static void PerformTask(Account accountInUse, int choice)
        {
            double amount;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the amount you want to deposit: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                    DepositDetails(accountInUse, amount);
                    break;
                case 2:
                    Console.WriteLine("Enter the amount you want to withdraw: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                    WithdrawalDetails(accountInUse, amount);
                    break;
                case 3:
                    Console.WriteLine(accountInUse);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input!");
                    break;

            }

        }
    }
}
