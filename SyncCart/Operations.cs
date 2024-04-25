using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public static class Operations
    {
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static List<ProductDetails> productList = new List<ProductDetails>();




        public static void MainMenu()

        {
            Console.WriteLine("*********Welcome to SynCart*********");
            int mainMenuOption;
            do
            {
                Console.WriteLine($"1.Registration\n2.Login\n3.Exit");
                mainMenuOption = int.Parse(Console.ReadLine());
                switch(mainMenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*********Registration*********");
                        CustomerRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*********Login*********");
                        CustomerLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*********Application Ended*********");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"Invalid Option");
                        break;
                    }
                }
            }while(mainMenuOption!=3);
            
        }//Main menu ends here

        public static void CustomerRegistration()
        {
            Console.Write("Enter your Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter your City: ");
            string customerCity = Console.ReadLine();
            Console.Write("Enter your Mobile Number: ");
            string mobileNumber= Console.ReadLine();
            Console.Write("Enter your EmailID: ");
            string emailID = Console.ReadLine();
            Console.Write("Enter your Wallet Balance: ");
            int walletBalance= int.Parse(Console.ReadLine());
            CustomerDetails customer= new CustomerDetails(customerName,customerCity,mobileNumber,emailID,walletBalance);
            customerList.Add(customer);
            Console.WriteLine($"Your registrarion has been successfully completed.\nYour customer ID is {customer.CustomerID}");
        }//CustomerRegistration ends here

        public static void CustomerLogin()
        {

        }//CustomerLogin ends here
        
        public static void AddingDefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails("Ravi",	"Chennai", "9885858588"		,"ravi@mail.com",50000);
            CustomerDetails customer2 = new CustomerDetails("Baskaran",	"Chennai", "9888475757"	,"baskaran@mail.com",60000);
            customerList.Add(customer1);
            customerList.Add(customer2);

            OrderDetails order1 = new OrderDetails("CID1001",	"PID101"	,20000	,DateTime.Now	,2,	OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002"	,"PID103",	40000	,DateTime.Now,	2,	OrderStatus.Ordered);
            orderList.Add(order1);
            orderList.Add(order2);

            ProductDetails product1 = new ProductDetails("Mobile (Samsung)",	10	,10000	,3);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)",	5	,15000,	2);
            ProductDetails product3 = new ProductDetails("Camara (Sony)",	3	,20000	,4);
            ProductDetails product4 = new ProductDetails("iPhone", 	5	,50000,	6);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)",	3,	40000	,3);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)",	5,	1000	,2);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)",	4,	500	,2);

            productList.AddRange(new List<ProductDetails>(){product1,product2,product3,product4,product5,product6,product7});


        foreach(CustomerDetails customer in customerList)
        {
            Console.WriteLine($"{customer.CustomerID} {customer.CustomerName} {customer.City} {customer.MobileNumber} {customer.WalletBalance} {customer.EmailID}");
        }
        Console.WriteLine();
        foreach(ProductDetails product in productList)
        {
            Console.WriteLine($"{product.ProductID} {product.ProductName} {product.Price} {product.Stock} {product.ShippingDuration}");
        }
        Console.WriteLine();
        foreach(OrderDetails order in orderList)
        {
            Console.WriteLine($"{order.OrderID} {order.CustomerID} {order.ProductID} {order.TotalPrice} {order.PurchaseDate} {order.Quantity} {order.OrderStatus}");
        }
        }

    }

}