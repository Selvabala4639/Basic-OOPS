using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class CustomerDetails
    {
        /*
        •	CustomerID (Auto Increment -CID1000)
        •	Name
        •	City
        •	MobileNumber
        •	WalletBalance
        •	EmailID

        */
        private static int s_customerID= 1000;
        public string CustomerID { get;  }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public int WalletBalance { get; set; }
        public string EmailID { get; set; }

        public CustomerDetails(string customerName, string city, string mobileNumber,  string emailID ,int walletBalance)
        {
            s_customerID++;
            CustomerID= "CID" +s_customerID;
            CustomerName= customerName;
            City = city;
            MobileNumber= mobileNumber;
            WalletBalance= walletBalance;
            EmailID=emailID;
        }

        public  int WalletRecharge(int amount)
        {
            WalletBalance = amount + WalletBalance;
            return WalletBalance;
        }

        public int DeductBalance(int amount)
        {
            WalletBalance -=amount;
            return WalletBalance;
        }
    }
}