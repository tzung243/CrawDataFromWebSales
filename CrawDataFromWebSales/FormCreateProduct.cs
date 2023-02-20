using ESEngine;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public partial class FormCreateProduct : Form
    {
        EService eService;
        List<Data> datas;
        public FormCreateProduct(List<Data> datas)
        {
            InitializeComponent();
            this.datas = datas;
            eService = new EService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)(async () =>
                {
                    var minPrice = datas.Min(s => s.price);
                    var ids = datas.Select(s => s._id).ToList();

                    var product = new Product()
                    {
                        name = nameBox.Text,
                        model = modelBox.Text,
                        branch = branchBox.Text,
                        description = desBox.Text,
                        price = minPrice,
                        totalLinks = ids.Count(),
                        data_id = ids.ToList(),
                        created = DateTime.Now
                    };



                    await eService.createProduct(product);
                    this.Close();
                }));
                
            });
            
        }
    }
}
