using System;

namespace CrawDataFromWebSales
{
    public class Product
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string branch { get; set; }
        public string model { get; set; }
        public int status { get; set; }
        public DateTime created { get; set; }
        public DateTime lastUpdated { get; set; }
        public int totalLinks { get; set; }
    }
}
