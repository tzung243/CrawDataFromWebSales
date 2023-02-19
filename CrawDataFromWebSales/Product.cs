using System;

namespace CrawDataFromWebSales
{
    public class Product
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Branch { get; set; }
        public string Model { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public int TotalLinks { get; set; }
    }
}
