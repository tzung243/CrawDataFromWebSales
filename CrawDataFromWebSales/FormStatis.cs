using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public partial class FormStatis : Form
    {
        EServicce eServicce;
        public FormStatis()
        {
            InitializeComponent();
        }

        private void FormStatis_Load(object sender, EventArgs e)
        {
            eServicce = new EServicce();
            DatagirdViewAction.createViewStatis(dataGridView1);
        }

        private void domainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = eServicce.statisDomain();
            DatagirdViewAction.setDataStatis(item, dataGridView1);
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = eServicce.statisStatus();
            List<StatisProducts> list = new List<StatisProducts>();

            foreach (StatisProducts i in item)
            {
                if (i.Key == "0")
                {
                    list.Add(new StatisProducts { Key = "Moi", count = i.count });
                }
                if (i.Key == "1")
                {
                    list.Add(new StatisProducts { Key = "Thanh cong", count = i.count });
                }

                if (i.Key == "2")
                {
                    list.Add(new StatisProducts { Key = "Loi", count = i.count });
                }
            }
           
            DatagirdViewAction.setDataStatis(list, dataGridView1);
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //TODO
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            FormsControl.switchMainForm(this, home);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch search = new FormSearch();
            FormsControl.switchMainForm(this, search);
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormProducts products = new FormProducts();
            FormsControl.switchMainForm(this, products);
        }
    }
}
