using System;
using System.Collections.Generic;

namespace Model
{
    public class Product
    {
        //[Ignore]
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string branch { get; set; }
        public string model { get; set; }
        public int status { get; set; }
        public DateTime created { get; set; }
        public DateTime lastUpdated { get; set; }
        public int totalLinks { get; set; }
        public List<string> data_id { get; set; }
    }
}
