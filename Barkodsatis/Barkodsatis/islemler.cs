using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodsatis
{
    static class islemler
    {
        
        public static double DoubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out sonuc);
            return Math.Round(sonuc,2);

        }
        public static void StokAzalt(string barkod,double miktar)
        {
            if(barkod!="1111111111116")
            {
                using (var db = new barkodlusatisEntities())
                {
                    var urunbilgi = db.Urunler.SingleOrDefault(x => x.Barkod == barkod);
                    urunbilgi.Miktar -= miktar;
                    db.SaveChanges();

                }
            }

        }
        public static void StokARttır(string barkod, double miktar)
        {
            if(barkod!="1111111111116")
            {
                using (var db = new barkodlusatisEntities())
                {
                    var urunbilgi = db.Urunler.SingleOrDefault(x => x.Barkod == barkod);
                    urunbilgi.Miktar += miktar;
                    db.SaveChanges();

                }
            }
           
        }

         public static void GridDuzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count>0)
            {
                for (int i = 0; i <dgv.Columns.Count ; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {

                        case "id":
                            dgv.Columns[i].HeaderText = "Numara"; break;

                        case "islemno":
                            dgv.Columns[i].HeaderText = "İşlem No"; break;

                        case "UrunId":
                            dgv.Columns[i].HeaderText = "Ürün Numarası";break;

                        case "UrunAdi":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama"; break;
                        case "aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama"; break;
                        case "UrunGrup":
                            dgv.Columns[i].HeaderText = "Ürün Grubu";break;
                        case "AlisFiyati":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            dgv.Columns[i].HeaderText = "Alış Fiyatı";break;
                        case "SatisFiyati":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            dgv.Columns[i].HeaderText = "Satış Fiyatı";break;
                        case "nakit":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            dgv.Columns[i].HeaderText = "Nakit"; break;
                        case "kart":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            dgv.Columns[i].HeaderText = "Kart"; break;
                        case "alisfiyat_toplam":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            dgv.Columns[i].HeaderText = "Alış Fiyatı"; break;
                        case "KdvOrani":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv.Columns[i].HeaderText = "Kdv Oranı";
                            break;

                        case "Birim":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Miktar":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;

                        case "Odemesekli":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;

                        case "Kart":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Nakit":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gelir":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gider":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;

                        case "gelir":
                            dgv.Columns[i].HeaderText = "Gelir"; break;
                        case "gider":
                            dgv.Columns[i].HeaderText = "Gider"; break;
                        case "odemesekli":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli"; break;
                        case "iademi":
                            dgv.Columns[i].HeaderText = "İade"; break;


                        case "Kullanici":
                            dgv.Columns[i].HeaderText = "Kullanıcı"; break;
                        case "kullanici":
                            dgv.Columns[i].HeaderText = "Kullanıcı"; break;
                        case "miktar":
                            dgv.Columns[i].HeaderText = "Miktar"; break;

                        case "urunadi":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "urungrup":
                            dgv.Columns[i].HeaderText = "Ürün Grup"; break;
                        case "toplam":
                            dgv.Columns[i].HeaderText = "Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;

                        case "KdvTutari":

                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            dgv.Columns[i].HeaderText = "Kdv Tutarı"; break;

                        case "AdSoyad":
                            dgv.Columns[i].HeaderText = "Ad Soyad"; break;

                        case "KullaniciAd":
                            dgv.Columns[i].HeaderText = "Kullanıcı Adı"; break;



                    }
                }
            }
        }
        public static void StokHareket(string barkod,string urunadi,string birim,double miktar,string urungrup,string kullanici)
        {
            using (var db=new barkodlusatisEntities())
            {
                stokhareket sh = new stokhareket();
                sh.barkod = barkod;
                sh.urunadi = urunadi;
                sh.birim = birim;
                sh.miktar = miktar;
                sh.urungrup = urungrup;
                sh.kullanici = kullanici;
                sh.tarih = DateTime.Now;
                db.stokhareket.Add(sh);
                db.SaveChanges();

            }
        }
    

        public static int KartKomisyon()
        {
            int  sonuc = 0;
            using (var db=new barkodlusatisEntities())
            {
                if(db.sabit.Any())
                {
                    sonuc = Convert.ToInt16(db.sabit.First().kartkomisyon);
                }

                else
                {
                    sonuc = 0;
                }
                return sonuc;

            }
        }

        public static void SabitVarsayilan()

        {
            using (var db= new barkodlusatisEntities())
            {
                if(!db.sabit.Any())
                {
                    sabit s = new sabit();
                    s.kartkomisyon = 0;
                    s.Yazici = false;
                    s.AdSoyad="admin";
                    s.Unvan = "admin";
                    s.Adres = "admin";
                    s.Telefon = "admin";
                    s.Eposta = "admin";
                    db.sabit.Add(s);
                    db.SaveChanges();

                }
              
            }
        }

        public static void Backup()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Veri Yedek Dosyası|0.bak";
            save.FileName = DateTime.Now.ToShortDateString() + "Barkodlu_Satis_Programı";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(save.FileName))
                    {
                        File.Delete(save.FileName);
                    }

                    var dbHedef = save.FileName;
                    //string dbkaynak = Application.StartupPath + @"Data Source=DESKTOP-10S04G1;Initial Catalog=barkodlusatis;Integrated Security=True";
                    
                    using (var db = new barkodlusatisEntities())
                    {
                        string dbkaynak = db.Database.Connection.Database;
                        var cmd = @"BACKUP DATABASE[" + dbkaynak + "]TO DISK='" + dbHedef + "'";
                        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Yedekleme Tamamlanmıştır");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }



    }
}
