
namespace Barkodsatis
{
    partial class frmurungrubuekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmurungrubuekle));
            this.lblstandart = new Barkodsatis.lblstandart();
            this.txturungrupadi = new Barkodsatis.txtstandart();
            this.listurungrup = new System.Windows.Forms.ListBox();
            this.btnekle = new Barkodsatis.btnstandart();
            this.btnsil = new Barkodsatis.btnstandart();
            this.SuspendLayout();
            // 
            // lblstandart
            // 
            this.lblstandart.AutoSize = true;
            this.lblstandart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblstandart.Location = new System.Drawing.Point(30, 30);
            this.lblstandart.Name = "lblstandart";
            this.lblstandart.Size = new System.Drawing.Size(147, 25);
            this.lblstandart.TabIndex = 0;
            this.lblstandart.Text = "Ürün Grubu Adı";
            // 
            // txturungrupadi
            // 
            this.txturungrupadi.BackColor = System.Drawing.Color.White;
            this.txturungrupadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txturungrupadi.Location = new System.Drawing.Point(35, 68);
            this.txturungrupadi.Name = "txturungrupadi";
            this.txturungrupadi.Size = new System.Drawing.Size(323, 30);
            this.txturungrupadi.TabIndex = 1;
            // 
            // listurungrup
            // 
            this.listurungrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listurungrup.FormattingEnabled = true;
            this.listurungrup.ItemHeight = 25;
            this.listurungrup.Location = new System.Drawing.Point(35, 115);
            this.listurungrup.Name = "listurungrup";
            this.listurungrup.Size = new System.Drawing.Size(323, 179);
            this.listurungrup.TabIndex = 2;
            // 
            // btnekle
            // 
            this.btnekle.BackColor = System.Drawing.Color.CadetBlue;
            this.btnekle.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.btnekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnekle.ForeColor = System.Drawing.Color.White;
            this.btnekle.Image = ((System.Drawing.Image)(resources.GetObject("btnekle.Image")));
            this.btnekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnekle.Location = new System.Drawing.Point(214, 308);
            this.btnekle.Margin = new System.Windows.Forms.Padding(1);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(144, 68);
            this.btnekle.TabIndex = 0;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = false;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btnsil
            // 
            this.btnsil.BackColor = System.Drawing.Color.Crimson;
            this.btnsil.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.ForeColor = System.Drawing.Color.White;
            this.btnsil.Image = ((System.Drawing.Image)(resources.GetObject("btnsil.Image")));
            this.btnsil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsil.Location = new System.Drawing.Point(35, 308);
            this.btnsil.Margin = new System.Windows.Forms.Padding(1);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(142, 68);
            this.btnsil.TabIndex = 3;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // frmurungrubuekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnsil);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.listurungrup);
            this.Controls.Add(this.txturungrupadi);
            this.Controls.Add(this.lblstandart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmurungrubuekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Grubu Ekle";
            this.Load += new System.EventHandler(this.frmurungrubuekle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblstandart lblstandart;
        private txtstandart txturungrupadi;
        private System.Windows.Forms.ListBox listurungrup;
        private btnstandart btnekle;
        private btnstandart btnsil;
    }
}