using System;
using System.Collections.Generic;
using System.IO;
namespace OnlineLibraryManagement;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        FileHandling.ReadFromCSV();
        //Operations.AddingDefaultData();
        Operations.MainMneu();
        FileHandling.WriteToCSV();
        
    }
}