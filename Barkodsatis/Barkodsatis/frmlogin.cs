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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Girisyap();
        }
        private void Girisyap()
        {
            if (txtkullaniciadi.Text != "" && txtsifre.Text != "")
            {
                try
                {
                    using (var db = new barkodlusatisEntities())
                    {
                        if (db.kullanici.Any())
                        {
                            var bak = db.kullanici.Where(x => x.KullaniciAd == txtkullaniciadi.Text && x.Sifre == txtsifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                kontrol kontrol = new kontrol();
                                if(kontrol.KontrolYap())
                                {
                                    frmbaslangic frm = new frmbaslangic();
                                    frm.btnsatisislemi.Enabled = (bool)bak.Satis;
                                    frm.btngenelrapor.Enabled = (bool)bak.Rapor;
                                    frm.btnstoktakibi.Enabled = (bool)bak.Stok;
                                    frm.btnurungiris.Enabled = (bool)bak.Urungiris;
                                    frm.btnayarlar.Enabled = (bool)bak.Ayarlar;
                                    frm.fiyatguncelle.Enabled = (bool)bak.FiyatGuncelle;
                                    frm.yedekleme.Enabled = (bool)bak.Yedekleme;
                                    frm.lblkullanici.Text = bak.AdSoyad;
                                    var isyeri = db.sabit.FirstOrDefault();
                                    frm.lblisyeri.Text = isyeri.Unvan;
                                    frm.Show();
                                    this.Hide();
                                }
                                 
                               


                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void frmlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Girisyap();
            }
        }
    }
}
