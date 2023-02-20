using ESEngine;
using Model;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace CrawlLinksService
{
    public partial class Service1 : ServiceBase
    {
        readonly string[] domains = { "www.dienmayxanh.com", "dienmaycholon.vn", "www.nguyenkim.com", "mediamart.vn", "hc.com.vn" };
        Timer timer;
        EService eService = new EService();
        private DateTime lastRun = DateTime.Now.AddDays(-1);
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer(10 * 60 * 1000); // every 10 minutes
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (lastRun.Date == DateTime.Now.Date) return;


        }

        private async Task updateLinks(List<Data> datas)
        {

        }

        protected override void OnStop()
        {
            timer.Stop();
        }
    }
}
