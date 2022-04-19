using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodsatis
{
    public partial class frmayarlar : Form
    {
        public frmayarlar()
        {
            InitializeComponent();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (btnkaydet.Text == "Kaydet")
            {
                if (txtadsoyad.Text != "" && maskedtelefon.Text != "" && txtkullaniciadi.Text != "" && txtsifre.Text != "" && txtsifretekrar.Text != "")
                {
                    if (txtsifretekrar.Text == txtsifretekrar.Text)
                    {
                        try
                        {
                            using (var db = new barkodlusatisEntities())
                            {
                                if (!db.kullanici.Any(x => x.KullaniciAd == txtkullaniciadi.Text))
                                {
                                    kullanici k = new kullanici();
                                    k.AdSoyad = txtadsoyad.Text;
                                    k.Telefon = maskedtelefon.Text;
                                    k.Eposta = txteposta.Text;
                                    k.KullaniciAd = txtkullaniciadi.Text.Trim();
                                    k.Sifre = txtsifre.Text;
                                    k.Satis = chsatis.Checked;
                                    k.Rapor = chrapor.Checked;
                                    k.Stok = chstok.Checked;
                                    k.Urungiris = churungiris.Checked;
                                    k.Ayarlar = chayarlar.Checked;
                                    k.FiyatGuncelle = chfiyatguncelle.Checked;
                                    k.Yedekleme = chyedekleme.Checked;
                                    db.kullanici.Add(k);
                                    db.SaveChanges();
                                    doldur();
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı Zaten Kayıtlı");
                                }
                            }

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata Oluştu");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz" + "\nAd Soyad \nTelefon\nKullanıcı adı \nŞifre \n Şifre Tekrar");


                }
            }
            else if (btnkaydet.Text == "Güncelle")
            {
                if (txtadsoyad.Text != "" && maskedtelefon.Text != "" && txtkullaniciadi.Text != "" && txtsifre.Text != "" && txtsifretekrar.Text != "")
                {
                    if (txtsifretekrar.Text == txtsifretekrar.Text)
                    {
                        int id = Convert.ToInt32(lblid.Text);
                        using (var db = new barkodlusatisEntities()) 
                        {
                            var guncelle = db.kullanici.Where(x => x.id == id).FirstOrDefault();

                            guncelle.AdSoyad = txtadsoyad.Text;
                            guncelle.Telefon = maskedtelefon.Text;
                            guncelle.Eposta = txteposta.Text;
                            guncelle.KullaniciAd = txtkullaniciadi.Text.Trim();
                            guncelle.Sifre = txtsifre.Text;
                            guncelle.Satis = chsatis.Checked;
                            guncelle.Rapor = chrapor.Checked;
                            guncelle.Stok = chstok.Checked;
                            guncelle.Urungiris = churungiris.Checked;
                            guncelle.Ayarlar = chayarlar.Checked;
                            guncelle.FiyatGuncelle = chfiyatguncelle.Checked;
                            guncelle.Yedekleme = chyedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme Yapışmıştır");
                            btnkaydet.Text = "Kaydet";
                            Temizle();
                            doldur();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz" + "\nAd Soyad \nTelefon\nKullanıcı adı \nŞifre \n Şifre Tekrar");
                }
            }
          
        }
        private void Temizle()
        {
            txtadsoyad.Clear();
            maskedtelefon.Clear();
            txteposta.Clear();
            txtkullaniciadi.Clear();
            txtsifre.Clear();
            txtsifretekrar.Clear();
            chsatis.Checked = false;
            chrapor.Checked = false;
            chstok.Checked = false;
            churungiris.Checked = false;
            chayarlar.Checked = false;
            chfiyatguncelle.Checked = false;
            chyedekleme.Checked = false;
            
                

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridlistekullanici.Rows.Count>0)
            {
                int id = Convert.ToInt32(gridlistekullanici.CurrentRow.Cells["id"].Value.ToString());
                lblid.Text = id.ToString();
                using(var db= new barkodlusatisEntities())
                {
                    var getir = db.kullanici.Where(x => x.id == id).FirstOrDefault();
                    txtadsoyad.Text = getir.AdSoyad;
                    maskedtelefon.Text = getir.Telefon;
                    txteposta.Text = getir.Eposta;
                    txtkullaniciadi.Text = getir.KullaniciAd;
                    txtsifre.Text = getir.Sifre;
                    txtsifretekrar.Text = getir.Sifre;
                    chsatis.Checked =(bool)getir.Satis;
                    chrapor.Checked =(bool)getir.Rapor;
                    chstok.Checked = (bool)getir.Stok;
                    churungiris.Checked = (bool)getir.Urungiris;
                    chayarlar.Checked = (bool)getir.Ayarlar;
                    chfiyatguncelle.Checked = (bool)getir.FiyatGuncelle;
                    chyedekleme.Checked = (bool)getir.Yedekleme;
                    btnkaydet.Text = "Güncelle";


                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz");
            }
        }

        private void frmayarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doldur();
            Cursor.Current = Cursors.Default;
                
        }
        private void doldur()
        {
            using (var db = new barkodlusatisEntities())
            {
                if (db.kullanici.Any())
                {
                    gridlistekullanici.DataSource = db.kullanici.Select(x => new { x.id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();
                    islemler.GridDuzenle(gridlistekullanici);
                }



                islemler.SabitVarsayilan();
                var yazici = db.sabit.FirstOrDefault();
                chyazmadurumu.Checked = (bool)yazici.Yazici;

                var sabitler = db.sabit.FirstOrDefault();
                txtkartkomisyon.Text = sabitler.kartkomisyon.ToString();

                var terazionek = db.terazi.ToList();
                cmbterazionek.DisplayMember = "TeraziOnEk";
                cmbterazionek.ValueMember = "id";
                cmbterazionek.DataSource = terazionek;

                txtisyeriadsoyad.Text = sabitler.AdSoyad;
                txtisyeriunvan.Text = sabitler.Unvan;
                txtisyeriadres.Text = sabitler.Adres;
                maskedisyeritelefon.Text = sabitler.Telefon;
                txtisyerieposta.Text = sabitler.Eposta;
                




            }
        }

        private void chyazmadurumu_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new barkodlusatisEntities())
            {
                if (chyazmadurumu.Checked == true)
                {


                    islemler.SabitVarsayilan();
                    var ayarla = db.sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();




                    chyazmadurumu.Text = "Yazma Durumu AKTİF";
                }
                else
                {
                    islemler.SabitVarsayilan();
                    var ayarla = db.sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    chyazmadurumu.Text = "Yazma Durumu PASİF";

                }
            }
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnkartkomisyon_Click(object sender, EventArgs e)
        {
            if(txtkartkomisyon.Text!="")
            {
                using(var db= new barkodlusatisEntities())
                {
                    var sabit = db.sabit.FirstOrDefault();
                    sabit.kartkomisyon =Convert.ToInt16(txtkartkomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart Komisyon Ayarlandı");
                    

                }
            }
            else
            {
                MessageBox.Show("Kart Komisyon Bilgisini Giriniz");
            }
        }

        private void btnterazikaydet_Click(object sender, EventArgs e)
        {
            if(txtterazionek.Text!="")
            {
                
                using(var db=new barkodlusatisEntities())
                {
                    if(db.terazi.Any(x=> x.TeraziOnEk == txtterazionek.Text))
                    {
                        MessageBox.Show(txtterazionek.Text.ToString() + " Ön ek zaten kayıtlı");
                    }
                    else
                    {
                        terazi t = new terazi();
                        t.TeraziOnEk = txtterazionek.Text;
                        db.terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Bilgiler Kaydedilmiştir");                      
                        cmbterazionek.DisplayMember=("TeraziOnEk");
                        cmbterazionek.ValueMember = "id";
                        cmbterazionek.DataSource = db.terazi.ToList();
                        txtterazionek.Clear();
                    }

                            

                }
            }
            else
            {
                MessageBox.Show("Terazi Ön Ek Bilgisini Giriniz");
            }
        }

        private void btnoneksil_Click(object sender, EventArgs e)
        {
            if(cmbterazionek.Text!="")
            {
                int onekid = Convert.ToInt32(cmbterazionek.SelectedValue);
                DialogResult onay = MessageBox.Show(cmbterazionek.Text +" Öneki silmek istiyor musunuz?","Terazi Ön Ek Silme İşlemi", MessageBoxButtons.YesNo);
                if(onay==DialogResult.Yes)
                {
                   using (var db=new barkodlusatisEntities())
                    {
                        var onek = db.terazi.Find(onekid);
                        db.terazi.Remove(onek);
                        db.SaveChanges();
                        cmbterazionek.DisplayMember = ("TeraziOnEk");
                        cmbterazionek.ValueMember = "id";
                        cmbterazionek.DataSource = db.terazi.ToList();
                        MessageBox.Show("Ön Ek Silinmiştir");




                    }
                }
            }
            else
            {
                MessageBox.Show("Ön Ek Seçiniz");
            }
        }

        private void btnstandart1_Click(object sender, EventArgs e)
        {
            if(txtisyeriadsoyad.Text!="" && txtisyeriunvan.Text!="" && txtisyeriadres.Text!="" && maskedtelefon.Text!="")
            {
                using (var db= new barkodlusatisEntities())
                {
                    var isyeri = db.sabit.FirstOrDefault();
                    isyeri.AdSoyad = txtisyeriadsoyad.Text;
                    isyeri.Unvan = txtisyeriunvan.Text;
                    isyeri.Adres = txtisyeriadres.Text;
                    isyeri.Telefon = maskedisyeritelefon.Text;
                    isyeri.Eposta = txtisyerieposta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri bilgileri kaydedilmiştir.");
                    var yeni = db.sabit.FirstOrDefault();
                        {
                        txtisyeriadsoyad.Text = yeni.AdSoyad;
                        txtisyeriunvan.Text = yeni.Unvan;
                        txtisyeriadres.Text = yeni.Adres;
                        txtisyerieposta.Text = yeni.Eposta;
                        maskedisyeritelefon.Text = yeni.Telefon;
                        
                    }
                }
            }
        }

        private void btnyedektenyukle_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\programrestore\programrestore.exe");
            Application.Exit();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }

      
    }
}
