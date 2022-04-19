
namespace Barkodsatis
{
    partial class frmgelirgider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgelirgider));
            this.cmbodemeturu = new System.Windows.Forms.ComboBox();
            this.datetarih = new System.Windows.Forms.DateTimePicker();
            this.btnekle = new Barkodsatis.btnstandart();
            this.lblstandart6 = new Barkodsatis.lblstandart();
            this.lblstandart5 = new Barkodsatis.lblstandart();
            this.txtaciklama = new Barkodsatis.txtstandart();
            this.lblstandart4 = new Barkodsatis.lblstandart();
            this.lblstandart3 = new Barkodsatis.lblstandart();
            this.txtkart = new Barkodsatis.txtstandart();
            this.txtnakit = new Barkodsatis.txtstandart();
            this.lblstandart2 = new Barkodsatis.lblstandart();
            this.lblgelirgider = new Barkodsatis.lblstandart();
            this.SuspendLayout();
            // 
            // cmbodemeturu
            // 
            this.cmbodemeturu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbodemeturu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbodemeturu.FormattingEnabled = true;
            this.cmbodemeturu.Items.AddRange(new object[] {
            "Nakit",
            "Kart",
            "Kart-Nakit"});
            this.cmbodemeturu.Location = new System.Drawing.Point(80, 128);
            this.cmbodemeturu.Name = "cmbodemeturu";
            this.cmbodemeturu.Size = new System.Drawing.Size(276, 33);
            this.cmbodemeturu.TabIndex = 3;
            this.cmbodemeturu.SelectedIndexChanged += new System.EventHandler(this.cmbodemeturu_SelectedIndexChanged);
            // 
            // datetarih
            // 
            this.datetarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.datetarih.Location = new System.Drawing.Point(80, 474);
            this.datetarih.Name = "datetarih";
            this.datetarih.Size = new System.Drawing.Size(276, 28);
            this.datetarih.TabIndex = 12;
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnekle.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnekle.ForeColor = System.Drawing.Color.White;
            this.btnekle.Image = ((System.Drawing.Image)(resources.GetObject("btnekle.Image")));
            this.btnekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnekle.Location = new System.Drawing.Point(77, 532);
            this.btnekle.Margin = new System.Windows.Forms.Padding(1);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(287, 51);
            this.btnekle.TabIndex = 13;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // lblstandart6
            // 
            this.lblstandart6.AutoSize = true;
            this.lblstandart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart6.ForeColor = System.Drawing.Color.Black;
            this.lblstandart6.Location = new System.Drawing.Point(75, 434);
            this.lblstandart6.Name = "lblstandart6";
            this.lblstandart6.Size = new System.Drawing.Size(57, 25);
            this.lblstandart6.TabIndex = 11;
            this.lblstandart6.Text = "Tarih";
            // 
            // lblstandart5
            // 
            this.lblstandart5.AutoSize = true;
            this.lblstandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart5.ForeColor = System.Drawing.Color.Black;
            this.lblstandart5.Location = new System.Drawing.Point(75, 283);
            this.lblstandart5.Name = "lblstandart5";
            this.lblstandart5.Size = new System.Drawing.Size(92, 25);
            this.lblstandart5.TabIndex = 10;
            this.lblstandart5.Text = "Açıklama";
            // 
            // txtaciklama
            // 
            this.txtaciklama.BackColor = System.Drawing.Color.White;
            this.txtaciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtaciklama.Location = new System.Drawing.Point(80, 323);
            this.txtaciklama.Multiline = true;
            this.txtaciklama.Name = "txtaciklama";
            this.txtaciklama.Size = new System.Drawing.Size(284, 86);
            this.txtaciklama.TabIndex = 9;
            // 
            // lblstandart4
            // 
            this.lblstandart4.AutoSize = true;
            this.lblstandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart4.ForeColor = System.Drawing.Color.Black;
            this.lblstandart4.Location = new System.Drawing.Point(223, 183);
            this.lblstandart4.Name = "lblstandart4";
            this.lblstandart4.Size = new System.Drawing.Size(48, 25);
            this.lblstandart4.TabIndex = 8;
            this.lblstandart4.Text = "Kart";
            // 
            // lblstandart3
            // 
            this.lblstandart3.AutoSize = true;
            this.lblstandart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart3.ForeColor = System.Drawing.Color.Black;
            this.lblstandart3.Location = new System.Drawing.Point(75, 183);
            this.lblstandart3.Name = "lblstandart3";
            this.lblstandart3.Size = new System.Drawing.Size(56, 25);
            this.lblstandart3.TabIndex = 7;
            this.lblstandart3.Text = "Nakit";
            // 
            // txtkart
            // 
            this.txtkart.BackColor = System.Drawing.Color.White;
            this.txtkart.Enabled = false;
            this.txtkart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtkart.Location = new System.Drawing.Point(228, 226);
            this.txtkart.Name = "txtkart";
            this.txtkart.Size = new System.Drawing.Size(128, 30);
            this.txtkart.TabIndex = 6;
            this.txtkart.Text = "0";
            // 
            // txtnakit
            // 
            this.txtnakit.BackColor = System.Drawing.Color.White;
            this.txtnakit.Enabled = false;
            this.txtnakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtnakit.Location = new System.Drawing.Point(80, 226);
            this.txtnakit.Name = "txtnakit";
            this.txtnakit.Size = new System.Drawing.Size(123, 30);
            this.txtnakit.TabIndex = 5;
            this.txtnakit.Text = "0";
            // 
            // lblstandart2
            // 
            this.lblstandart2.AutoSize = true;
            this.lblstandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart2.ForeColor = System.Drawing.Color.Black;
            this.lblstandart2.Location = new System.Drawing.Point(75, 100);
            this.lblstandart2.Name = "lblstandart2";
            this.lblstandart2.Size = new System.Drawing.Size(128, 25);
            this.lblstandart2.TabIndex = 4;
            this.lblstandart2.Text = "Ödeme Türü ";
            // 
            // lblgelirgider
            // 
            this.lblgelirgider.AutoSize = true;
            this.lblgelirgider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblgelirgider.ForeColor = System.Drawing.Color.Black;
            this.lblgelirgider.Location = new System.Drawing.Point(75, 30);
            this.lblgelirgider.Name = "lblgelirgider";
            this.lblgelirgider.Size = new System.Drawing.Size(112, 25);
            this.lblgelirgider.TabIndex = 0;
            this.lblgelirgider.Text = "lblstandart1";
            // 
            // frmgelirgider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(511, 644);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.datetarih);
            this.Controls.Add(this.lblstandart6);
            this.Controls.Add(this.lblstandart5);
            this.Controls.Add(this.txtaciklama);
            this.Controls.Add(this.lblstandart4);
            this.Controls.Add(this.lblstandart3);
            this.Controls.Add(this.txtkart);
            this.Controls.Add(this.txtnakit);
            this.Controls.Add(this.lblstandart2);
            this.Controls.Add(this.cmbodemeturu);
            this.Controls.Add(this.lblgelirgider);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmgelirgider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GELİR- GİDER";
            this.Load += new System.EventHandler(this.frmgelirgider_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblstandart lblgelirgider;
        private System.Windows.Forms.ComboBox cmbodemeturu;
        private lblstandart lblstandart2;
        private txtstandart txtnakit;
        private txtstandart txtkart;
        private lblstandart lblstandart3;
        private lblstandart lblstandart4;
        private txtstandart txtaciklama;
        private lblstandart lblstandart5;
        private lblstandart lblstandart6;
        private System.Windows.Forms.DateTimePicker datetarih;
        private btnstandart btnekle;
    }
}