using ESEngine;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public partial class FormSearch : Form
    {
        EService eService;
        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            eService = new EService();
            DatagirdViewAction.createView(dataGridView1);
        }
        private void linksProduct_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            FormsControl.switchMainForm(this, home);
        }

        private void statisLinksProduct_Click(object sender, EventArgs e)
        {
            FormStatis statis = new FormStatis();
            FormsControl.switchMainForm(this, statis);
        }

        private void products_Click(object sender, EventArgs e)
        {
            FormProducts products = new FormProducts();
            FormsControl.switchMainForm(this, products);
        }

        private async void button_search_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    string name = textBox1.Text;

                    string status_text = comboBox_status.Text;
                    int status = -1;
                    switch (status_text)
                    {
                        case "Moi":
                            status = 0;
                            break;
                        case "Thanh cong":
                            status = 1;
                            break;
                        case "Loi":
                            status = 2;
                            break;
                    }

                    string domain = comboBox_domain.Text;

                    string priceFromTo = textBox_price.Text;
                    double priceFrom = -1;
                    double priceTo = -1;
                    if (priceFromTo != string.Empty)
                    {
                        var price = priceFromTo.Split('-');
                        priceFrom = Convert.ToDouble(price[0]);
                        priceTo = Convert.ToDouble(price[1]);
                    }

                    string dateUpdateFromTo = tb_timeUpdate.Text;
                    DateTime? updateFrom = null;
                    DateTime? updateTo = null;
                    if (dateUpdateFromTo != string.Empty)
                    {
                        var dateUp = dateUpdateFromTo.Split('-');
                        updateFrom = DateTime.ParseExact(dateUp[0], "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
                        updateTo = DateTime.ParseExact(dateUp[1], "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
                    }

                    string dateCreateFromTo = tb_timeUpdate.Text;
                    DateTime? createFrom = null;
                    DateTime? createTo = null;
                    if (dateCreateFromTo != string.Empty)
                    {
                        var dateCre = dateCreateFromTo.Split('-');
                        createFrom = DateTime.ParseExact(dateCre[0], "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
                        createTo = DateTime.ParseExact(dateCre[1], "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
                    }

                    var item = eService.getLinksProduct(name, status, domain, priceFrom, priceTo, updateFrom, updateTo, createFrom, createTo, this.checkBox1.Checked);

                    DatagirdViewAction.setData(item, dataGridView1);
                }));
            });

        }

        private void button_createPr_Click(object sender, EventArgs e)
        {
          
                List<DataGridViewRow> rows = new List<DataGridViewRow>();


                List<Data> result = new List<Data>();
                var selectedRows = dataGridView1.SelectedRows;

                foreach (DataGridViewRow s in dataGridView1.SelectedRows)
                {
                  
                    var data = new Data()
                    {
                        _id = s.Cells[0].Value.ToString(),
                        url = s.Cells[1].Value.ToString(),
                        //status = int.Parse(s.Cells[2].Value.ToString()),
                        name = s.Cells[3].Value.ToString(),
                        price = double.Parse(s.Cells[4].Value.ToString())
                    };
                    result.Add(data);

                }
                var createForm = new FormCreateProduct(result);
                createForm.ShowDialog();


                // get selected rows

                /*         dataGridView1.Invoke((MethodInvoker)(() =>
                         {
                             *//*var selectedRows = dataGridView1.SelectedRows;
                             for (int i = 0; i < selectedRows.Count; i++)
                             {
                                 rows.Add(selectedRows[i]);
                             }*//*
                             List<Data> result = new List<Data>();
                             var selectedRows = dataGridView1.SelectedRows;

                             foreach (DataGridViewRow s in selectedRows)
                             {
                                 var i = s.Cells[0].Value.ToString();
                                 var data = new Data()
                                 {
                                     _id = s.Cells[0].Value.ToString(),
                                     url = s.Cells[1].Value.ToString(),
                                     //status = int.Parse(s.Cells[2].Value.ToString()),
                                     name = s.Cells[3].Value.ToString(),
                                     price = double.Parse(s.Cells[4].Value.ToString())
                                 };
                                 result.Add(data);

                             }
                             var createForm = new FormCreateProduct(result);
                             createForm.ShowDialog();

                         }));*/

                /*  if (rows.Count == 0) return;
  */


                /*var datas = rows.Select(s => new Data()
                {
                    _id = s.Cells[0].Value.ToString(),
                    url = s.Cells[1].Value.ToString(),
                    status = int.Parse(s.Cells[2].Value.ToString()),
                    name = s.Cells[3].Value.ToString(),
                    price = double.Parse(s.Cells[4].Value.ToString())
                });*/
                /* var createForm = new FormCreateProduct(result);
                 createForm.ShowDialog();*/





        }
    }
}