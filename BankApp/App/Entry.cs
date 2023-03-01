using BankApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.App
{
    public class Entry
    {
        public static void Menu()
        {
            Console.Clear();
            Console.Title = "Banking App";
            
            Console.WriteLine("-----------Welcome to Banking App--------------\n");
            Console.WriteLine("1.  Create an Account                  ");
            Console.WriteLine("2.  Login                              ");
        }

        public static void Auth()
        {
            Console.WriteLine("-----------Welcome to My Bank--------------\n");
            Console.WriteLine("3.  Account Balance                    ");
            Console.WriteLine("4.  Cash Deposit                       ");
            Console.WriteLine("5.  Withdrawal                         ");
            Console.WriteLine("6.  Summary                            ");
        }
        //private Dictionary<string, CreateAccount> users = new Dictionary<string, CreateAccount>();
        public void MenuOptions()
        {
            double accountBalance = 100000;

            Console.WriteLine("Enter Transaction Number: ");
            int options = int.Parse(Console.ReadLine());

            switch (options)
            {
                case (int)AppMenu.AccountBalance:
                    if (options == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Account Balance is N {accountBalance}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.WriteLine("Press Enter to continue");

                    break;

                case (int)AppMenu.CreateAccount:
                    if (options == 1)
                    {
                        Bank.Signup();
                    }

                    Console.WriteLine("Press Enter to continue");

                    break;

                case (int)AppMenu.Login:
                    if (options == 2)
                    {

                        Bank.Login();
                    }

                    Console.WriteLine("Press Enter to continue");

                    break;

                case (int)AppMenu.CashDeposit:
                    if (options == 4)
                    {

                        Bank.Deposit();
                    }

                    Console.WriteLine("Press Enter to continue");

                    break;

                case (int)AppMenu.Withdrawal:
                    if (options == 5)
                    {

                        Bank.Withdrawal();
                    }

                    Console.WriteLine("Press Enter to continue");

                    break;

                case (int)AppMenu.Summary:
                    if (options == 6)
                    {

                        Bank.Transactions();
                    }

                    Console.WriteLine("Press Enter to continue");

                    break;

                default:
                    Console.WriteLine("Enter correct deatils");
                    break;
            }
            Console.ReadLine();

        }
    }
}
