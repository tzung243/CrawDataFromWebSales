using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dataGridView.Columns[1].Width = (int)(dataGridView.Width * 0.3);

            dataGridView.Columns.Add("path", "Path");
            dataGridView.Columns[2].Width = (int)(dataGridView.Width * 0.4);

            dataGridView.Columns.Add("id", String.Empty);
            dataGridView.Columns[3].Visible = false;


        }

        private static void addData(Data data, DataGridView dataGridView)
        {

            DataGridViewRow row = new DataGridViewRow();

            row.CreateCells(dataGridView);
            row.Cells[0].Value = data.url;
            if (data.status == 1)
            {
                row.Cells[1].Value = "Thành công";
                row.Cells[2].Value = $@"C:\demo\{data._id}.txt";
            }
            else if (data.status == 0)
            {
                row.Cells[1].Value = "Mới";
            }
            else if (data.status == 2)
            {
                row.Cells[1].Value = "Lỗi";

            }
            row.Cells[3].Value = data._id;
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
    }
}
