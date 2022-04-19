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
    public partial class frmfiyatguncelle : Form
    {
        public frmfiyatguncelle()
        {
            InitializeComponent();
        }

        private void frmfiyatguncelle_Load(object sender, EventArgs e)
        {
            lblbarkod.Text = "";
            lblurunadi.Text = "";
            lblfiyat.Text = "";
        }

        private void txtbarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                using (var db= new barkodlusatisEntities())
                {
                    if(db.Urunler.Any(x=> x.Barkod==txtbarkod.Text))
                        {
                        var getir = db.Urunler.Where(x => x.Barkod == txtbarkod.Text).SingleOrDefault();
                        lblbarkod.Text = getir.Barkod;
                        lblurunadi.Text = getir.UrunAdi;
                        double mevcutfiyat = Convert.ToDouble(getir.SatisFiyati);
                        lblfiyat.Text = mevcutfiyat.ToString("C2");





                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı Değil");
                    }

                }
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if(txtyenifiyat.Text!="" && lblbarkod.Text!="")
            {
                using ( var db = new barkodlusatisEntities())
                {
                    var urungetir = db.Urunler.Where(x => x.Barkod == txtbarkod.Text).SingleOrDefault();
                    var guncellenecek = db.Urunler.Where(x => x.Barkod == lblbarkod.Text).SingleOrDefault();
                        {
                        guncellenecek.SatisFiyati = islemler.DoubleYap(txtyenifiyat.Text);
                        int kdvorani = Convert.ToInt16(guncellenecek.KdvOrani);
                        Math.Round(islemler.DoubleYap(txtyenifiyat.Text) * kdvorani / 100);
                        db.SaveChanges();
                        MessageBox.Show("Fiyat kaydedilmiştir");
                        lblbarkod.Text =urungetir.Barkod;
                        lblurunadi.Text = urungetir.UrunAdi;
                        double mevcutfiyat = Convert.ToDouble(urungetir.SatisFiyati);
                        lblfiyat.Text = mevcutfiyat.ToString("C2");
                        txtyenifiyat.Clear();
                        txtbarkod.Text = "";
                        txtbarkod.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ürün Okutunuz");
                txtbarkod.Focus();
            }
        }
    }
}
