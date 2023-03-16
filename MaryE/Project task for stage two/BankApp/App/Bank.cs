using BankApp.Entity;
using System.Globalization;

namespace BankApp.App
{
    public static class Bank
    {
        public static void Logout()
        {
            Console.WriteLine("Thank You for banking with us..");
            Environment.Exit(0);
        }

        public static void Balance()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            string fileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}.txt";
            CreateAccount c = CreateAccount.LoadCustomerFromFile(username);

            var name = c.UserName.Split(' ')[1];

            if (name != username)
            {
                Console.WriteLine("Invalid username.");
                return;
            }
            else
            {
                Console.WriteLine($"Balance: {c.Balance}");
            }
        }

        public static void Deposit(string username)
        {
            string fileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}.txt";
            CreateAccount account = CreateAccount.LoadCustomerFromFile(username);

            Console.WriteLine("Enter the amount to deposit: ");
            decimal input = decimal.Parse(Console.ReadLine());

            var name = account.UserName.Split(' ')[1];

            if (name != username)
            {
                Console.WriteLine("Invalid username.");
            }

            if (input < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
            }

            else
            {
                var transaction = new Transactions(username, input, DateTime.Now);

                account.Balance += input;

                string transactionFileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}_Transaction.txt";
                using (StreamWriter writer = File.AppendText(transactionFileName))
                {
                    writer.WriteLine($"{transaction.UserName}|{transaction.Amount}|{transaction.Date}");
                }
                Console.WriteLine("Deposit of {0} successful. New balance is {1}.", input, account.Balance);
            }


            Console.WriteLine("Final balance is {0}.", account.Balance);

        }
        public static void Withdrawal(string username)
        {

            Console.Write("Enter withdrawal amount: ");
            decimal input = decimal.Parse(Console.ReadLine());

            List<CreateAccount> account = new List<CreateAccount>();

            string fileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}.txt";
            CreateAccount createAccount = CreateAccount.LoadCustomerFromFile(username);

            var name = createAccount.UserName.Split(' ')[1];
            if (name != username)
            {
                Console.WriteLine("Invalid username.");
                return;
            }

            if (input > createAccount.Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            var transaction = new Transactions(username, input, DateTime.Now);

            // Update the customer's balance
            createAccount.Balance -= input;

            // Append transaction to transaction history file
            string transactionFileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}_Transaction.txt";
            using (StreamWriter writer = File.AppendText(transactionFileName))
            {
                writer.WriteLine($"{transaction.UserName}|{transaction.Amount}|{transaction.Date}");
            }

            Console.WriteLine($"Withdraw successful. Your new balance is {createAccount.Balance}");
        }

        public static void SaveTransactionToFile(string username, Transactions transaction)
        {
            string fileName = "Transaction.txt";
            string filePath = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + username + fileName;

            // Write the transaction data to the file
            using (StreamWriter writer = File.AppendText(filePath))
            {
   
                writer.WriteLine($"{username}|{transaction.Amount}|{transaction.Date}");
            }
        }

        public static void DisplayTransactionHistory()
        {
            Console.Write("Enter username:");
            string username = Console.ReadLine();

            string fileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}.txt";
            string transactionFileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}_Transaction.txt";

            CreateAccount c = CreateAccount.LoadCustomerFromFile(username);

            var name = c.UserName.Split(' ')[1];
            if (name != username)
            {
                Console.WriteLine("Invalid username.");
                return;
            }

            else
            {
                // Display the customer's transaction history
                Console.WriteLine($"Transaction history for {c.UserName}");
                List<Transactions> transactions = LoadTransactionHistoryFromFile(username);
                foreach (Transactions transaction in transactions)
                {
                    Console.WriteLine($"Username: {transaction.UserName}\tAmount: {transaction.Amount}\tDate: {transaction.Date}");
                }
            }


            static List<Transactions> LoadTransactionHistoryFromFile(string username)
            {
                string fileName = @"C:\Users\erhie\Desktop\Bootcamp Projects\Balablue\MaryE\Project task for stage two\" + $"{username}_Transaction.txt";

                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException($"File not found: {fileName}");
                }

                List<Transactions> transactions = new List<Transactions>();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        DateTime date = DateTime.ParseExact(fields[2], "dd/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        decimal amount = decimal.Parse(fields[1]);
                        Transactions transaction = new Transactions(username, amount, date);
                        transactions.Add(transaction);
                    }
                }

                return transactions;
            }
        }
    }
}


