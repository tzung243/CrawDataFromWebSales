using ESEngine;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public partial class FormProducts : Form
    {
        EService eService;
        public FormProducts()
        {
            InitializeComponent();
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            eService = new EService();
        }
        private void search_Click(object sender, EventArgs e)
        {
            FormSearch search = new FormSearch();
            FormsControl.switchMainForm(this, search);
        }

        private void statisLinksProduct_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void linksProduct_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            FormsControl.switchMainForm(this, home);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string name = textBox_namePr.Text;

            string priceFromTo = textBox_PricePr.Text;
            double priceFrom = -1;
            double priceTo = -1;
            if (priceFromTo != string.Empty)
            {
                var price = priceFromTo.Split('-');
                priceFrom = Convert.ToDouble(price[0]);
                priceTo = Convert.ToDouble(price[1]);
            }

            string dateCreateFromTo = tb_timeCreatePR.Text;
            DateTime? createFrom = null;
            DateTime? createTo = null;
            if (dateCreateFromTo != string.Empty)
            {
                var dateCre = dateCreateFromTo.Split('-');
                createFrom = DateTime.ParseExact(dateCre[0], "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
                createTo = DateTime.ParseExact(dateCre[1], "yyyy-MM-dd", CultureInfo.DefaultThreadCurrentCulture);
            }

            string numberLinksFromTo = textBox_numberLinkPR.Text;
            int numberLinkFrom = -1;
            int numberLinkTo = -1;
            if (numberLinksFromTo != string.Empty)
            {
                var numberLinks = dateCreateFromTo.Split('-');
                numberLinkFrom = Convert.ToInt16(numberLinks[0]);
                numberLinkTo = Convert.ToInt16(numberLinks[1]);
            }

            var item = eService.getProduct(name, priceFrom, priceTo, createFrom, createTo, numberLinkFrom, numberLinkTo);
        }


    }
}
