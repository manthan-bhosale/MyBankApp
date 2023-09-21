using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankClassLibrary;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyBankApp
{
    class Program
    {
        static void Main(string[] args)
        {

        List<ShowRecords> customer = new List<ShowRecords>
        {
            new ShowRecords() { AccountNum = "C1452", CustomerName = "Alice Smith", Balance = 1250, AccountType = "Current"},
            new ShowRecords() { AccountNum = "S1042", CustomerName = "Bob Johnson", Balance = 15000, AccountType = "Saving"},
            new ShowRecords() { AccountNum = "S0052", CustomerName = "Carol Williams", Balance = 12000, AccountType = "Saving"},
            new ShowRecords() { AccountNum = "C1002", CustomerName = "David Jones", Balance = 100, AccountType = "Current"},
            new ShowRecords() { AccountNum = "C1005", CustomerName = "Eve Brownd ", Balance = 50050, AccountType = "Current"},
        };
            ShowRecords bankaccount = new ShowRecords();
            Console.WriteLine("Welcome to my Bank");
            Console.WriteLine("________________________________________________________________________________________________________");

            while (true)
            {
                Console.WriteLine("Enter Choice ");
                Console.WriteLine("1. Deposit money");
                Console.WriteLine("2. Withdraw money");
                Console.WriteLine("3. Check Account Balance");
                Console.WriteLine("4. New Account Opening"); 
                Console.WriteLine("5. Get Account Records");
                Console.WriteLine("6. Get all saving account records:");
                Console.WriteLine("7. Get all current account records:");
                var choice = Console.ReadLine();
                Console.WriteLine("________________________________________________________________________________________________________");
                
                switch (choice)
                {
                case "1":
                    {   
                        Console.WriteLine("Enter account Number: ");
                        var accountfinder = Console.ReadLine();
                        ShowRecords foundAccount = customer.Find(account => account.AccountNum == accountfinder);

                            if (foundAccount != null)
                            {
                                Console.WriteLine("Enter Amount: ");
                                decimal deposit = decimal.Parse(Console.ReadLine());
                                bankaccount.DepositMoney(deposit, foundAccount );
                            }
                            else
                            {
                                Console.WriteLine("Account not found.");
                            }
                        break;
                    }

                case "2":
                    {
                        Console.WriteLine("Enter account Number: ");
                        var accountfinder = Console.ReadLine();
                        ShowRecords foundAccount = customer.Find(account => account.AccountNum == accountfinder);

                        if (foundAccount != null)
                        {   
                            Console.WriteLine("Enter Amount: ");
                            var withdraw = decimal.Parse(Console.ReadLine());
                                if(withdraw <= foundAccount.Balance)
                                {
                                    bankaccount.WithdrawtMoney(withdraw, foundAccount);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance...!!!");
                                }        
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    }

                case "3":
                    {
                        Console.WriteLine("Enter account Number: ");
                        var accountfinder = Console.ReadLine();
                        ShowRecords foundAccount = customer.Find(account => account.AccountNum == accountfinder);

                        if (foundAccount != null)
                        {   
                            Console.WriteLine($"Your account balance is: Rs.{foundAccount.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    }

                case "4":
                    {
                    Console.Write("Enter your name: ");
                    string accountHolder = Console.ReadLine();
                    Console.Write("Enter initial deposit: ");
                    decimal initialDeposit = decimal.Parse(Console.ReadLine());
                            

                    Console.WriteLine("Choose account type:");
                    Console.WriteLine("1. Saving Account Opening");
                    Console.WriteLine("2. Current Account Opening");
                    var choice2 = Console.ReadLine();

                    switch (choice2)
                    {
                    case "1":
                        {             
                            
                            Random random = new Random();
                            int newNumber;
                        do
                        {
                            newNumber = random.Next(10000); // Generate a random number between 0 and 9999  
                                            
                        } while (newNumber.ToString().Length != 4);
          
                             Console.WriteLine($"Please wait generating  account number..... " +
                                               $"Your 4 digit account number is: " +"S"+newNumber);

                            customer.Add(new ShowRecords { AccountNum = "S" + newNumber,
                                                           CustomerName = accountHolder, 
                                                           Balance = initialDeposit,
                                                           AccountType = "Saving Account"});

                            Console.WriteLine("Saving account opened successfully...Enter 5 to display details...!");
                        }
                            break;
                    case "2":
                        {
        
                            Random random = new Random();
                            int newNumber;
                        do
                        {
                            newNumber = random.Next(10000); // Generate a random number between 0 and 9999

                        } while (newNumber.ToString().Length != 4);
                             Console.WriteLine($"Please wait generating  account number..... " +
                                                $"Your 4 digit account number is: " +"C"+newNumber);  
                                        
                            customer.Add(new ShowRecords { AccountNum = "C" + newNumber, 
                                                           CustomerName = accountHolder, 
                                                           Balance = initialDeposit,
                                                           AccountType = "Current Account"});

                            Console.WriteLine("Current account opened successfully...Enter 5 to display details...!");
                        }           
                        break;
                        default:
                            {
                                Console.WriteLine("Enter valid choice");
                                break;
                            }
                    }
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("Enter Account Number: ");
                        var accountfinder = Console.ReadLine();
                        ShowRecords foundAccount = customer.Find(account => account.AccountNum == accountfinder);
                        if (foundAccount != null)
                        { 
                            Console.WriteLine("_______________________________________________________________________________________________");
                            Console.WriteLine($"Name: {foundAccount.CustomerName}   " + $"Account Number: {foundAccount.AccountNum}     "
                                + $"Balance: Rs.{foundAccount.Balance}   "  + $"Account Type: {foundAccount.AccountType} " );
                            Console.WriteLine("_______________________________________________________________________________________________");
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    }
                case "6":
                    {
                        string searchTerm = "S";
                        var savingaccounts = customer.Where(account => account.AccountNum.Any(c => searchTerm.Contains(c)));
                        Console.WriteLine("Records of All saving account are as follows");
                        Console.WriteLine("_______________________________________________________________________________________________");
                        foreach (var account in savingaccounts)
                        {
                            Console.WriteLine( $"Name: {account.CustomerName}   " + $"Account Number: {account.AccountNum}  "
                                + $"Balance: Rs.{account.Balance}   " + $"Account type: {account.AccountType}");
                        }
                        Console.WriteLine("_______________________________________________________________________________________________");
                        break;
                    }
                case "7":
                    {
                        string searchTerm = "C";
                        var currentaccounts = customer.Where(account => account.AccountNum.Any(c => searchTerm.Contains(c)));
                        Console.WriteLine("Records of All current account are as follows");
                        Console.WriteLine("_______________________________________________________________________________________________");
                        foreach (var account in currentaccounts)
                        {
                            Console.WriteLine($"Name: {account.CustomerName}   " + $"Account Number: {account.AccountNum}  "
                                + $"Balance: Rs.{account.Balance}   " + $"Account type: {account.AccountType}");
                        }
                        Console.WriteLine("_______________________________________________________________________________________________");
                        break;
                    }
                default:
                    Console.WriteLine("Enter valid choice");
                    break;
                }
            }

        }
    }
}
