
namespace Barkodsatis
{
    partial class frmfiyatguncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmfiyatguncelle));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblbarkod = new System.Windows.Forms.Label();
            this.lblurunadi = new System.Windows.Forms.Label();
            this.lblfiyat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.txtyenifiyat = new Barkodsatis.txtnumeric();
            this.txtbarkod = new Barkodsatis.txtstandart();
            this.lblkullanici = new Barkodsatis.lblstandart();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "Barkod Okutunuz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Barkod ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ürün Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fiyat";
            // 
            // lblbarkod
            // 
            this.lblbarkod.AutoSize = true;
            this.lblbarkod.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblbarkod.ForeColor = System.Drawing.Color.Black;
            this.lblbarkod.Location = new System.Drawing.Point(127, 174);
            this.lblbarkod.Name = "lblbarkod";
            this.lblbarkod.Size = new System.Drawing.Size(0, 28);
            this.lblbarkod.TabIndex = 12;
            // 
            // lblurunadi
            // 
            this.lblurunadi.AutoSize = true;
            this.lblurunadi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblurunadi.ForeColor = System.Drawing.Color.Black;
            this.lblurunadi.Location = new System.Drawing.Point(127, 231);
            this.lblurunadi.Name = "lblurunadi";
            this.lblurunadi.Size = new System.Drawing.Size(0, 28);
            this.lblurunadi.TabIndex = 13;
            // 
            // lblfiyat
            // 
            this.lblfiyat.AutoSize = true;
            this.lblfiyat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblfiyat.ForeColor = System.Drawing.Color.Black;
            this.lblfiyat.Location = new System.Drawing.Point(127, 284);
            this.lblfiyat.Name = "lblfiyat";
            this.lblfiyat.Size = new System.Drawing.Size(0, 28);
            this.lblfiyat.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "Yeni Fiyat";
            // 
            // btnkaydet
            // 
            this.btnkaydet.BackColor = System.Drawing.Color.OrangeRed;
            this.btnkaydet.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnkaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.ForeColor = System.Drawing.Color.White;
            this.btnkaydet.Location = new System.Drawing.Point(207, 387);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(147, 37);
            this.btnkaydet.TabIndex = 17;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.UseVisualStyleBackColor = false;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // txtyenifiyat
            // 
            this.txtyenifiyat.BackColor = System.Drawing.Color.White;
            this.txtyenifiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtyenifiyat.Location = new System.Drawing.Point(12, 387);
            this.txtyenifiyat.Multiline = true;
            this.txtyenifiyat.Name = "txtyenifiyat";
            this.txtyenifiyat.Size = new System.Drawing.Size(189, 36);
            this.txtyenifiyat.TabIndex = 15;
            this.txtyenifiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbarkod
            // 
            this.txtbarkod.BackColor = System.Drawing.Color.White;
            this.txtbarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtbarkod.Location = new System.Drawing.Point(12, 64);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(250, 30);
            this.txtbarkod.TabIndex = 0;
            this.txtbarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbarkod_KeyDown);
            // 
            // lblkullanici
            // 
            this.lblkullanici.AutoSize = true;
            this.lblkullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblkullanici.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblkullanici.Location = new System.Drawing.Point(382, 22);
            this.lblkullanici.Name = "lblkullanici";
            this.lblkullanici.Size = new System.Drawing.Size(112, 25);
            this.lblkullanici.TabIndex = 18;
            this.lblkullanici.Text = "lblstandart1";
            // 
            // frmfiyatguncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 600);
            this.Controls.Add(this.lblkullanici);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtyenifiyat);
            this.Controls.Add(this.lblfiyat);
            this.Controls.Add(this.lblurunadi);
            this.Controls.Add(this.lblbarkod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbarkod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmfiyatguncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiyat Güncelle";
            this.Load += new System.EventHandler(this.frmfiyatguncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private txtstandart txtbarkod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblbarkod;
        private System.Windows.Forms.Label lblurunadi;
        private System.Windows.Forms.Label lblfiyat;
        private txtnumeric txtyenifiyat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnkaydet;
        internal lblstandart lblkullanici;
    }
}