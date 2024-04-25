using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking
{
    public class CustomerDetails
    {
        //private string _customerName;

        
        private static int s_customerID = 1000;

        public string CustomerID {get;}
        public string CustomerName { get; set; }

        public int Balance { get; set; }

        public Gender Gender { get; set; }

        public long Phone { get; set; }

        public string MailID { get; set; }

        public DateTime DOB { get; set; }


        public CustomerDetails( string name,int balance, Gender gender, long phone, string mail, DateTime dob)
        {
            s_customerID++;

            CustomerID ="HDFC"+s_customerID;
            CustomerName = name;
            Balance= balance;
            Gender=gender;
            Phone =phone;
            MailID =mail;
            DOB=dob;    
        }

        public int Deposit(int amount, int balance)
        {
            return amount+balance;
        }
        public int Withdraw(int amount, int balance)
        {
            return balance-amount;
        }
    }
}