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
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_url = new System.Windows.Forms.TextBox();
            this.textbox_search = new System.Windows.Forms.TextBox();
            this.button_craw = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button_next = new System.Windows.Forms.Button();
            this.button_prev = new System.Windows.Forms.Button();
            this.page_number = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Noi dung can tim";
            // 
            // textbox_url
            // 
            this.textbox_url.Location = new System.Drawing.Point(326, 58);
            this.textbox_url.Name = "textbox_url";
            this.textbox_url.Size = new System.Drawing.Size(790, 31);
            this.textbox_url.TabIndex = 2;
            // 
            // textbox_search
            // 
            this.textbox_search.Location = new System.Drawing.Point(326, 112);
            this.textbox_search.Name = "textbox_search";
            this.textbox_search.Size = new System.Drawing.Size(790, 31);
            this.textbox_search.TabIndex = 3;
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
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(1236, 106);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(159, 48);
            this.button_search.TabIndex = 5;
            this.button_search.Text = "Tim kiem";
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.Location = new System.Drawing.Point(61, 160);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 82;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.Size = new System.Drawing.Size(1334, 625);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 924);
            this.Controls.Add(this.page_number);
            this.Controls.Add(this.button_prev);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_craw);
            this.Controls.Add(this.textbox_search);
            this.Controls.Add(this.textbox_url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_url;
        private System.Windows.Forms.TextBox textbox_search;
        private System.Windows.Forms.Button button_craw;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.Label page_number;
    }
}

