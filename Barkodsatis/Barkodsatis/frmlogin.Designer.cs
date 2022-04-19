
namespace Barkodsatis
{
    partial class frmlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtkullaniciadi = new Barkodsatis.txtstandart();
            this.txtsifre = new Barkodsatis.txtstandart();
            this.lblstandart1 = new Barkodsatis.lblstandart();
            this.lblstandart2 = new Barkodsatis.lblstandart();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtkullaniciadi
            // 
            this.txtkullaniciadi.BackColor = System.Drawing.Color.White;
            this.txtkullaniciadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtkullaniciadi.Location = new System.Drawing.Point(361, 106);
            this.txtkullaniciadi.Name = "txtkullaniciadi";
            this.txtkullaniciadi.Size = new System.Drawing.Size(231, 30);
            this.txtkullaniciadi.TabIndex = 1;
            this.txtkullaniciadi.Text = "admin1";
            // 
            // txtsifre
            // 
            this.txtsifre.BackColor = System.Drawing.Color.White;
            this.txtsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtsifre.Location = new System.Drawing.Point(361, 162);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(231, 30);
            this.txtsifre.TabIndex = 2;
            this.txtsifre.Text = "admin1";
            // 
            // lblstandart1
            // 
            this.lblstandart1.AutoSize = true;
            this.lblstandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart1.ForeColor = System.Drawing.Color.Black;
            this.lblstandart1.Location = new System.Drawing.Point(200, 106);
            this.lblstandart1.Name = "lblstandart1";
            this.lblstandart1.Size = new System.Drawing.Size(119, 25);
            this.lblstandart1.TabIndex = 3;
            this.lblstandart1.Text = "Kullanıcı Adı";
            // 
            // lblstandart2
            // 
            this.lblstandart2.AutoSize = true;
            this.lblstandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblstandart2.ForeColor = System.Drawing.Color.Black;
            this.lblstandart2.Location = new System.Drawing.Point(200, 162);
            this.lblstandart2.Name = "lblstandart2";
            this.lblstandart2.Size = new System.Drawing.Size(52, 25);
            this.lblstandart2.TabIndex = 4;
            this.lblstandart2.Text = "Şifre";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(361, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 59);
            this.button1.TabIndex = 5;
            this.button1.Text = "Giriş";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(196, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 49);
            this.label2.TabIndex = 7;
            this.label2.Text = "Barkodlu Satış Programı";
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 318);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblstandart2);
            this.Controls.Add(this.lblstandart1);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.txtkullaniciadi);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmlogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private txtstandart txtkullaniciadi;
        private txtstandart txtsifre;
        private lblstandart lblstandart1;
        private lblstandart lblstandart2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}