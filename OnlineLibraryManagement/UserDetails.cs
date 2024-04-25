using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum Gender{Select, Male, Female}
public enum Department{ECE, EEE, CSE}
namespace OnlineLibraryManagement
{

    public class UserDetails
    {
        /*
                a.	UserID (Auto Increment – SF3000)
        b.	UserName
        c.	Gender
        d.	Department – (Enum – ECE, EEE, CSE)
        e.	MobileNumber
        f.	MailID

        */
        private static int s_userID=3000;
        public string  UserID { get;  }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public  Department Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }


        public void WalletRecharge(int amount)
        {
            WalletBalance = WalletBalance + amount;
             Console.WriteLine($"Current balance is {WalletBalance}");
        }

        public void DeductBalance(double amount)
        {
            WalletBalance = WalletBalance - amount;
            Console.WriteLine($"Current balance is {WalletBalance}");
        }

        public UserDetails(string userName, Gender gender, Department department, string mobileNumber, string mailID ,int walletBalance)
        {
            s_userID++;
            UserID = "SF" +s_userID;
            UserName  = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailID = mailID;
            WalletBalance= walletBalance;
        }

        public UserDetails(string user)
        {
            string [] values = user.Split(",");
            s_userID = int.Parse(values[0].Remove(0,2));
            UserID = values[0];
            UserName  = values[1];
            Gender = Enum.Parse<Gender>(values[2]);
            Department = Enum.Parse<Department>(values[3]);;
            MobileNumber = values[4];
            MailID = values[5];
            WalletBalance= int.Parse(values[6]);
        }
    }
}