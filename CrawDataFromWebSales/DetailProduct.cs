using ESEngine;
using Model;
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
    public partial class DetailProduct : Form
    {
        EService eService;
        public DetailProduct()
        {
            InitializeComponent();
        }

        public DetailProduct(string id, string name, string price)
        {
            eService = new EService();
            InitializeComponent();
            label_nameproduct.Text = name;
            label_price.Text = "Price: " + price;
            DatagridViewAction.createView(dataGridView1);
            var item = eService.getData_idProductbyID(id);

            List<Model.Data> list_data = new List<Model.Data>();
            foreach(var i in item) {
                var data = eService.GetDataByID(i);
                list_data.AddRange(data);
            }
            DatagridViewAction.setData(list_data, dataGridView1);


        }

    }
}
