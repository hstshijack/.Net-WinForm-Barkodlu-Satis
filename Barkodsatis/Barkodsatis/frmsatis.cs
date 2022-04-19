
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Barkodsatis;
using System.Linq;

namespace BorkodluSatis
{
    public partial class frmsatis : Form
    {
        public frmsatis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("data source=DESKTOP-10S04G1;initial catalog=barkodlusatis;integrated security=True;");
        barkodlusatisEntities db = new barkodlusatisEntities();
        private void frmsatis_Load(object sender, EventArgs e)
        {
            HizliButonDoldur();
            btn5.Text = 5.ToString("C2");
            btn10.Text = 10.ToString("C2");
            btn20.Text = 20.ToString("C2");
            btn50.Text = 50.ToString("C2");
            btn100.Text = 100.ToString("C2");
            btn200.Text = 200.ToString("C2");

            using (var db=new barkodlusatisEntities())
            {
                var sabit = db.sabit.FirstOrDefault();
                chyazdirmadurumu.Checked = Convert.ToBoolean(sabit.Yazici);
                
            }
        }
        public void HizliButonDoldur()
        {
            var hizliurun = db.hizliurun.ToList();
            foreach (var item in hizliurun)
            {
                Button bh = this.Controls.Find("hbtn" + item.id, true).FirstOrDefault() as Button;

                if(bh!=null)
                {
                    double fiyat = islemler.DoubleYap(item.fiyat.ToString());
                    bh.Text = item.urunadi + "\n"+fiyat.ToString("C2");
                }
            }
        }
        private void HizliButtonClick(object sender,EventArgs e)
        {
            Button b = (Button)sender;
            int butonid = Convert.ToInt16(b.Name.ToString().Substring(4, b.Name.Length - 4));
            if (b.Text.ToString().StartsWith("-"))
            {
                frmhizlibtnurunekle frm = new frmhizlibtnurunekle();
                frm.lblbutonid.Text = butonid.ToString();
                frm.ShowDialog();
                
            }else
            {
               
                var urunbarkod = db.hizliurun.Where(a => a.id == butonid).Select(a => a.barkod).FirstOrDefault();
                var urun = db.Urunler.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirListeye(urun, urunbarkod, Convert.ToDouble(txtmiktar.Text));
                GenelToplam();
            }
           
        }
     
        private void txtbarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string barkod = txtbarkod.Text.Trim();
                if(barkod.Length<=2)
                {
                    txtmiktar.Text = barkod;
                    txtbarkod.Clear();

                    txtbarkod.Focus();


                }
                else
                {
              

                    if(db.Urunler.Any(a=> a.Barkod==barkod))
                    {
                        var urun = db.Urunler.Where(a => a.Barkod == barkod).FirstOrDefault();
                        UrunGetirListeye(urun, barkod, Convert.ToDouble(txtmiktar.Text));
                   
                    }
                    else

                    {
                        if(txtbarkod.Text.Length>=7)
                            {
                            string onek = barkod.Substring(0, 2).ToString();
                            if (db.terazi.Any(a => a.TeraziOnEk == onek))
                            {
                                string teraziurunno = barkod.Substring(2, 5);
                                if (db.Urunler.Any(a => a.Barkod == teraziurunno))
                                {
                                    var urunterazi = db.Urunler.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                    double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                    UrunGetirListeye(urunterazi, teraziurunno, miktarkg);
                                }
                                else
                                {
                                    Console.Beep(900, 2000);
                                    frmurungiris frm = new frmurungiris();
                                    frm.ShowDialog();

                                }
                            }
                            else

                            {
                                //Console.Beep(900, 2000);
                                frmurungiris frm = new frmurungiris();
                                frm.txtbarkod.Text = barkod;
                                frm.ShowDialog();
                            }

                        }





                    }


     


                }
                gridsatislistesi.ClearSelection();
                GenelToplam();
               

            }
        }
        private void UrunGetirListeye(Urunler urun,string barkod,double miktar)
        {
            int satirsayisi = gridsatislistesi.Rows.Count;
            //double miktar = Convert.ToDouble(txtmiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridsatislistesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Miktar"].Value);
                        gridsatislistesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Fiyat"].Value), 2);
                        eklenmismi = true;

                    }
                }
            }
            if (!eklenmismi)
            {
                gridsatislistesi.Rows.Add();
                gridsatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                gridsatislistesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAdi;
                gridsatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridsatislistesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridsatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyati;
                gridsatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                gridsatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyati, 2);
                gridsatislistesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = urun.AlisFiyati;
                gridsatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;




            }
        }

        private void GenelToplam()
        {



            double toplam = 0;
            for (int i = 0; i < gridsatislistesi.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(gridsatislistesi.Rows[i].Cells["Toplam"].Value);

            }
            txtgeneltoplam.Text = toplam.ToString("C2");
            txtmiktar.Text = "1";
            txtbarkod.Clear();
            txtbarkod.Focus();



        }

        private void gridsatislistesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==9)
            {
                gridsatislistesi.Rows.Remove(gridsatislistesi.CurrentRow);
                
                gridsatislistesi.ClearSelection();
                GenelToplam();
          
                txtbarkod.Focus();
            }
        }
        private void bh_MouseDown(object sender,MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int butonid = Convert.ToInt16(b.Name.ToString().Substring(4, b.Name.Length - 4));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + butonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int buttonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.hizliurun.Find(buttonid);
            guncelle.barkod = "-";
            guncelle.urunadi = "-";
            guncelle.fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("hbtn" + buttonid, true).FirstOrDefault() as Button;
            b.Text = "-"+"\n"+fiyat.ToString("C2");
            
        }

        private void bnx_Click(object sender,EventArgs e)
        {
            Button b = (Button)sender;

            if(b.Text==",")
            {
                int virgul = txtnumarator.Text.Count(x => x == ',');
                if(virgul<1)
                {
                    txtnumarator.Text += b.Text;
                }
            }
            else if(b.Text=="<")
            {
                if(txtnumarator.Text.Length>0)
                {
                    txtnumarator.Text = txtnumarator.Text.Substring(0, txtnumarator.Text.Length - 1);
                }
            }

            else
            {
                txtnumarator.Text += b.Text;
            }


        }

        private void Badet_Click(object sender, EventArgs e)
        {
            if(txtnumarator.Text!="")
            {
                txtmiktar.Text = txtnumarator.Text;
                txtnumarator.Clear();
                txtbarkod.Clear();
                txtbarkod.Focus();
            }
        }

        private void bodenen_Click(object sender, EventArgs e)
        {
            if (txtnumarator.Text != "")
            {
                double sonuc = islemler.DoubleYap(txtnumarator.Text) - islemler.DoubleYap(txtgeneltoplam.Text);
                txtparaustu.Text = sonuc.ToString("C2");
                double odenen = islemler.DoubleYap(txtnumarator.Text);
                txtödenen.Text = odenen.ToString("C2");


                txtnumarator.Clear();
                txtbarkod.Focus();
                
            }
        }

        private void bbarkod_Click(object sender, EventArgs e)
        {
            if(txtnumarator.Text!="")
            {
                if(db.Urunler.Any(a=> a.Barkod==txtnumarator.Text))
                {
                    var urun = db.Urunler.Where(a => a.Barkod == txtnumarator.Text).FirstOrDefault();
                    UrunGetirListeye(urun, txtnumarator.Text, Convert.ToDouble(txtmiktar.Text));
                    txtnumarator.Clear();
                    txtbarkod.Focus();
                }
                else
                {
                    frmurungiris frm = new frmurungiris();
                    frm.ShowDialog();
                }
            }
        }
        private void ParaUstuHesapla_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double sonuc = islemler.DoubleYap(b.Text) - islemler.DoubleYap(txtgeneltoplam.Text);
            txtparaustu.Text = sonuc.ToString("C2");
            txtödenen.Text =islemler.DoubleYap(b.Text).ToString("C2");
        }

        private void bdigerurun_Click(object sender, EventArgs e)
        {
            if(txtnumarator.Text!="")
            {
                int satirsayisi = gridsatislistesi.Rows.Count;
                gridsatislistesi.Rows.Add();
                gridsatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111116";
                gridsatislistesi.Rows[satirsayisi].Cells["Urunadi"].Value = "Barkodsuz Ürün";
                gridsatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                gridsatislistesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridsatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridsatislistesi.Rows[satirsayisi].Cells["Alisfiyati"].Value = 0;
                gridsatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(txtnumarator.Text);
                gridsatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridsatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(txtnumarator.Text);      
                txtnumarator.Text = "";
                GenelToplam();
                txtbarkod.Focus();
            }
        }

        private void btniade_Click(object sender, EventArgs e)
        {
            if(chsatisiade.Checked)
            {
                chsatisiade.Checked = false;
                chsatisiade.Text = "Satış Yapılıyor";

            }
            else
            {
                chsatisiade.Checked = true;
                chsatisiade.Text = "İade İşlemi";
            }
        }

        private void temizle()
        {
            txtmiktar.Text="1";
            txtbarkod.Clear();
            txtödenen.Clear();
            txtparaustu.Clear();
            txtgeneltoplam.Text = 0.ToString("C2");
            chsatisiade.Checked = false;
            txtnumarator.Clear();
            gridsatislistesi.Rows.Clear();
            txtbarkod.Clear();
            txtbarkod.Focus();

        }
        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }

        public void SatisYap(string odemesekli)
        {
            int satirsayisi = gridsatislistesi.Rows.Count;
            bool satisiade = chsatisiade.Checked;
            double alisfiyattoplam = 0;

            if(satirsayisi>0)
            {
                int? islemno = db.islem.First().islemno;
                satis satis = new satis();

                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.islemno = islemno;
                    satis.urunadi = gridsatislistesi.Rows[i].Cells["Urunadi"].Value.ToString();
                    satis.urungrup = gridsatislistesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.barkod = gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.birim = gridsatislistesi.Rows[i].Cells["Birim"].Value.ToString();
                    satis.alisfiyat =islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Alisfiyati"].Value.ToString());
                    satis.satisfiyat = islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["fiyat"].Value.ToString());
                    satis.miktar = islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["miktar"].Value.ToString());
                    satis.toplam = islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["toplam"].Value.ToString());
                    satis.kdvtutari = islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["kdvtutari"].Value.ToString()) * islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["miktar"].Value.ToString());
                    satis.odeme_sekli = odemesekli;
                    satis.iade = satisiade;
                    satis.tarih = DateTime.Now;
                    satis.kullanici = lblkullanici.Text;
                    db.satis.Add(satis);
                    db.SaveChanges();
                    

                
                    if(!satisiade)
                    {
                        islemler.StokAzalt(gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString(),islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["miktar"].Value.ToString()));

                    }
                    else
                    {
                        islemler.StokARttır(gridsatislistesi.Rows[i].Cells["Barkod"].Value.ToString(), islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["miktar"].Value.ToString()));
                    }
                    alisfiyattoplam += islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["Alisfiyati"].Value.ToString())* islemler.DoubleYap(gridsatislistesi.Rows[i].Cells["miktar"].Value.ToString()); 

                }
                islem_ozet io = new islem_ozet();
                io.islemno = islemno;
                io.iademi = satisiade;
                io.alisfiyat_toplam = alisfiyattoplam;
                io.gelir = false;
                io.gider = false;
                if(!satisiade)
                {
                    io.aciklama = odemesekli + "Satış";
                }
                else

                {
                    
                    io.aciklama = "İade İşlemi (" + odemesekli + ")";
                }
                io.odemesekli = odemesekli;
                io.kullanici = lblkullanici.Text;
                io.tarih = DateTime.Now;

                switch(odemesekli)
                {
                    case "Nakit":
                        io.nakit = islemler.DoubleYap(txtgeneltoplam.Text);
                        io.kart = 0;break;

                    case "Kart":
                        io.nakit = 0;
                        io.kart = islemler.DoubleYap(txtgeneltoplam.Text); break;

                    case "Kart-Nakit":
                        io.nakit = islemler.DoubleYap(lnakit.Text);
                        io.kart = islemler.DoubleYap(lkart.Text);
                        break;
                        
                }
                db.islem_ozet.Add(io);
                db.SaveChanges();
                var islemnoarttir = db.islem.First();
                islemnoarttir.islemno += 1;
                db.SaveChanges();
                if(chyazdirmadurumu.Checked)
                {
                    yazdir yazdir = new yazdir(islemno);
                    yazdir.YazdirmayaBasla();
                }
                temizle();

            }
        }

        private void btnnakit_Click(object sender, EventArgs e)
        {
            SatisYap("Nakit");
        }

        private void btnkartnakit_Click(object sender, EventArgs e)
        {
            frmnakitkart frm = new frmnakitkart();
            frm.ShowDialog();
        }

        private void btnkart_Click(object sender, EventArgs e)
        {
            SatisYap("Kart");
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void txtmiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void txtnumarator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void frmsatis_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F1)
                SatisYap("Nakit");
           
            if (e.KeyCode == Keys.F2)
            
                SatisYap("Kart");
            if(e.KeyCode==Keys.F3)
            {
                frmnakitkart frm = new frmnakitkart();
                frm.ShowDialog();
            }
            
        }

        private void btnislembeklet_Click(object sender, EventArgs e)
        { 
            if(btnislembeklet.Text=="İşlem Beklet")
            {
                Bekle();
                btnislembeklet.BackColor = System.Drawing.Color.Tomato;
                btnislembeklet.Text = "İşlem Bekliyor";
                gridsatislistesi.Rows.Clear();

            }
            else
            {
                BeklemedenCik();
                btnislembeklet.BackColor = System.Drawing.Color.YellowGreen;
                btnislembeklet.Text = "İşlem Beklet";
                gridbekle.Rows.Clear();
            }

       

        }
        private void Bekle()
        {
            int satir = gridsatislistesi.Rows.Count;
            int sutun = gridsatislistesi.Columns.Count;
            if(satir>0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridbekle.Rows.Add();
                    for (int j = 0; j < sutun-1; j++)
                    {
                        gridbekle.Rows[i].Cells[j].Value = gridsatislistesi.Rows[i].Cells[j].Value;
                    }
                }
            }
          
        }
        private void BeklemedenCik()
        {
            int satir =gridbekle.Rows.Count;
            int sutun = gridbekle.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                   gridsatislistesi.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridsatislistesi.Rows[i].Cells[j].Value = gridbekle.Rows[i].Cells[j].Value;
                    }
                }
            }
            GenelToplam();
        }

        private void chsatisiade_CheckedChanged(object sender, EventArgs e)
        {
            if(chsatisiade.Checked)
            {
                chsatisiade.Text = "İade Yapılıyor";

            }
            else

            {
                chsatisiade.Text = "Satış Yapılıyor";
            }

        }
    }
}
