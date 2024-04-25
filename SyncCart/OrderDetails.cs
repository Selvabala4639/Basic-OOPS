using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum OrderStatus{Default, Ordered, Cancelled}
namespace SyncCart
{
    public class OrderDetails
    {
        /*
        •	OrderID (Auto Increment – OID1001)
        •	CustomerID
        •	ProductID
        •	TotalPrice 
        •	PurchaseDate
        •	Quantity
        •	OrderStatus – (Enum- Default, Ordered, Cancelled)
        */
        //Static field
        private static int s_orderId=1000;
        //Properties
        public string CustomerID { get; set; }
        public string OrderID { get; }
        public string  ProductID { get; set; }
        public int  TotalPrice { get; set; }

        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string customerID, string productID, int totalPrice, DateTime purchaseDate, int quantity, OrderStatus orderStatus)
        {
            s_orderId++;
            OrderID = "OID" + s_orderId;
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity= quantity;
            OrderStatus= orderStatus;
        }
    }
}