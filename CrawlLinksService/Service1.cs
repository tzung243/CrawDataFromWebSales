using ESEngine;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace CrawlLinksService
{
    public partial class Service1 : ServiceBase
    {
        readonly string[] urls = { "https://www.dienmayxanh.com/tivi", "https://www.nguyenkim.com/tivi/", "https://dienmaycholon.vn/tivi-led", "https://hc.com.vn/ords/c--tivi", "https://mediamart.vn/tivi/" };
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

            timer.Stop();
            var factory = new StoreFactory();
            await Task.Run(async () =>
            {
                foreach (var url in urls)
                {
                    var store = factory.GetStore(url);
                    var links = crawl(store, url);
                    await addNew(links, store.getDomain());
                }
            });
            lastRun = DateTime.Now;
            timer.Start();
        }

        private List<string> crawl(IStore store, string url)
        {

            var links = store.getLinkProducts(url);

            return links;
        }

        private async Task addNew(List<string> links, string domain)
        {
            var newDatas = links.Where(w => !eService.checkExitsData(w)).Select(s => new Data(s, domain));
            await eService.indexDatasAsync(newDatas);
        }

        protected override void OnStop()
        {
            timer.Stop();
        }
    }
}
