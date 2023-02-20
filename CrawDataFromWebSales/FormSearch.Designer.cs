namespace CrawDataFromWebSales
{
    partial class FormSearch
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.linksProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.statisLinksProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.products = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_search = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.domain = new System.Windows.Forms.Label();
            this.label_price = new System.Windows.Forms.Label();
            this.time_update = new System.Windows.Forms.Label();
            this.time_create = new System.Windows.Forms.Label();
            this.comboBox_domain = new System.Windows.Forms.ComboBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.tb_timeUpdate = new System.Windows.Forms.TextBox();
            this.tb_timeCreate = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_createPr = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linksProduct,
            this.statisLinksProduct,
            this.products});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1478, 40);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // linksProduct
            // 
            this.linksProduct.Name = "linksProduct";
            this.linksProduct.Size = new System.Drawing.Size(99, 36);
            this.linksProduct.Text = "Home";
            this.linksProduct.Click += new System.EventHandler(this.linksProduct_Click);
            // 
            // statisLinksProduct
            // 
            this.statisLinksProduct.Name = "statisLinksProduct";
            this.statisLinksProduct.Size = new System.Drawing.Size(90, 36);
            this.statisLinksProduct.Text = "Statis";
            this.statisLinksProduct.Click += new System.EventHandler(this.statisLinksProduct_Click);
            // 
            // products
            // 
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(126, 36);
            this.products.Text = "Products";
            this.products.Click += new System.EventHandler(this.products_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 31);
            this.textBox1.TabIndex = 13;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(51, 48);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(156, 26);
            this.label_name.TabIndex = 14;
            this.label_name.Text = "Ten san pham:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1353, 636);
            this.dataGridView1.TabIndex = 16;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(1264, 98);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(113, 39);
            this.button_search.TabIndex = 17;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(51, 98);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(127, 29);
            this.label_status.TabIndex = 18;
            this.label_status.Text = "Trang thai:";
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "Moi",
            "Thanh cong",
            "Loi"});
            this.comboBox_status.Location = new System.Drawing.Point(213, 98);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(212, 33);
            this.comboBox_status.TabIndex = 19;
            // 
            // domain
            // 
            this.domain.AutoSize = true;
            this.domain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domain.Location = new System.Drawing.Point(434, 48);
            this.domain.Name = "domain";
            this.domain.Size = new System.Drawing.Size(102, 29);
            this.domain.TabIndex = 20;
            this.domain.Text = "Domain:";
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_price.Location = new System.Drawing.Point(434, 101);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(56, 29);
            this.label_price.TabIndex = 21;
            this.label_price.Text = "Gia:";
            // 
            // time_update
            // 
            this.time_update.AutoSize = true;
            this.time_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_update.Location = new System.Drawing.Point(780, 50);
            this.time_update.Name = "time_update";
            this.time_update.Size = new System.Drawing.Size(171, 29);
            this.time_update.TabIndex = 22;
            this.time_update.Text = "Ngay cap nhat:";
            // 
            // time_create
            // 
            this.time_create.AutoSize = true;
            this.time_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_create.Location = new System.Drawing.Point(780, 104);
            this.time_create.Name = "time_create";
            this.time_create.Size = new System.Drawing.Size(114, 29);
            this.time_create.TabIndex = 23;
            this.time_create.Text = "Ngay tao:";
            // 
            // comboBox_domain
            // 
            this.comboBox_domain.FormattingEnabled = true;
            this.comboBox_domain.Items.AddRange(new object[] {
            "mediamart.vn",
            "hc.com.vn",
            "www.dienmayxanh.com",
            "dienmaycholon.vn",
            "www.nguyenkim.com"});
            this.comboBox_domain.Location = new System.Drawing.Point(542, 45);
            this.comboBox_domain.Name = "comboBox_domain";
            this.comboBox_domain.Size = new System.Drawing.Size(232, 33);
            this.comboBox_domain.TabIndex = 25;
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(542, 98);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(232, 31);
            this.textBox_price.TabIndex = 26;
            // 
            // tb_timeUpdate
            // 
            this.tb_timeUpdate.Location = new System.Drawing.Point(957, 45);
            this.tb_timeUpdate.Name = "tb_timeUpdate";
            this.tb_timeUpdate.Size = new System.Drawing.Size(232, 31);
            this.tb_timeUpdate.TabIndex = 27;
            // 
            // tb_timeCreate
            // 
            this.tb_timeCreate.Location = new System.Drawing.Point(957, 104);
            this.tb_timeCreate.Name = "tb_timeCreate";
            this.tb_timeCreate.Size = new System.Drawing.Size(232, 31);
            this.tb_timeCreate.TabIndex = 28;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1232, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(190, 29);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Have product ?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button_createPr
            // 
            this.button_createPr.Location = new System.Drawing.Point(1199, 822);
            this.button_createPr.Name = "button_createPr";
            this.button_createPr.Size = new System.Drawing.Size(210, 41);
            this.button_createPr.TabIndex = 30;
            this.button_createPr.Text = "Tao san pham";
            this.button_createPr.UseVisualStyleBackColor = true;
            this.button_createPr.Hide();
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 924);
            this.Controls.Add(this.button_createPr);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tb_timeCreate);
            this.Controls.Add(this.tb_timeUpdate);
            this.Controls.Add(this.textBox_price);
            this.Controls.Add(this.comboBox_domain);
            this.Controls.Add(this.time_create);
            this.Controls.Add(this.time_update);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.domain);
            this.Controls.Add(this.comboBox_status);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linksProduct;
        private System.Windows.Forms.ToolStripMenuItem statisLinksProduct;
        private System.Windows.Forms.ToolStripMenuItem products;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Label domain;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.Label time_update;
        private System.Windows.Forms.Label time_create;
        private System.Windows.Forms.ComboBox comboBox_domain;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.TextBox tb_timeUpdate;
        private System.Windows.Forms.TextBox tb_timeCreate;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_createPr;
    }
}