using BankApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.App
{
    public static class Bank
    {
        public static string Signup()
        {
            Console.Clear();

            string username;
            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            while (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username field is required. Please enter your username again.");
                username = Console.ReadLine();
            }

            string email;
            Console.Write("Enter your email: ");
            email = Console.ReadLine();

            while (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email field is required. Please enter your email again.");
                email = Console.ReadLine();
            }

            string age;
            Console.Write("Enter your age: ");
            age = Console.ReadLine();

            while (string.IsNullOrEmpty(age))
            {
                Console.WriteLine("age field is required. Please enter your age again.");
                age = Console.ReadLine();
            }

            string phone;
            Console.Write("Enter your phone: ");
            phone = Console.ReadLine();

            while (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("phone field is required. Please enter your phone again.");
                phone = Console.ReadLine();
            }

            string password;
            Console.Write("Enter your password: ");
            password = Console.ReadLine();

            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password field is required. Please enter your password again.");
                password = Console.ReadLine();
            }
            string accountNum = GenerateAccountNum();

            var userInfo = $"UserName: {username}, Email: {email}, Age: {age}, Phone: {phone}, Password: {password}, AcctNum {accountNum}"; 
            File.AppendAllText($@"C:\Users\erhie\Desktop\MaryE\Project task for stage two\BankApp\{accountNum}.Txt", userInfo);

            Console.WriteLine("Account Created successfully.");

            return userInfo;
        }

        public static string GenerateAccountNum()
        {
            //string accountType = "Savings";
            int randomNum = new Random().Next(10000000, 99999999);
            string accountNum = $"{randomNum}";
            Console.WriteLine($"Account Number is: {accountNum}");
            return accountNum;
        }

        public static void Login()
        {
            Console.Clear();
            int attempts = 0;
            string username, password;

            do
            {
                Console.Write("Please enter your username:");
                username = Console.ReadLine();

                Console.Write("Please enter your password:");
                password = Console.ReadLine();

                attempts++;

                if (VerifyCredentials(username, password))
                {
                    Console.WriteLine("Credentials verified. Welcome to the application!");
                    // Take the user to the main screen here.
                    Entry.Auth();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid credentials. Please try again.");
                }
            } while (attempts < 3);

            if (attempts == 3)
            {
                Console.WriteLine("Too many attempts. Your account has been locked.");
                
                Environment.Exit(0);
            }

            Console.ReadKey();
            //return login;
        }

        public static bool VerifyCredentials(string username, string password)
        {
            string accountNum = GenerateAccountNum();
            using (StreamReader file = new StreamReader($@"C:\Users\erhie\Desktop\MaryE\Project task for stage two\BankApp\Balablue{accountNum}.Txt"))
            {
                string user;
                while ((user = file.ReadLine()) != null)
                {
                    //var splitString = user.Split(' ');

                    //password = splitString[splitString.Length - 1];
                    //Console.WriteLine(user);

                    string filePath = $@"C:\Users\erhie\Desktop\MaryE\Project task for stage two\BankApp\Balablue{accountNum}.Txt";
                    string data = null;

                    if (File.Exists(filePath))
                    {
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            data = reader.ReadLine();
                        }
                    }

                    Console.WriteLine("Data read from file: " + data);

                }
                file.Close();
            }

            return username == "username" && password == "password";
           
        }

        public static double Deposit()
        {
            double accountBalance = 100000;
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Enter the amount to deposit (or 'q' to quit): ");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    quit = true;
                }
                else
                {
                    double deposit;
                    bool isNumeric = double.TryParse(input, out deposit);

                    if (!isNumeric || deposit < 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    }
                    else
                    {
                        accountBalance += deposit;
                        Console.WriteLine($"Deposit of {0} successful. New balance is {1}.", deposit, accountBalance);
                    }
                }
            }

            Console.WriteLine($"Exiting program. Final balance is {0}.", accountBalance);
            return accountBalance;
        }

        public static void Withdrawal()
        {
            decimal accountBalance = 100000;
          
            Console.Write("Enter withdrawal amount: ");
            string input = Console.ReadLine();

            decimal withdrawalAmount;
            if (decimal.TryParse(input, out withdrawalAmount) && withdrawalAmount >= 0)
            {
                // check if withdrawal amount is greater than balance
                if (withdrawalAmount <= accountBalance)
                {
                    // deduct withdrawal amount from balance
                    accountBalance -= withdrawalAmount;
                    Console.WriteLine($"Withdrawal successful. New balance: {0:C}", accountBalance);
                }
                else
                {
                    Console.WriteLine("Not sufficient fund available.");
                }
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }

        public static void Transactions()
        {

            List<Transactions> transactions = new List<Transactions> {
            new Transactions { Date = DateTime.Parse("2/1/2023"), Amount = 1000, Balance = 1000 },
            new Transactions { Date = DateTime.Parse("2/4/2023"), Amount = 5000, Balance = 6000 },
            new Transactions { Date = DateTime.Parse("2/5/2023"), Amount = -2000, Balance = 4000 }
            };

            // Loop through transactions and print information
            foreach (Transactions t in transactions)
            {
                Console.WriteLine($"Transaction Date: {0} === Transaction Amount: {1} === Current Balance: {2}",
                t.Date, t.Amount, t.Balance);
            }
        }
    }

}


