using Model;
using System.Collections.Generic;
using System.Linq;
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

            dataGridView.Columns.Add("url", "Link");
            dataGridView.Columns[0].Width = (int)(dataGridView.Width * 0.3);

            dataGridView.Columns.Add("state", "Trang thai");
            dataGridView.Columns[1].Width = (int)(dataGridView.Width * 0.2);

            dataGridView.Columns.Add("Name", "Name");
            dataGridView.Columns[2].Width = (int)(dataGridView.Width * 0.3);

            dataGridView.Columns.Add("Price", "Gia");
            dataGridView.Columns[3].Width = (int)(dataGridView.Width * 0.2);


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

        private static void addData(Data data, DataGridView dataGridView)
        {

            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(dataGridView);
            row.Cells[0].Value = data.url;
            if (data.status == 1)
            {
                row.Cells[1].Value = "Thành công";
            }
            else if (data.status == 0)
            {
                row.Cells[1].Value = "Mới";
            }
            else if (data.status == 2)
            {
                row.Cells[1].Value = "Lỗi";

            }
            row.Cells[2].Value = data.name;
            row.Cells[3].Value = data.price;
            dataGridView.Rows.Add(row);

        }

        public static void setData(List<Data> data, DataGridView dataGridView)
        {

            dataGridView.ReadOnly = true;
            dataGridView.Rows.Clear();

            if (data == null) { return; }

            var List = data.ToList();
            if (List == null)
                return;
            foreach (Data item in List)
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