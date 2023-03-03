using System;
using System.IO;
using System.Linq;

namespace FraudulentBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "accounts.txt");

            Console.WriteLine("Welcome to the Fraudulent Bank application!");

            while (true)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Signup");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.WriteLine("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UserAccount.Signup(fileName);
                        break;
                    case "2":
                        string accountNumber = UserAccount.Login(fileName);

                        if (accountNumber != null)
                        {
                            LoggedInMenu.ShowMenu(fileName, accountNumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials. Please try again.");
                        }
                        UserAccount.Login(fileName);
                        break;
                    case "3":
                        Console.WriteLine("Have a nice day");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option Selection");
                        break;
                }
            }
        }
    }
}