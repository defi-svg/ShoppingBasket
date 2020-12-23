using Shopping.Business;
using Shopping.Data;
using Shopping.Model;
using Shopping.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the scenario you prefer:");
            Console.WriteLine("\t1 - 1 Bread, 1 Butter, 1 Milk");
            Console.WriteLine("\t2 - 2 Butter, 2 Bread");
            Console.WriteLine("\t3 - 4 Milks");
            Console.WriteLine("\t4 - 2 Butter, 1 Bread, 8 Milk");

            BasketBLL b = new BasketBLL();

            decimal totalSum = 0;

            switch (Console.ReadLine())
            {
                case "1":
                    totalSum=b.ShoppingList(1);
                    break;
                case "2":
                    totalSum=b.ShoppingList(2);
                    break;
                case "3":
                    totalSum=b.ShoppingList(3);
                    break;
                case "4":
                    totalSum=b.ShoppingList(4);
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Final shopping value: {totalSum:00.00 $}");

            Console.WriteLine("Press any key to finish shopping");
            Console.ReadKey();
        }
    }
}
