using ESEngine;
using Model;
using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace CrawDetailService
{
    public partial class Service1 : ServiceBase
    {
        Timer timer;
        EService elastic = new EService();
        private DateTime lastRun = DateTime.Now.AddDays(-1);
        public Service1()
        {
            InitializeComponent();

            timer = new Timer();
        }


        protected override void OnStart(string[] args)
        {
            timer = new Timer(10 * 60 * 1000); // every 2 hours
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Start();
        }
        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            // stop the timer while we are running the crawl detail webs
            timer.Stop();
            var oldDatas = await elastic.getOldestCrawledLinks(200);


            var taks = oldDatas.Select(d => crawlAndUpdate(d));
            await Task.WhenAll(taks);

            timer.Start();

        }

        public async Task<Data> crawl(Data data)
        {
            IStore store = new StoreFactory().GetStore(data.domain);

            var newData = await store.getData(data);
            return newData;
        }

        public async Task crawlAndUpdate(Data data)
        {
            var newData = await crawl(data);
            elastic.updateData(newData);
        }

        protected override void OnStop()
        {

        }
    }
}
