using System;

namespace Model
{
    public class Data
    {
        public string _id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public string description { get; set; }
        public DateTime? time_create { get; set; }

        public DateTime? time_update { get; set; }

        public DateTime? time_load { get; set; }
        public string domain { get; set; }

        //status 0: Moi 1: Thanh cong 2: Loi
        public int status { get; set; }

        public int is_belonged { get; set; }
        public string product_id { get; set; }
        public Data() { }
        public Data(string url, string domain)
        {
            this.url = url;
            this.domain = domain;
            this.time_create = DateTime.Now;
            this.time_load = DateTime.Now;
        }

    }
}
