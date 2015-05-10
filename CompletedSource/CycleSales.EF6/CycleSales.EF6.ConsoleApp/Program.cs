using System;
using System.Linq;
using CycleSales.EF6.ConsoleApp.CycleSalesModel;
using ObjectPrinter;
using System.Diagnostics;
using System.Collections.Generic;

namespace CycleSales.EF6.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // if you want to use sql server 2014 localdb, change the connection string from CycleSalesContext
            // remember that sql2014 localdb default instance name is (localdb)\mssqllocaldb

            using (var db = new CycleSalesContext())
            {
                db.Database.Initialize(false);
            }

            do
            {
                Console.Write("1 [select], 2 [round-fail], 3 [round-ok], 4 [batch update], 5 [massive insert]: ");
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

                if (test == "5")
                {
                    Console.Write("How many bikes would you like to insert? ");
                    var howMany = Convert.ToInt32(Console.ReadLine());

                    using (var db = new CycleSalesContext())
                    {
                        var nextId = db.Bikes.Max(b => b.Bike_Id) + 1;

                        var sw = Stopwatch.StartNew();
                        //var bikes = new List<Bike>();
                        for (int i = 0; i < howMany; i++)
                        {
                            db.Bikes.Add(new Bike
                            {
                                Bike_Id = nextId + i,
                                Description = Guid.NewGuid().ToString(),
                                ImageUrl = Guid.NewGuid().ToString(),
                                ModelNo = Guid.NewGuid().ToString(),
                                Name = Guid.NewGuid().ToString(),
                                Retail = 100m + i
                            });
                        }
                        //db.Bikes.AddRange(bikes);
                        var addTiming = sw.ElapsedMilliseconds;

                        sw.Restart();
                        db.SaveChanges();
                        var saveTiming = sw.ElapsedMilliseconds;

                        Console.WriteLine("Bikes added to EF context in {0} ms", addTiming);
                        Console.WriteLine("Bikes saved to database in {0} ms", saveTiming);
                        Console.WriteLine("Total time spent is {0} ms", addTiming + saveTiming);
                    }
                }
            } while (Console.ReadLine() != "exit");
        }
    }
}
