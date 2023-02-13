using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawDataFromWebSales
{
    public class Data
    {
        public string _id { get; set; }
        public string url { get; set; }
        public string domain { get; set; }
    
        //status 0: Moi 1: Thanh cong 2: Loi
        public int status { get; set; }
        public DateTime? time { get; set; }

       

        public Data(string _id, string url, int status, string folder, string domain, DateTime? time = null)
        {
            this._id = _id;
            this.url = url;
            this.status = status;
            this.time = time == null ? DateTime.Now : time;
            this.domain = domain;
        }

        public Data() { }

    }
}
