using System.Collections.Generic;

namespace CycleSales.EF6.ConsoleApp.CycleSalesModel
{
    public class Bike
    {
        public int Bike_Id { get; set; }
        public string Name { get; set; }
        public string ModelNo { get; set; }
        public decimal Retail { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
