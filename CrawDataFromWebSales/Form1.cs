using ESEngine;
using Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;


namespace CrawDataFromWebSales
{
    public partial class Form1 : Form
    {
        EService eService;
        int pageNumber = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            eService = new EService();
            DatagridViewAction.createView(dataGridView);
            await Load_DataGridView();
            getData();
        }


        private async Task Load_DataGridView()
        {
            long counter = await eService.countIndex("test");
            int pageTail;
            if (counter % 20 == 0)
            {
                pageTail = (int)counter / 20;
            }
            else
            {
                pageTail = (int)counter / 20 + 1;
            }

            dataGridView.Invoke(new Action(async () =>
            {
                if (pageTail == 1)
                {
                    button_next.Enabled = false;
                    button_prev.Enabled = false;
                }
                else if (pageNumber == 1)
                {

                    button_prev.Enabled = false;
                    button_next.Enabled = true;

                }
                else if (pageNumber == pageTail)
                {
                    button_next.Enabled = false;
                    button_prev.Enabled = true;

                }
                else
                {
                    button_next.Enabled = true;
                    button_prev.Enabled = true;
                }
                page_number.Text = pageNumber.ToString();
                List<Data> list = await loadPageNumber(pageNumber);
                DatagridViewAction.setData(list, dataGridView);

            }));
        }

        private async void button_craw_Click(object sender, EventArgs e)
        {
            button_craw.Enabled = false;
            string url = textbox_url.Text;
            await getLinks(url);
            button_craw.Enabled = true;
        }

        private async Task getLinks(String url)
        {
            await Task.Run(() =>
            {
                IStore store = (new StoreFactory()).GetStore(url);
                List<string> result = new List<string>();
                string domain = null;
                if (store != null)
                {
                    result = store.getLinkProducts(url);
                    domain = store.getDomain();

                }
                Task task = addLinkToES(result, domain);
            });


        }

        private async Task addLinkToES(List<string> list_url, string domain)
        {
            if (list_url.Count == 0) { return; }

            var listData = list_url.Select(u => new Data(u, domain));

            await eService.indexDatasAsync(listData);
            await Load_DataGridView();
        }

        private async Task<List<Data>> loadPageNumber(int numberPage)
        {
            int numberData = (pageNumber - 1) * 20;
            long counter = await eService.countIndex("test");

            var response = await eService.SearchDataFrom(numberData);

            if (!response.IsValid)
            {
                return null;

            }
            else
            {
                return response.Hits.Select(
            hit =>
            {
                hit.Source._id = hit.Id;
                return hit.Source;
            }).ToList();
            }
        }

        private void addData(Data data)
        {

            DataGridViewRow row = new DataGridViewRow();
            row.Cells[0].Value = data.url;
            if (data.status == 1)
            {
                row.Cells[1].Value = "Thành công";
                row.Cells[2].Value = $@"C:\demo\{data._id}.txt";
            }
            else if (data.status == 0)
            {
                row.Cells[1].Value = "Mới";
            }
            else if (data.status == 2)
            {
                row.Cells[1].Value = "Lỗi";

            }
            row.Cells[3].Value = data._id;
            dataGridView.Rows.Add(row);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                pageNumber++;
                await Load_DataGridView();
            });

        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                pageNumber--;
                await Load_DataGridView();
            });

        }

        private void getData()
        {
            /*var timer = new Timer(5000);
            timer.Elapsed += async (s, e) =>
            {

                if (!isLoadsLinks)
                {
                    await getDataAsync();
                    Load_DataGridView();
                }
            };

            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();*/
        }


        private async Task getDataAsync()
        {
            var data = await getLinkCraw(eService.Client);
            if (data != null)
            {
                ParallelLoopResult result = Parallel.ForEach(data, getData);
            }
        }

        private async Task<List<Data>> getLinkCraw(ElasticClient client)
        {
            var response = await client.SearchAsync<Data>(n => n
            .Index("test")
            .From(0)
            .MatchAll()
            .Sort((sd) =>
            {
                sd.Ascending(new Field("time_load"));
                return sd;
            })
            .Size(10)
            );

            if (!response.IsValid)
            {
                return null;
            }
            else
            {
                return response.Hits.Select(
                hit =>
                {
                    hit.Source._id = hit.Id;
                    return hit.Source;
                }).ToList();
            }
        }

        private void getData(Data data)
        {
            IStore store = (new StoreFactory()).GetStore(data.url);
            var _data = store.getData(data).Result;
            eService.updateData(_data);
        }

        private void seachLinksProduct_Click(object sender, EventArgs e)
        {
            FormSearch seach = new FormSearch();
            FormsControl.switchMainForm(this, seach);
        }

        private void products_Click(object sender, EventArgs e)
        {
            FormProducts products = new FormProducts();
            FormsControl.switchMainForm(this, products);
        }

        private void statisLinksProduct_Click(object sender, EventArgs e)
        {
            FormStatis statis = new FormStatis();
            FormsControl.switchMainForm(this,statis);
        }
    }
}