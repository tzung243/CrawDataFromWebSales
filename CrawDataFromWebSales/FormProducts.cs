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
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
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
    }
}
