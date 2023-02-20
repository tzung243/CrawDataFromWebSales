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
    public partial class CrawlLinksService : ServiceBase
    {
        readonly string[] urls = { "https://mediamart.vn/tivi/", "https://www.dienmayxanh.com/tivi", "https://www.nguyenkim.com/tivi/", "https://dienmaycholon.vn/tivi-led", "https://hc.com.vn/ords/c--tivi" };
        Timer timer;
        EService eService = new EService();
        private DateTime lastRun;
        public CrawlLinksService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            lastRun = DateTime.Now.AddDays(-1);
            timer = new Timer(10 * 60 * 1000); // every 10 minutes
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (lastRun.Date == DateTime.Now.Date) return;

            var factory = new StoreFactory();
            Task.Run(async () =>
            {
                foreach (var url in urls)
                {
                    var store = factory.GetStore(url);
                    var links = crawl(store, url);
                    await addNew(links, store.getDomain());
                }
            });
            lastRun = DateTime.Now;
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
