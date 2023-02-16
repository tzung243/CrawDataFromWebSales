using Elasticsearch.Net.Specification.MachineLearningApi;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Timer = System.Timers.Timer;


namespace CrawDataFromWebSales
{
    public partial class Form1 : Form
    {
        ElasticClient client;
        int pageNumber = 1;
        private bool isLoadsLinks;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new ElasticClient("craw_data:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvOjQ0MyQ3OGU2Y2Q2OWIwYWQ0NTczYWMwNDNkYThmNDdlZTE0ZiQ4YTM0NTJlMDBlYzU0NzE1YTA1MmQ1MDdjMWRlMDk4NA==",
              new Elasticsearch.Net.ApiKeyAuthenticationCredentials("T3R1c1NJWUJKdUNELWYxb2lhTUM6aWJ5TjNDcmVTYjJpT1BKTFlvUTlFZw=="));

            isLoadsLinks = false;
            DatagirdViewAction.createView(dataGridView);
            await Load_DataGridView();
            getData();
        }


        private async Task Load_DataGridView()
        {
            CountRequest countReq = new CountRequest("data-index");
            long counter = (await client.CountAsync(countReq)).Count;
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
                DatagirdViewAction.setData(list, dataGridView);

            }));
        }

        private async void button_craw_Click(object sender, EventArgs e)
        {
            isLoadsLinks= true;
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
                Task task = addLinkToES(result,domain);
            });

            isLoadsLinks = false;
            
        }

        private async Task addLinkToES(List<string> list_url, string _domain)
        {
            if (list_url.Count == 0) { return; }
            foreach (var item in list_url)
            {
                Data data = new Data()
                {
                    url = item,
                    status = 0,
                    time_create = DateTime.Now,
                    domain = _domain,
                    time_load = DateTime.Now
                };

                var response = client.Index(data, request => request.Index("data-index"));
            }
            await Load_DataGridView();
        }

        private async Task<List<Data>> loadPageNumber(int numberPage)
        {

            CountRequest countReq = new CountRequest("data-index");

            int numberData = (pageNumber - 1) * 20;
            long counter = client.Count(countReq).Count;


            Nest.ISearchResponse<Data> response;

            response = await client.SearchAsync<Data>(n => n
            .Index("data-index")
            .Query(q => q
                .MatchAll()
                )
            .Sort((sd) =>
            {
                sd.Descending(new Field("time_load"));
                return sd;
            })
            .From(pageNumber)
            .Size(20)
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
            var timer = new Timer(5000);
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
            timer.Start();
        }

        private async Task getDataAsync()
        {
            var data = await getLinkCraw(client);
            if (data != null)
            {
                ParallelLoopResult result = Parallel.ForEach(data, getData);
            }
        }

        private async Task<List<Data>> getLinkCraw(ElasticClient client)
        {
            var response = await client.SearchAsync<Data>(n => n
            .Index("data-index")
            .From(0)
            .Query(q => q
                .Match(m => m.Field("status").Query("2")))
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

        private async void getData(Data data)
        {
            IStore store = (new StoreFactory()).GetStore(data.url);
            var _data = store.getData(data).Result;
            updateData(_data);
        }

        private void updateData(Data data)
        {
            var response = client.Update<Data, object>(data._id, (ud) =>
            {
               
                ud.Doc(new Data
                {
                    url = data.url,
                    name = data.name,
                    price= data.price,
                    description = data.description,
                    time_load = data.time_load,
                    status = data.status
                }).Index("data-index");
                return ud;
            });
        }

    }
}
