﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nest;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Linq;

namespace CrawDataFromWebSales
{
    public partial class Form1 : Form
    {
        ElasticClient client;
        int pageNumber = 1;
        //private bool isLoadsLinks;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new ElasticClient("craw_data:dXMtY2VudHJhbDEuZ2NwLmNsb3VkLmVzLmlvOjQ0MyQ3OGU2Y2Q2OWIwYWQ0NTczYWMwNDNkYThmNDdlZTE0ZiQ4YTM0NTJlMDBlYzU0NzE1YTA1MmQ1MDdjMWRlMDk4NA==",
              new Elasticsearch.Net.ApiKeyAuthenticationCredentials("T3R1c1NJWUJKdUNELWYxb2lhTUM6aWJ5TjNDcmVTYjJpT1BKTFlvUTlFZw=="));
            
            //isLoadsLinks = false;
            DatagirdViewAction.createView(dataGridView);
            await Load_DataGridView();
        }


        private async Task Load_DataGridView()
        {
            CountRequest countReq = new CountRequest("data-index");
            long counter = client.Count(countReq).Count;
            int pageTail;
            if (counter % 50 == 0)
            {
                pageTail = (int)counter / 50;
            }
            else
            {
                pageTail = (int)counter / 50 + 1;
            }

            this.Invoke(new Action(async () =>
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

        private void button_craw_Click(object sender, EventArgs e)
        {
            //isLoadsLinks= true;
            string url = textbox_url.Text;
            getLinks(url);
        }

        private void getLinks(String url)
        {
            var result = new List<string>();
            if (WebDienMayXanh.Instance.isStore(url))
            {
                result = WebDienMayXanh.Instance.getLinkProducts(url);
            }
            if (WebNguyenKim.Instance.isStore(url))
            {
                result = WebNguyenKim.Instance.getLinkProducts(url);
            }
            if (WebDienMayChoLon.Instance.isStore(url))
            {
                result = WebDienMayChoLon.Instance.getLinkProducts(url);
            }
            if (WebMediaMart.Instance.isStore(url))
            {
                result = WebMediaMart.Instance.getLinkProducts(url);
            }

            addLinkToES(result);
            
        }

        private async void addLinkToES(List<string> list_url)
        {
            foreach (var item in list_url)
            {
                Data data = new Data()
                {
                    url = item,
                    status = 0,
                    time = DateTime.Now
                };

                var response = client.Index(data, request => request.Index("data-index"));
                await Load_DataGridView();
            }
        }
       
        private async Task<List<Data>> loadPageNumber(int numberPage)
        {

            CountRequest countReq = new CountRequest("data-index");
           
            int numberData = (pageNumber - 1) * 50;
            long counter = client.Count(countReq).Count;


            Nest.ISearchResponse<Data> response;
            
                response = await client.SearchAsync<Data>(n => n
                .Index("data-index")
                .Query(q => q
                    .MatchAll()
                    )
                .Sort((sd) =>
                {
                    sd.Descending(new Field("time"));
                    return sd;
                })
                .From(pageNumber)
                .Size(50)
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
            pageNumber++;
            Load_DataGridView();

        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            pageNumber--;
            Load_DataGridView();
        }
    }
}
