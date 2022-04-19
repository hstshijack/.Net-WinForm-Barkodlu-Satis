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
    public partial class frmrapor : Form
    {
        public frmrapor()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        public void btngöster_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime baslangic = DateTime.Parse(datebaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(datebitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            using (var db=new barkodlusatisEntities())
            {
                if(rdtumu.Checked)//Tümünü Getir
                {
                    db.islem_ozet.Where(x => x.tarih >= baslangic && x.tarih <= bitis).OrderByDescending(x => x.tarih).Load();
                    var islemozet = db.islem_ozet.Local.ToBindingList();
                    gridliste.DataSource = islemozet;

                    txtsatisnakit.Text = Convert.ToDouble( islemozet.Where(x => x.iademi == false && x.gelir == false && x.gider == false).Sum(x => x.nakit)).ToString("C2");
                    txtsatiskart.Text = Convert.ToDouble(islemozet.Where(x => x.iademi == false && x.gelir == false && x.gider == false).Sum(s => s.kart)).ToString("C2");

                    txtiadenakit.Text = Convert.ToDouble(islemozet.Where(x => x.iademi == true).Sum(x => x.nakit)).ToString("C2");
                    txtiadekart.Text = Convert.ToDouble(islemozet.Where(x => x.iademi == true).Sum(x => x.kart)).ToString("C2");
                    txtgelirnakit.Text = Convert.ToDouble(islemozet.Where(x => x.gelir == true).Sum(s => s.nakit)).ToString("C2");
                    txtgelirkart.Text = Convert.ToDouble(islemozet.Where(x => x.gelir == true).Sum(s => s.kart)).ToString("C2");
                    txtgidernakit.Text = Convert.ToDouble(islemozet.Where(x => x.gider == true).Sum(s => s.nakit)).ToString("C2");
                    txtgiderkart.Text = Convert.ToDouble(islemozet.Where(x => x.gider == true).Sum(s => s.kart)).ToString("C2");

                    db.satis.Where(x => x.tarih >= baslangic && x.tarih <= bitis).Load();
                    var satistablosu = db.satis.Local.ToBindingList();

                    double kdvtutarisatis = islemler.DoubleYap(satistablosu.Where(x => x.iade == false).Sum(x => x.kdvtutari).ToString());
                    double kdvtutariade = islemler.DoubleYap(satistablosu.Where(x => x.iade == true).Sum(x => x.kdvtutari).ToString());
                    txtkdvtoplam.Text = (kdvtutarisatis - kdvtutariade).ToString("C2");                        
                
                } 

                else if (rdsatislar.Checked)//Satışlar
                {
                    db.islem_ozet.Where(x => x.tarih > baslangic && x.tarih <= bitis && x.iademi == false && x.gelir == false && x.gider == false).Load();
                    var islemozet = db.islem_ozet.Local.ToBindingList();
                    gridliste.DataSource = islemozet;

                }
                else if (rdiade.Checked)//İadeler
                {
                    db.islem_ozet.Where(x => x.tarih > baslangic && x.tarih <= bitis && x.iademi == true).Load();
                    var islemozet = db.islem_ozet.Local.ToBindingList();
                    gridliste.DataSource = islemozet;

                }
                else if (rdgelir.Checked)//Gelir
                {
                    db.islem_ozet.Where(x => x.tarih > baslangic && x.tarih <= bitis && x.gelir == true).Load();
                    var islemozet = db.islem_ozet.Local.ToBindingList();
                    gridliste.DataSource = islemozet;

                }
                else if (rdgider.Checked)//Gelir
                {
                    db.islem_ozet.Where(x => x.tarih > baslangic && x.tarih <= bitis && x.gider == true).Load();
                    var islemozet = db.islem_ozet.Local.ToBindingList();
                    gridliste.DataSource = islemozet;

                }

            }
            islemler.GridDuzenle(gridliste);

            Cursor.Current=Cursors.Default;

        }

        private void frmrapor_Load(object sender, EventArgs e)
        {
            rdtumu.Checked = true;

            txtkartkomisyon.Text = islemler.KartKomisyon().ToString();
            btngöster_Click(null, null);
            

        }

        private void gridliste_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex==2 || e.ColumnIndex==6 || e.ColumnIndex == 7)
            {

                if(e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Evet" : "Hayır";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btngelirekle_Click(object sender, EventArgs e)
        {
            frmgelirgider frm = new frmgelirgider();
            frm.GelirGider = "GELİR";
            frm.kullanici = lblkullanici.Text;
            frm.ShowDialog();
        }

        private void btngiderekle_Click(object sender, EventArgs e)
        {
            frmgelirgider frm = new frmgelirgider();
            frm.GelirGider = "GİDER";
            frm.kullanici = lblkullanici.Text;
            frm.ShowDialog();
        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridliste.Rows.Count>=0)
            {
                int islemno =Convert.ToInt32(gridliste.CurrentRow.Cells["islemno"].Value.ToString());
                if(islemno!=0)
                {
                    frmdetaygoster frm = new frmdetaygoster();
                    frm.islemno = islemno;
                    frm.ShowDialog();
                }
            }
        }

        private void btnraporal_Click(object sender, EventArgs e)
        {
            raporlar.Baslik = "GENEL RAPOR";
            raporlar.SatisKart = txtsatiskart.Text;
            raporlar.SatisNakit = txtsatisnakit.Text;
            raporlar.İadeKart = txtiadekart.Text;
            raporlar.İadeNakit = txtiadenakit.Text;
            raporlar.GelirKart = txtgelirkart.Text;
            raporlar.GelirNakit = txtgelirnakit.Text;
            raporlar.GiderKart = txtgiderkart.Text;
            raporlar.GiderNakit = txtgidernakit.Text;
            raporlar.TarihBaslangic = datebaslangic.Value.ToShortDateString();
            raporlar.TarihBitis = datebitis.Value.ToShortDateString();
            raporlar.KdvToplam = txtkdvtoplam.Text;
            raporlar.KartKomisyon = txtkartkomisyon.Text;
            raporlar.RaporSayfasiRaporu(gridliste);
        }

        
    }
}
