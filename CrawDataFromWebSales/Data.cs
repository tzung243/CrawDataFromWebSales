using System;

namespace CrawDataFromWebSales
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

        /*

         public Data(string _id, string url, string name,  int status, string domain, DateTime? time_create = null, DateTime? time_update, )
         {
             this._id = _id;
             this.url = url;
             this.status = status;
             this.time_crete = time == null ? DateTime.Now : time;
             this.domain = domain;
         }*/

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
