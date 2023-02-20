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
            dataGridView.CellMouseDown += dataGridView1_CellMouseDown;
            LoadContextMenuStrip();
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            eService = new EService();
            DatagridViewAction.createViewProduct(dataGridView);
        }
        private void search_Click(object sender, EventArgs e)
        {
            FormSearch search = new FormSearch();
            FormsControl.switchMainForm(this, search);
        }

        private void statisLinksProduct_Click(object sender, EventArgs e)
        {
            FormStatis statis = new FormStatis();
            FormsControl.switchMainForm(this, statis);
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

            var items = eService.getProduct(name, priceFrom, priceTo, createFrom, createTo, numberLinkFrom, numberLinkTo);
            DatagridViewAction.setProducts(items, dataGridView);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;


            if (e.Button == MouseButtons.Right)
            {
                dataGridView.ClearSelection();

                DataGridViewCell cell = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                cell.Selected = true;
                dataGridView.CurrentCell = cell;
            }
        }

        private void LoadContextMenuStrip()
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Sửa sản phẩm");
            cms.Items.Add("Xoá");

            cms.ItemClicked += contexMenu_ItemClicked;
            cms.Opening += Cms_Opening;

            dataGridView.ContextMenuStrip = cms;
        }

        private void Cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cms = sender as ContextMenuStrip;
            var mousepos = Control.MousePosition;
            if (cms != null)
            {
                var rel_mousePos = cms.PointToClient(mousepos);
                if (cms.ClientRectangle.Contains(rel_mousePos))
                {
                    //the mouse pos is on the menu ... 
                    //looks like the mouse was used to open it
                    var dataGridView1_rel_mousePos = dataGridView.PointToClient(mousepos);
                    var hti = dataGridView.HitTest(dataGridView1_rel_mousePos.X, dataGridView1_rel_mousePos.Y);
                    if (hti.RowIndex == -1)
                    {
                        // no row ...
                        e.Cancel = true;
                    }
                }
                else
                {
                    //looks like the menu was opened without the mouse ...
                    //we could cancel the menu, or perhaps use the currently selected cell as reference...
                    e.Cancel = true;
                }
            }
        }

        private async void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ToolStripItem item = e.ClickedItem;

            if (dataGridView.SelectedCells.Count > 0)
            {
                var cell = dataGridView.SelectedCells[0];
                var row = dataGridView.Rows[cell.RowIndex];

                string actionType = item.Text;
                if (actionType.Equals("Sửa sản phẩm"))
                {
                    var urlCell = row.Cells[0];
                    //dataGridView.CurrentCell = urlCell;

                    // TODO


                    return;
                }
                else if (actionType.Equals("Xoá"))
                {
                    await eService.deletedProduct(row.Cells[0].Value.ToString());

                    dataGridView.Rows.Remove(row);
                }
            }

            dataGridView.CurrentCell = null;
            dataGridView.ClearSelection();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string nameProduct = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            string priceProduct = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

            DetailProduct detail = new DetailProduct(id, nameProduct, priceProduct); 
            detail.ShowDialog();
            




            

        }
    }
}