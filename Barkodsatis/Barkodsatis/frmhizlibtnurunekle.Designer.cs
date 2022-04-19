
namespace Barkodsatis
{
    partial class frmhizlibtnurunekle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmhizlibtnurunekle));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblbutonid = new System.Windows.Forms.Label();
            this.chtumu = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txturunara = new System.Windows.Forms.TextBox();
            this.gridurunler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridurunler)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblbutonid);
            this.splitContainer1.Panel1.Controls.Add(this.chtumu);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txturunara);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridurunler);
            this.splitContainer1.Size = new System.Drawing.Size(1276, 777);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblbutonid
            // 
            this.lblbutonid.AutoSize = true;
            this.lblbutonid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblbutonid.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblbutonid.Location = new System.Drawing.Point(576, 21);
            this.lblbutonid.Name = "lblbutonid";
            this.lblbutonid.Size = new System.Drawing.Size(101, 28);
            this.lblbutonid.TabIndex = 12;
            this.lblbutonid.Text = "Buton No ";
            this.lblbutonid.Visible = false;
            // 
            // chtumu
            // 
            this.chtumu.AutoSize = true;
            this.chtumu.Location = new System.Drawing.Point(422, 74);
            this.chtumu.Name = "chtumu";
            this.chtumu.Size = new System.Drawing.Size(129, 21);
            this.chtumu.TabIndex = 10;
            this.chtumu.Text = "Tümünü Göster";
            this.chtumu.UseVisualStyleBackColor = true;
            this.chtumu.CheckedChanged += new System.EventHandler(this.chtumu_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 28);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ürün Ara";
            // 
            // txturunara
            // 
            this.txturunara.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txturunara.Location = new System.Drawing.Point(12, 62);
            this.txturunara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txturunara.Name = "txturunara";
            this.txturunara.Size = new System.Drawing.Size(389, 34);
            this.txturunara.TabIndex = 8;
            this.txturunara.TextChanged += new System.EventHandler(this.txturunara_TextChanged);
            // 
            // gridurunler
            // 
            this.gridurunler.AllowUserToAddRows = false;
            this.gridurunler.AllowUserToDeleteRows = false;
            this.gridurunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridurunler.BackgroundColor = System.Drawing.Color.White;
            this.gridurunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridurunler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridurunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridurunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridurunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridurunler.EnableHeadersVisualStyles = false;
            this.gridurunler.Location = new System.Drawing.Point(0, 0);
            this.gridurunler.Margin = new System.Windows.Forms.Padding(1);
            this.gridurunler.Name = "gridurunler";
            this.gridurunler.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridurunler.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridurunler.RowHeadersVisible = false;
            this.gridurunler.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.gridurunler.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridurunler.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.gridurunler.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridurunler.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridurunler.RowTemplate.Height = 32;
            this.gridurunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridurunler.Size = new System.Drawing.Size(1276, 673);
            this.gridurunler.TabIndex = 2;
            this.gridurunler.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridurunler_CellContentDoubleClick);
            // 
            // frmhizlibtnurunekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 777);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmhizlibtnurunekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hızlı Ürün Ekleme";
            this.Load += new System.EventHandler(this.frmhizlibtnurunekle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridurunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridurunler;
        private System.Windows.Forms.CheckBox chtumu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txturunara;
        public System.Windows.Forms.Label lblbutonid;
    }
}