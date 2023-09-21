using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class ShowRecords
    {
        public string AccountNum { get; set; }        public String CustomerName { get; set; }        public decimal Balance { get; set; }        public String AccountType { get; set; }



        public void DepositMoney(decimal amount, ShowRecords foundAccount)
        {
               foundAccount.Balance += amount;
               Console.WriteLine($"Deposit successful... Updated balance is: Rs.{foundAccount.Balance}");
        }
        public void WithdrawtMoney(decimal amount, ShowRecords foundAccount)
        {
               foundAccount.Balance -= amount;
               Console.WriteLine($"Deposit successful... Updated balance is: Rs.{foundAccount.Balance}");
        }

        }
   

}
