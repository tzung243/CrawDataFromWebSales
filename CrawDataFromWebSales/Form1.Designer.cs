using System;

namespace CrawDataFromWebSales
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_url = new System.Windows.Forms.TextBox();
            this.button_craw = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button_next = new System.Windows.Forms.Button();
            this.button_prev = new System.Windows.Forms.Button();
            this.page_number = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.seachLinksProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.statisLinksProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.products = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL can quet";
            // 
            // textbox_url
            // 
            this.textbox_url.Location = new System.Drawing.Point(326, 58);
            this.textbox_url.Name = "textbox_url";
            this.textbox_url.Size = new System.Drawing.Size(790, 31);
            this.textbox_url.TabIndex = 2;
            // 
            // button_craw
            // 
            this.button_craw.Location = new System.Drawing.Point(1236, 52);
            this.button_craw.Name = "button_craw";
            this.button_craw.Size = new System.Drawing.Size(159, 48);
            this.button_craw.TabIndex = 4;
            this.button_craw.Text = "Quet link";
            this.button_craw.UseVisualStyleBackColor = true;
            this.button_craw.Click += new System.EventHandler(this.button_craw_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.Location = new System.Drawing.Point(61, 129);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 82;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.Size = new System.Drawing.Size(1334, 656);
            this.dataGridView.TabIndex = 6;
            // 
            // button_next
            // 
            this.button_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_next.Location = new System.Drawing.Point(1339, 806);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(56, 44);
            this.button_next.TabIndex = 8;
            this.button_next.Text = ">";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_prev
            // 
            this.button_prev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_prev.Location = new System.Drawing.Point(1224, 806);
            this.button_prev.Name = "button_prev";
            this.button_prev.Size = new System.Drawing.Size(56, 44);
            this.button_prev.TabIndex = 9;
            this.button_prev.Text = "<";
            this.button_prev.UseVisualStyleBackColor = true;
            this.button_prev.Click += new System.EventHandler(this.button_prev_Click);
            // 
            // page_number
            // 
            this.page_number.AutoSize = true;
            this.page_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.page_number.Location = new System.Drawing.Point(1295, 813);
            this.page_number.Name = "page_number";
            this.page_number.Size = new System.Drawing.Size(29, 31);
            this.page_number.TabIndex = 10;
            this.page_number.Text = "1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachLinksProduct,
            this.statisLinksProduct,
            this.products});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1478, 42);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // seachLinksProduct
            // 
            this.seachLinksProduct.Name = "seachLinksProduct";
            this.seachLinksProduct.Size = new System.Drawing.Size(105, 38);
            this.seachLinksProduct.Text = "Search";
            this.seachLinksProduct.Click += new System.EventHandler(this.seachLinksProduct_Click);
            // 
            // statisLinksProduct
            // 
            this.statisLinksProduct.Name = "statisLinksProduct";
            this.statisLinksProduct.Size = new System.Drawing.Size(90, 38);
            this.statisLinksProduct.Text = "Statis";
            this.statisLinksProduct.Click += new System.EventHandler(this.statisLinksProduct_Click);
            // 
            // products
            // 
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(126, 38);
            this.products.Text = "Products";
            this.products.Click += new System.EventHandler(this.products_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 924);
            this.Controls.Add(this.page_number);
            this.Controls.Add(this.button_prev);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button_craw);
            this.Controls.Add(this.textbox_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_url;
        private System.Windows.Forms.Button button_craw;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.Label page_number;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seachLinksProduct;
        private System.Windows.Forms.ToolStripMenuItem statisLinksProduct;
        private System.Windows.Forms.ToolStripMenuItem products;
    }
}

