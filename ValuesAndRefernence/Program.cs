using System;
using ValuesAndRefernence;
namespace ValuesAndReference;
class Program{
    public static void Main(string[] args)
    {
        int num1 =10;
        Console.WriteLine($"{num1}");
        int num2 = num1;
        Console.WriteLine($"{num2}");
        num1 = 20;
        Console.WriteLine(num2);

        Student student1 = new Student();
        student1.Name = "Selva";
        Console.WriteLine(student1.Name);

        Student student2 = new Student();
        student2 = student1;
        Console.WriteLine(student2.Name);

        student1.Name = "Bala";
        Console.WriteLine(student1.Name);
        Console.WriteLine(student2.Name);
    }


}