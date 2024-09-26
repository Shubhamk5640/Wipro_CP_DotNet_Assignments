using AccountUsingThreads;

class Program
{
    static void Main(string[] args)
    {
        Account account1 = new Account(1, 2000m);
        Account account2 = new Account(2, 1000m);

        // Display initial balances
        account1.DisplayBalance();
        account2.DisplayBalance();

        // Create AccountManager for transferring
        AccountManager accountManager1 = new AccountManager(account1, account2);
        AccountManager accountManager2 = new AccountManager(account2, account1);

        // Create threads to simulate transactions
        Thread thread1 = new Thread(() => accountManager1.Transfer(1000m)); // Transfer 500 from account1 to account2
        Thread thread2 = new Thread(() => accountManager2.Transfer(500)); // Transfer 250 from account2 to account1

        // Start transactions
        thread1.Start();
        thread2.Start();

        // Wait for threads to complete
        thread1.Join();
        thread2.Join();

        // Display final balances
        account1.DisplayBalance();
        account2.DisplayBalance();
    }
}