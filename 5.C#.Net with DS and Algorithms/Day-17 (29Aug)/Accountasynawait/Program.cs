using System;
using System.Threading.Tasks;

namespace Accountasynawait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account(1, 1000);
            Account account2 = new Account(2, 2000);

            Console.WriteLine($"Balance in account {account1.account_id} is: {account1.balance}");
            Console.WriteLine($"Balance in account {account2.account_id} is: {account2.balance}");

            AccountManager manager = new AccountManager(account1, account2);

            Task task1 = new Task(async () => { await manager.transfer(account1, account2, 500); });
            Task task2 = new Task(async () => { await manager.transfer(account2, account1, 250); });

            task1.Start();
            task2.Start();

            task1.Wait();
            task2.Wait();

            Console.WriteLine($"Balance in account {account1.account_id} is: {account1.balance}");
            Console.WriteLine($"Balance in account {account2.account_id} is: {account2.balance}");

            Console.ReadLine();
        }
    }
}