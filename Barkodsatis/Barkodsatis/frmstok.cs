using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodsatis
{
    public partial class frmstok : Form
    {
        public frmstok()
        {
            InitializeComponent();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            if (txtara.Text.Length >= 3)
            {
                string urunad = txtara.Text;
                using (var db = new barkodlusatisEntities())
                {
                    if (cmbislemturu.SelectedIndex == 0)
                    {
                        db.Urunler.Where(x => x.UrunAdi.Contains(urunad)).Load();
                        gridliste.DataSource = db.Urunler.Local.ToBindingList();
                        islemler.GridDuzenle(gridliste);
                    }
                    else if (cmbislemturu.SelectedIndex == 1)
                    {
                        db.stokhareket.Where(x => x.urunadi.Contains(urunad)).Load();
                        gridliste.DataSource = db.stokhareket.Local.ToBindingList();
                        islemler.GridDuzenle(gridliste);
                    }
                  


                }
            }

            
            
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            gridliste.DataSource = null;
            using (var db=new barkodlusatisEntities())
            {
                if(cmbislemturu.Text!="")
                {
                    string urungrubu = cmburungrup.Text;
                    if (cmbislemturu.SelectedIndex==0)
                    {
                        if(rdtumu.Checked)
                        {
                            db.Urunler.OrderBy(x => x.Miktar).Load();
                            gridliste.DataSource = db.Urunler.Local.ToBindingList();
                            islemler.GridDuzenle(gridliste);
                        }
                        else if (rdurungrubunagore.Checked)
                        {
                            db.Urunler.Where(x => x.UrunGrup == urungrubu).OrderBy(x=>x.Miktar).Load();
                            gridliste.DataSource = db.Urunler.Local.ToBindingList();
                            islemler.GridDuzenle(gridliste);
                        }
                      
                       
                                
                    }
                    else if (cmbislemturu.SelectedIndex==1)
                    {
                        DateTime baslangic = DateTime.Parse(datebaslangic.Value.ToShortDateString());
                        DateTime bitis = DateTime.Parse(datebitis.Value.ToShortDateString());
                        bitis = bitis.AddDays(1);
                        if(rdtumu.Checked)
                        {
                            db.stokhareket.OrderByDescending(x => x.tarih).Where(x => x.tarih >= baslangic && x.tarih <= bitis).Load();
                            gridliste.DataSource = db.stokhareket.Local.ToBindingList();
                            islemler.GridDuzenle(gridliste);

                        }
                        else if (rdurungrubunagore.Checked)
                        {
                            db.stokhareket.OrderByDescending(x => x.tarih).Where(x => x.tarih >= baslangic && x.tarih <= bitis && x.urungrup.Contains(urungrubu)).Load();
                            gridliste.DataSource = db.stokhareket.Local.ToBindingList();
                            islemler.GridDuzenle(gridliste);
                        }
                        


                    }
                }
            }
        }
        barkodlusatisEntities dbx = new barkodlusatisEntities();
        private void frmstok_Load(object sender, EventArgs e)
        {
            cmbislemturu.SelectedIndex = 0;
            cmburungrup.DisplayMember = "urungrupadi";
            cmburungrup.ValueMember = "id";
            cmburungrup.DataSource = dbx.urungrup.ToList();

            using (var db = new barkodlusatisEntities())
            {
                db.Urunler.OrderBy(x => x.Miktar).Load();
                gridliste.DataSource = db.Urunler.Local.ToBindingList();
                islemler.GridDuzenle(gridliste);
            }
             


        }

        private void cmbislemturu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnraporal_Click(object sender, EventArgs e)
        {
            if(cmbislemturu.SelectedIndex==0)
            {
                raporlar.Baslik = cmbislemturu.Text + "Raporu";
                raporlar.TarihBaslangic = datebaslangic.Value.ToShortDateString();
                raporlar.TarihBitis = datebitis.Value.ToShortDateString();
                raporlar.StokRaporu(gridliste);
            }

            else
            {
                raporlar.Baslik = cmbislemturu.Text + "Raporu";
                raporlar.TarihBaslangic = datebaslangic.Value.ToShortDateString();
                raporlar.TarihBitis = datebitis.Value.ToShortDateString();
                raporlar.StokizlemeRaporu(gridliste);
            }
            
        }
    }
}
