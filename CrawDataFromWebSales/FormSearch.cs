using ESEngine;
using System;
using System.Globalization;
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
            //TODO
        }

        private void products_Click(object sender, EventArgs e)
        {
            FormProducts products = new FormProducts();
            FormsControl.switchMainForm(this, products);
        }

        private async void button_search_Click(object sender, EventArgs e)
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

            if (item.Count > 0)
            {
                button_createPr.Show();
            }
        }


    }
}
