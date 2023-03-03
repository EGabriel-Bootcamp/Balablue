using System;

public class LoggedInMenu
{
	public static void ShowMenu(string fileName, string accountNumber)
	{
        while (true)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Show Account Summary");
            Console.WriteLine("5. Logout");

            Console.WriteLine("Choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Activity.Deposit(fileName, accountNumber);
                    break;
                case "2":
                    Activity.Withdraw(fileName, accountNumber);
                    break;
                case "3":
                    Activity.CheckBalance(fileName, accountNumber);
                    break;
                case "4":
                    Activity.ShowAccountSummary(fileName, accountNumber);
                    break;
                case "5":
                    Console.WriteLine("Logout successful!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
