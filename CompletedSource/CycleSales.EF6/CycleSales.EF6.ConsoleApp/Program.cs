using System;
using System.Linq;
using CycleSales.EF6.ConsoleApp.CycleSalesModel;
using ObjectPrinter;

namespace CycleSales.EF6.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Run Update-Database in "Package Manager Console" before run the application.
            //

            // if you want to use sql server 2014 localdb, change the connection string from CycleSalesContext
            // remember that sql2014 localdb default instance name is (localdb)\mssqllocaldb
            
            Console.Write("1 [select], 2 [round-fail], 3 [round-ok], 4 [update single command]: ");
            var test = Console.ReadLine();

            if (test == "1")
            {
                using (var db = new CycleSalesContext())
                {
                    var bikes = db.Bikes.ToList();
                    Console.WriteLine(bikes.Dump());
                }
            }

            if (test == "2")
            {
                using (var db = new CycleSalesContext())
                {
                    var priceService = new PriceService(db);
                    var prices = priceService.CalculateForeignPrices(1.3m);
                    Console.WriteLine(prices.Dump());
                }
            }

            if (test == "3")
            {
                using (var db = new CycleSalesContext())
                {
                    var priceService = new PriceService(db);
                    var prices = priceService.CalculateForeignPricesForEf6(1.3m);
                    Console.WriteLine(prices.Dump());
                }
            }

            if (test == "4")
            {
                using (var db = new CycleSalesContext())
                {
                    var b1 = db.Bikes.Find(1);
                    b1.Description = "(edit)" + b1.Description;
                    var b2 = db.Bikes.Find(2);
                    b2.Description = "(edit)" + b2.Description;
                    db.SaveChanges();
                    Console.WriteLine("Done!");
                }
            }
        }
    }
}
