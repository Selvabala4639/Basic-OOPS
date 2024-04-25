using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillCalculation
{
    public class BillBalculation
    {
        private static int s_meterId = 1000;
        private static int s_billId =2000;
        public string MeterId { get; }

        public string  UserName { get; set; }

        public long Phone { get; set; }

        public string MailId { get; set; }
        public int UnitsUsed { get; set; }

        public int TotalAmount { get; set; }
        public string BillId { get; set; }

        public  BillBalculation(string userName, long phone, string mail)
        {
            s_meterId++;
            MeterId = "EB"+ s_meterId;
            s_billId++;
            BillId = "Bill"+s_billId;
            UserName=userName;
            Phone =phone;
            MailId = mail;
            // UnitsUsed= units;
            // TotalAmount = amount;
        }
        public int CalculateAmount()
        {
            TotalAmount= 5*UnitsUsed;
            return TotalAmount;
        }
    }
}