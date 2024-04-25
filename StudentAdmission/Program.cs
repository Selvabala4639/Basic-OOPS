using System;
using System.Collections.Generic;
using System.IO;

namespace StudentAdmission;
class Program
{
    public static void Main(string[] args)
    {
        //FileHandling.Create();
        //Default data Calling
        Operations.AddDefaultData();
        //FileHandling.ReadFromCSV();
        //Calling Main Menu
        Operations.MainMenu();
        //FileHandling.WriteToCSV();
    }
}