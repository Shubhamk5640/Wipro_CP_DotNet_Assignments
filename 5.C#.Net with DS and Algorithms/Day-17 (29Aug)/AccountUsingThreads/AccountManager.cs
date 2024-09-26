using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountUsingThreads
{
    public class AccountManager
    {
        private readonly Account fromAccount;
        private readonly Account toAccount;
        private readonly object lockObject = new object();

        public AccountManager(Account fromAccount, Account toAccount)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
        }

        public void Transfer(decimal amount)
        {
            lock (lockObject)
            {
                Console.WriteLine($"{amount} is transferring from Account {fromAccount.AccountId} to Account {toAccount.AccountId}");
                if (fromAccount.Withdraw(amount))
                {
                    // Simulating a delay
                    Thread.Sleep(1000); // Delay to simulate real-world transaction processing
                    toAccount.Deposit(amount);
                    Console.WriteLine($"{amount} is successfully transferred from Account {fromAccount.AccountId} to Account {toAccount.AccountId}");
                }
                else
                {
                    Console.WriteLine($"Transfer failed: Insufficient funds in Account {fromAccount.AccountId}");
                }
            }
        }
    }
}
