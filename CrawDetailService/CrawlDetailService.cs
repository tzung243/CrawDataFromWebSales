using ESEngine;
using Model;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace CrawDetailService
{
    public partial class CrawlDetailService : ServiceBase
    {
        Timer timer;
        EService elastic = new EService();
        public CrawlDetailService()
        {
            InitializeComponent();

            timer = new Timer();
        }


        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            timer = new Timer(120 * 60 * 1000); // every 2 hours
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Enabled = true;

        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            // stop the timer while we are running the crawl detail webs
            timer.Enabled = false;

            var oldDatas = elastic.getOldestCrawledLinks(200);

            Parallel.ForEach(oldDatas, crawlAndUpdate);

            timer.Enabled = true;
        }

        public Data crawl(Data data)
        {
            IStore store = new StoreFactory().GetStore(data.url);

            var newData = store.getData(data).Result;
            return newData;
        }

        public void crawlAndUpdate(Data data)
        {
            var newData = crawl(data);
            if (!string.IsNullOrEmpty(newData._id))
            {
                elastic.updateData(newData);
            }
        }

        protected override void OnStop()
        {

        }
    }
}
