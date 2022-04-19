using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodsatis
{
    public partial class frmgelirgider : Form
    {
        public frmgelirgider()
        {
            InitializeComponent();
        }
        public string GelirGider { get; set; }
        public string kullanici { get; set; } 

        private void frmgelirgider_Load(object sender, EventArgs e)
        {

            lblgelirgider.Text = GelirGider +" İŞLEMİ YAPILIYOR";
        }

        private void cmbodemeturu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbodemeturu.SelectedIndex==0)
            {
                txtnakit.Enabled = true;
                txtkart.Enabled = false;

            }
            else if (cmbodemeturu.SelectedIndex == 1)
            {
                txtnakit.Enabled = false;
                txtkart.Enabled = true;

            }
            else if (cmbodemeturu.SelectedIndex == 2)
            {
                txtnakit.Enabled = true;
                txtkart.Enabled = true;
                
            }
            txtkart.Text = "0";
            txtnakit.Text = "0";
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if(cmbodemeturu.Text!="")
            {
                if(txtnakit.Text!="" && txtkart.Text!="" )
                {
                    using (var db = new barkodlusatisEntities())
                    {
                        islem_ozet io = new islem_ozet();
                        io.islemno = 0;
                        io.iademi = false;
                        io.odemesekli = cmbodemeturu.Text;
                        io.nakit = islemler.DoubleYap(txtnakit.Text);
                        io.kart = islemler.DoubleYap(txtkart.Text);
                        if(GelirGider=="GELİR")
                        {
                            io.gelir = true;
                            io.gider = false;
                        }
                        else
                        {
                            io.gelir = false;
                            io.gider = true;
                        }
                        io.alisfiyat_toplam = 0;
                        io.aciklama = GelirGider + "- İşlemi " + txtaciklama.Text;
                        io.tarih = datetarih.Value;
                        io.kullanici = kullanici;
                        db.islem_ozet.Add(io);
                        db.SaveChanges();
                        MessageBox.Show(GelirGider +"İşlemi Kaydedildi");
                        txtnakit.Text = "";
                        txtkart.Text = "0";
                        txtaciklama.Clear();
                        cmbodemeturu.Text = "";

                        frmrapor frm = (frmrapor)Application.OpenForms["frmrapor"];
                        if(frm!=null)
                        {
                            frm.btngöster_Click(null,null);
                        }
                        this.Hide();




                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Ödeme Türünü Belirleyiniz");

            }
        }
    }
}
