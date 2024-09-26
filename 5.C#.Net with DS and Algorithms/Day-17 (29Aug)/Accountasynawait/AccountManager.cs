using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountasynawait
{
    public class AccountManager
    {
        Account account1;
        Account account2;

        public AccountManager(Account account1, Account account2)
        {
            this.account1 = account1;
            this.account2 = account2;
        }

        public async Task transfer(Account fromAccount, Account toAccount, double amount)
        {
            Console.WriteLine($"{amount} is transferring from account {fromAccount.account_id} to account {toAccount.account_id}");
            await Task.Delay(1000); // Simulate some delay in processing
            await fromAccount.withdraw(amount);
            await toAccount.deposit(amount);
            Console.WriteLine($"{amount} is successfully transferred from account {fromAccount.account_id} to account {toAccount.account_id}");
        }
    }
}
