using System;

public class Activity
{
    public static void Deposit(string fileName, string accountNumber)
    {
        string[] lines = File.ReadAllLines(fileName);

        var line = lines.FirstOrDefault(l => l.StartsWith(accountNumber + ","));

        if (line != null)
        {

            string[] values = line.Split(',');
            decimal balance = decimal.Parse(values[4]);

            Console.WriteLine("Enter amount to deposit:");
            var amount = decimal.Parse(Console.ReadLine());

            balance += amount;
            values[4] = balance.ToString();
            string newLine = string.Join(",", values);
            int index = Array.IndexOf(lines, line);
            lines[index] = newLine;
            File.WriteAllLines(fileName, lines);

            Console.WriteLine("---DEPOSIT NOTIFICATION--");
            Console.WriteLine($"Deposit successful! New balance is: N{balance:N2}");
            Console.WriteLine("-----------------");
        }
        else
        {
            Console.WriteLine("Invalid account number. Please try again.");
        }
    }

    public static void Withdraw(string fileName, string accountNumber)
    {
        string[] lines = File.ReadAllLines(fileName);

        var line = lines.FirstOrDefault(l => l.StartsWith(accountNumber + ","));

        if (line != null)
        {
            string[] values = line.Split(',');
            decimal balance = decimal.Parse(values[4]);

            Console.WriteLine("Enter amount to withdraw:");
            var amount = decimal.Parse(Console.ReadLine());

            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance. Please try again.");
            }
            else
            {
                balance -= amount;
                values[4] = balance.ToString();
                string newLine = string.Join(",", values);
                int index = Array.IndexOf(lines, line);
                lines[index] = newLine;
                File.WriteAllLines(fileName, lines);

                Console.WriteLine("---WITHDRAWAL NOTIFICATION--");
                Console.WriteLine($"Withdrawal successful! New balance is: N{balance:N2}");
                Console.WriteLine("-------------------");
            }
        }
        else
        {
            Console.WriteLine("Invalid account number. Please try again.");
        }
    }

    public static void CheckBalance(string fileName, string accountNumber)
    {
        string[] lines = File.ReadAllLines(fileName);

        var line = lines.FirstOrDefault(l => l.StartsWith(accountNumber + ","));

        if (line != null)
        {
            string[] values = line.Split(',');
            decimal balance = decimal.Parse(values[4]);
            Console.WriteLine("---BALANCE NOTIFICATION--");
            Console.WriteLine($"Your balance is: N{balance:N2}");
            Console.WriteLine("--------------------");
        }
        else
        {
            Console.WriteLine("Invalid account number. Please try again.");
        }
    }
    public static void ShowAccountSummary(string fileName, string accountNumber)
    {
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] fields = line.Split(',');

            if (fields[0] == accountNumber)
            {
                Console.WriteLine("---ACCOUNT SUMMARY---");
                Console.WriteLine($"Account Number: {fields[0]}");
                Console.WriteLine($"Account Name: {fields[1]}");
                Console.WriteLine($"Email: {fields[2]}");
                double currentBalance = 0;
                if (double.TryParse(fields[4], out currentBalance))
                {
                    Console.WriteLine($"Current Balance: N{currentBalance:N2}");
                }
                else
                {
                    Console.WriteLine("Invalid balance format.");
                }
                Console.WriteLine("--------------------");
                return;
            }
        }

        Console.WriteLine("Account not found.");
    }
}

