namespace CrawDataFromWebSales
{
    partial class FormProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linksProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.button_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statisLinksProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_numberLinkPR = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_namePr = new System.Windows.Forms.TextBox();
            this.time_create = new System.Windows.Forms.Label();
            this.time_update = new System.Windows.Forms.Label();
            this.textBox_PricePr = new System.Windows.Forms.TextBox();
            this.tb_timeCreatePR = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linksProduct
            // 
            this.linksProduct.Name = "linksProduct";
            this.linksProduct.Size = new System.Drawing.Size(99, 36);
            this.linksProduct.Text = "Home";
            this.linksProduct.Click += new System.EventHandler(this.linksProduct_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(1194, 96);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(113, 39);
            this.button_search.TabIndex = 23;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1366, 723);
            this.dataGridView1.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linksProduct,
            this.statisLinksProduct,
            this.search});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1478, 40);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statisLinksProduct
            // 
            this.statisLinksProduct.Name = "statisLinksProduct";
            this.statisLinksProduct.Size = new System.Drawing.Size(90, 36);
            this.statisLinksProduct.Text = "Statis";
            this.statisLinksProduct.Click += new System.EventHandler(this.statisLinksProduct_Click);
            // 
            // search
            // 
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(105, 36);
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // textBox_numberLinkPR
            // 
            this.textBox_numberLinkPR.Location = new System.Drawing.Point(841, 107);
            this.textBox_numberLinkPR.Name = "textBox_numberLinkPR";
            this.textBox_numberLinkPR.Size = new System.Drawing.Size(316, 31);
            this.textBox_numberLinkPR.TabIndex = 32;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(101, 107);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(62, 29);
            this.label_status.TabIndex = 29;
            this.label_status.Text = "Gia :";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(101, 57);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(156, 26);
            this.label_name.TabIndex = 28;
            this.label_name.Text = "Ten san pham:";
            // 
            // textBox_namePr
            // 
            this.textBox_namePr.Location = new System.Drawing.Point(263, 54);
            this.textBox_namePr.Name = "textBox_namePr";
            this.textBox_namePr.Size = new System.Drawing.Size(349, 31);
            this.textBox_namePr.TabIndex = 27;
            // 
            // time_create
            // 
            this.time_create.AutoSize = true;
            this.time_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_create.Location = new System.Drawing.Point(677, 111);
            this.time_create.Name = "time_create";
            this.time_create.Size = new System.Drawing.Size(158, 29);
            this.time_create.TabIndex = 34;
            this.time_create.Text = "So luong link:";
            // 
            // time_update
            // 
            this.time_update.AutoSize = true;
            this.time_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_update.Location = new System.Drawing.Point(677, 57);
            this.time_update.Name = "time_update";
            this.time_update.Size = new System.Drawing.Size(114, 29);
            this.time_update.TabIndex = 33;
            this.time_update.Text = "Ngay tao:";
            // 
            // textBox_PricePr
            // 
            this.textBox_PricePr.Location = new System.Drawing.Point(263, 114);
            this.textBox_PricePr.Name = "textBox_PricePr";
            this.textBox_PricePr.Size = new System.Drawing.Size(349, 31);
            this.textBox_PricePr.TabIndex = 35;
            // 
            // tb_timeCreatePR
            // 
            this.tb_timeCreatePR.Location = new System.Drawing.Point(839, 55);
            this.tb_timeCreatePR.Name = "tb_timeCreatePR";
            this.tb_timeCreatePR.Size = new System.Drawing.Size(318, 31);
            this.tb_timeCreatePR.TabIndex = 36;
            // 
            // FormProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 924);
            this.Controls.Add(this.tb_timeCreatePR);
            this.Controls.Add(this.textBox_PricePr);
            this.Controls.Add(this.time_create);
            this.Controls.Add(this.time_update);
            this.Controls.Add(this.textBox_numberLinkPR);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox_namePr);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormProducts";
            this.Text = "FormProducts";
            this.Load += new System.EventHandler(this.FormProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem linksProduct;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem statisLinksProduct;
        private System.Windows.Forms.ToolStripMenuItem search;
        private System.Windows.Forms.TextBox textBox_numberLinkPR;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_namePr;
        private System.Windows.Forms.Label time_create;
        private System.Windows.Forms.Label time_update;
        private System.Windows.Forms.TextBox textBox_PricePr;
        private System.Windows.Forms.TextBox tb_timeCreatePR;
    }
}