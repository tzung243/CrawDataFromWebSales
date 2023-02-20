using Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public class DatagirdViewAction
    {
        public static void createView(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.ReadOnly = true;

            dataGridView.Columns.Add("id", "id");
            dataGridView.Columns[0].Visible = false;

            dataGridView.Columns.Add("url", "Link");
            dataGridView.Columns[1].Width = (int)(dataGridView.Width * 0.3);

            dataGridView.Columns.Add("state", "Trang thai");
            dataGridView.Columns[2].Width = (int)(dataGridView.Width * 0.2);

            dataGridView.Columns.Add("Name", "Name");
            dataGridView.Columns[3].Width = (int)(dataGridView.Width * 0.3);

            dataGridView.Columns.Add("Price", "Gia");
            dataGridView.Columns[4].Width = (int)(dataGridView.Width * 0.2);


        }

        public static void createViewStatis(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.ReadOnly = true;

            dataGridView.Columns.Add("type", "Type");
            dataGridView.Columns[0].Width = (int)(dataGridView.Width * 0.5);

            dataGridView.Columns.Add("Number", "So luong");
            dataGridView.Columns[1].Width = (int)(dataGridView.Width * 0.5);

        }

        public static void createViewProduct(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.ReadOnly = true;

            dgv.Columns.Add("id", "id");
            dgv.Columns[0].Visible = false;

            dgv.Columns.Add("name", "Name");
            dgv.Columns[1].Width = (int)(dgv.Width * 0.3);

            dgv.Columns.Add("price", "Gia");
            dgv.Columns[2].Width = (int)(dgv.Width * 0.2);

            dgv.Columns.Add("created_date", "Ngay tao");
            dgv.Columns[3].Width = (int)(dgv.Width * 0.3);

            dgv.Columns.Add("total_link", "So luong link");
            dgv.Columns[4].Width = (int)(dgv.Width * 0.2);
        }

        private static void addProduct(Product p, DataGridView dgv)
        {
            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(dgv);
            row.Cells[0].Value = p._id;
            row.Cells[1].Value = p.name;
            row.Cells[2].Value = p.price;
            row.Cells[3].Value = p.created;
            row.Cells[4].Value = p.totalLinks;
            dgv.Rows.Add(row);
        }

        public static void setProducts(List<Product> ps, DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.Rows.Clear();

            if (ps == null) { return; }


            foreach (var item in ps)
            {
                addProduct(item, dgv);
            }
        }

        private static void addData(Data data, DataGridView dataGridView)
        {

            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(dataGridView);
            row.Cells[0].Value = data._id;
            row.Cells[1].Value = data.url;
            if (data.status == 1)
            {
                row.Cells[2].Value = "Thành công";
            }
            else if (data.status == 0)
            {
                row.Cells[2].Value = "Mới";
            }
            else if (data.status == 2)
            {
                row.Cells[2].Value = "Lỗi";

            }
            row.Cells[3].Value = data.name;
            row.Cells[4].Value = data.price;
            dataGridView.Rows.Add(row);

        }

        public static void setData(List<Data> datas, DataGridView dataGridView)
        {

            dataGridView.ReadOnly = true;
            dataGridView.Rows.Clear();

            if (datas == null) { return; }


            foreach (Data item in datas)
            {
                addData(item, dataGridView);
            }
        }

        public static void setDataStatis(List<StatisProducts> data, DataGridView dataGrid)
        {

            dataGrid.Rows.Clear();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    addDataStatis(item, dataGrid);
                }
            }
        }
        public static void addDataStatis(StatisProducts data, DataGridView dataGrid)
        {
            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(dataGrid);
            row.Cells[0].Value = data.Key;
            row.Cells[1].Value = data.count;
            dataGrid.Rows.Add(row);
        }
    }
}