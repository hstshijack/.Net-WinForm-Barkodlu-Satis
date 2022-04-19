using BorkodluSatis;
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
    public partial class frmurungiris : Form
    {
        public frmurungiris()
        {
            InitializeComponent();
        }
        barkodlusatisEntities db = new barkodlusatisEntities();

        private void txtbarkod_KeyDown(object sender, KeyEventArgs e)
        {
          if(e.KeyCode==Keys.Enter)
            {
                string barkod = txtbarkod.Text.Trim();
                if(db.Urunler.Any(a=>a.Barkod==barkod))
                    {
                    var urun = db.Urunler.Where(a => a.Barkod == barkod).SingleOrDefault();
                    txturunadi.Text = urun.UrunAdi;
                    txtaciklama.Text = urun.Aciklama;
                    cmburungrubu.Text = urun.UrunGrup;
                    txtalisfiyati.Text = urun.AlisFiyati.ToString();
                    txtsatisfiyati.Text = urun.SatisFiyati.ToString();
                    txtmiktar.Text = urun.Miktar.ToString();
                    txtkdvorani.Text = urun.KdvOrani.ToString();
                    if(urun.Birim=="Kg")
                    {
                        churuntipi.Checked = true;

                    }
                    else
                    {
                        churuntipi.Checked = false;
                    }

                    }
                else
                {
                    MessageBox.Show("Ürün Kayıtlı Değil, Kaydedebilirsiniz...");
                }
            }
         
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtbarkod.Text != "" && txturunadi.Text != "" && cmburungrubu.Text != "" && txtalisfiyati.Text != "" && txtsatisfiyati.Text != "" && txtkdvorani.Text != "" && txtmiktar.Text != "") 
            {
                if (db.Urunler.Any(a => a.Barkod == txtbarkod.Text))
                {
                    var guncelle = db.Urunler.Where(a => a.Barkod == txtbarkod.Text).SingleOrDefault();
                    guncelle.UrunAdi = txturunadi.Text;
                    guncelle.Aciklama = txtaciklama.Text;
                    guncelle.UrunGrup = cmburungrubu.Text;
                    guncelle.AlisFiyati = Convert.ToDouble(txtalisfiyati.Text);
                    guncelle.SatisFiyati = Convert.ToDouble(txtsatisfiyati.Text);
                    guncelle.KdvOrani = Convert.ToInt16(txtkdvorani.Text);
                    guncelle.KdvTutari = Math.Round(islemler.DoubleYap(txtsatisfiyati.Text) * Convert.ToInt16(txtkdvorani.Text) / 100, 2);
                    guncelle.Miktar += Convert.ToDouble(txtmiktar.Text);
                    if(churuntipi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                            
                  
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lblkullaniciurungiris.Text;
                    db.SaveChanges();

                    MessageBox.Show("Ürün Güncellenmiştir");
                    gridurunler.DataSource = db.Urunler.OrderByDescending(a => a.UrunId).Take(10).ToList();
                }
                else
                {
                    Urunler urun = new Urunler();
                    urun.Barkod = txtbarkod.Text;
                    urun.UrunAdi = txturunadi.Text;
                    urun.Aciklama = txtaciklama.Text;
                    urun.UrunGrup = cmburungrubu.Text;
                    urun.AlisFiyati = Convert.ToDouble(txtalisfiyati.Text);
                    urun.SatisFiyati = Convert.ToDouble(txtsatisfiyati.Text);
                    urun.KdvOrani = Convert.ToInt16(txtkdvorani.Text);
                    urun.KdvTutari = Math.Round(islemler.DoubleYap(txtsatisfiyati.Text) * Convert.ToInt16(txtkdvorani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(txtmiktar.Text);
                    if(churuntipi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }
                   
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lblkullaniciurungiris.Text;
                    db.Urunler.Add(urun);
                    db.SaveChanges();
                    if (txtbarkod.Text.Length == 8)
                    {
                        var ozelbarkod = db.barkod.First();
                        ozelbarkod.barkodno += 1;
                        db.SaveChanges();

                    }

                    islemler.StokHareket(txtbarkod.Text, txturunadi.Text, "Adet", Convert.ToDouble(txtmiktar.Text), cmburungrubu.Text, lblkullaniciurungiris.Text);
                    temizle();
                }



                gridurunler.DataSource = db.Urunler.OrderByDescending(a => a.UrunId).Take(20).ToList();
                islemler.GridDuzenle(gridurunler);


            } 
            
            else
            {
                MessageBox.Show("Lütfen Giriş Bilgilerinizi Kontrol Ediniz");
                txtbarkod.Focus();
            }
            

            




        }
        


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txturunara_TextChanged(object sender, EventArgs e)
        {
            if(txturunara.Text.Length>=2)
            {
                string urunad = txturunara.Text;
                gridurunler.DataSource = db.Urunler.Where(a => a.UrunAdi.Contains(urunad)).ToList();
                islemler.GridDuzenle(gridurunler);
            }

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {
            txtbarkod.Clear();
            txturunadi.Clear();
            txtaciklama.Clear();
            txtalisfiyati.Text = "0";
            txtsatisfiyati.Text = "0";
            txtmiktar.Text = "0";
            txtkdvorani.Text = "8";
            txtbarkod.Focus();
            churuntipi.Checked = false;
        }

        private void frmurungiris_Load(object sender, EventArgs e)
        {
            txturunsayisi.Text = db.Urunler.Count().ToString();
            gridurunler.DataSource = db.Urunler.OrderByDescending(a => a.UrunId).Take(20).ToList();
            
            grupdoldur();
            islemler.GridDuzenle(gridurunler);
            
        }
        public void grupdoldur()
        {
            cmburungrubu.DisplayMember = "urungrupadi";
            cmburungrubu.ValueMember = "id";
            cmburungrubu.DataSource = db.urungrup.OrderBy(a => a.urungrupadi).ToList();
        }
        private void btnurungrubuekle_Click(object sender, EventArgs e)
        {
            frmurungrubuekle frm = new frmurungrubuekle();
            frm.ShowDialog();
        }

        private void btnbarkodolustur_Click(object sender, EventArgs e)
        {
            var barkodno = db.barkod.First();
            int karakter = barkodno.barkodno.ToString().Length;
            string sifirlar = string.Empty;
            for (int i= 0; i <8-karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.barkodno.ToString();
            txtbarkod.Text = olusanbarkod;
            txturunadi.Focus();



        }

        private void txtsatisfiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08 && e.KeyChar!=(char)44 && e.KeyChar!=(char)45)
            {
                e.Handled = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridurunler.Rows.Count>0)
            {
                int urunid = Convert.ToInt32(gridurunler.CurrentRow.Cells["Urunid"].Value.ToString());
                string urunad = gridurunler.CurrentRow.Cells["Urunadi"].Value.ToString();
                string barkod = gridurunler.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunad + "Ürünü Silmek İstiyor musunuz ?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urunler.Find(urunid);
                    db.Urunler.Remove(urun);
                    db.SaveChanges();
                    if (db.hizliurun.Any(a => a.barkod == barkod))
                    {
                        var hizliurun = db.hizliurun.Where(x => x.barkod == barkod).SingleOrDefault();
                        hizliurun.barkod = "-";
                        hizliurun.urunadi = "-";
                        hizliurun.fiyat = 0;
                        db.SaveChanges();
                        frmsatis frm = (frmsatis)Application.OpenForms["frmsatis"];
                        frm.HizliButonDoldur();

                        
                        

                    }
                 
                    MessageBox.Show("Ürün Silinmiştir");
                    gridurunler.DataSource = db.Urunler.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    islemler.GridDuzenle(gridurunler);
                    txtbarkod.Focus();

                }
            }
            

        }

        private void churuntipi_CheckedChanged(object sender, EventArgs e)
        {
            if(churuntipi.Checked)
            {
                churuntipi.Text = "Gramajlı Ürün İşlemi";
                btnbarkodolustur.Enabled = false;
                
            }
            else
            {
                churuntipi.Text = "Barkodlu Ürün İşlemi";
                btnbarkodolustur.Enabled = true;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridurunler.Rows.Count>0)
            {
                txtbarkod.Text = gridurunler.CurrentRow.Cells["barkod"].Value.ToString();
                txturunadi.Text= gridurunler.CurrentRow.Cells["urunadi"].Value.ToString();
                txtaciklama.Text= gridurunler.CurrentRow.Cells["aciklama"].Value.ToString();
                cmburungrubu.Text= gridurunler.CurrentRow.Cells["urungrup"].Value.ToString();
                txtalisfiyati.Text= gridurunler.CurrentRow.Cells["alisfiyati"].Value.ToString();
                txtsatisfiyati.Text= gridurunler.CurrentRow.Cells["satisfiyati"].Value.ToString();
                txtkdvorani.Text= gridurunler.CurrentRow.Cells["kdvorani"].Value.ToString();
                txtmiktar.Text= gridurunler.CurrentRow.Cells["miktar"].Value.ToString();
                string birim= gridurunler.CurrentRow.Cells["birim"].Value.ToString();
                if(birim=="Kg")
                {
                    churuntipi.Checked = true;
                }
                else
                {
                    churuntipi.Checked = false;
                }

            }
        }

        private void gridurunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
