using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountasynawait
{
    public class Account
    {
        public int account_id { get; set; }
        public double balance { get; set; }

        public Account(int id, double amount)
        {
            this.account_id = id;
            this.balance = amount;
        }

        public Task<double> deposit(double amount)
        {
            this.balance += amount;
            Console.WriteLine($"Balance after depositing {amount} in account {account_id} is {this.balance}");
            return Task.FromResult(balance);
        }

        public Task<double> withdraw(double amount)
        {
            if (balance >= amount)
            {
                this.balance -= amount;
                Console.WriteLine($"Balance after withdrawing {amount} from account {account_id} is {this.balance}");
                return Task.FromResult(amount);
            }
            else
            {
                Console.WriteLine($"Account {account_id} has insufficient balance\nTransaction failed");
                return Task.FromResult(0.0);
            }
        }
    }
}
