using System;
using System.IO;

public class UserAccount
{
    public static void Signup(string fileName)
    {
    
            Console.WriteLine("Please enter your name:");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter your email:");
            var email = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            var password = Console.ReadLine();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
            {
                // Generate a unique 10-digit account number starting with 2
                Random rand = new Random();
                string accountNumber = "2" + rand.Next(100000000, 999999999).ToString();

                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine($"{accountNumber},{name},{email},{password},0");
                }
                Console.WriteLine("Signup successful!");
                Console.WriteLine("Your account number is " + accountNumber);
                LoggedInMenu.ShowMenu(fileName, accountNumber);
            }
            else
            {
                Console.WriteLine("Invalid details! You have entered a null or empty value. Try again!!!");
            }
        
    }
    public static string Login(string fileName)
    {
        while (true) 
        { 
            Console.WriteLine("Please enter your account number:");
            var accountNumber = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            Console.Write("Enter password: ");
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            string[] lines = File.ReadAllLines(fileName);

            if (string.IsNullOrWhiteSpace(accountNumber) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields[0] == accountNumber && fields[1] == password)
                {
                    Console.WriteLine("Login successful!");
                    return accountNumber;
                }
            }

            Console.WriteLine("Invalid account number or password. Please try again.");
        }
    }
}

