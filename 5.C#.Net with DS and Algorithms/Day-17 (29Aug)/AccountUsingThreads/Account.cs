using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountUsingThreads
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; private set; }

        public Account(int accountId, decimal initialBalance)
        {
            AccountId = accountId;
            Balance = initialBalance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Balance in account {AccountId} is: {Balance}");
        }
    }
}
