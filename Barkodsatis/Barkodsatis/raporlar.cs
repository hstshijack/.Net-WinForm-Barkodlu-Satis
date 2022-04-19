using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows.Forms;

namespace Barkodsatis
{
    public static class raporlar
    {
        public static string Baslik { get; set; }
        public static string TarihBaslangic { get; set; }
        public static string TarihBitis { get; set; }

        public static string SatisNakit { get; set; }
        public static string SatisKart { get; set; }
        public static string İadeNakit { get; set; }
        public static string İadeKart { get; set; }
        public static string GelirNakit { get; set; }
        public static string GelirKart { get; set; }
        public static string GiderNakit{ get; set; }
        public static string GiderKart { get; set; }
        public static string KdvToplam { get; set; }
        public static string KartKomisyon { get; set; }

        public static void RaporSayfasiRaporu(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<islem_ozet> list = new List<islem_ozet>();
            list.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)

            {
                list.Add(new islem_ozet

                {
                    islemno = Convert.ToInt32(dgv.Rows[i].Cells["islemno"].Value.ToString()),
                    iademi = Convert.ToBoolean(dgv.Rows[i].Cells["iademi"].Value),
                    odemesekli = dgv.Rows[i].Cells["odemesekli"].Value.ToString(),
                    nakit = islemler.DoubleYap(dgv.Rows[i].Cells["nakit"].Value.ToString()),
                    kart = islemler.DoubleYap(dgv.Rows[i].Cells["kart"].Value.ToString()),
                    gelir = Convert.ToBoolean(dgv.Rows[i].Cells["gelir"].Value.ToString()),
                    gider = Convert.ToBoolean(dgv.Rows[i].Cells["gider"].Value.ToString()),
                    alisfiyat_toplam =islemler.DoubleYap( dgv.Rows[i].Cells["alisfiyat_toplam"].Value.ToString()),
                    aciklama=dgv.Rows[i].Cells["aciklama"].Value.ToString(),
                    tarih=Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value.ToString()),
                    kullanici=dgv.Rows[i].Cells["kullanici"].Value.ToString()

                    
                    





                }) ; 
                    
                    

            }

            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsGenelRapor";
            rs.Value = list;
            frmraporgöster frm = new frmraporgöster();
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(rs);
            frm.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\rpGenelRapor.rdlc";
            ReportParameter[] prm = new ReportParameter[13];
            prm[0] = new ReportParameter("Baslik", Baslik);
            prm[1] = new ReportParameter("TarihBaslangic", TarihBaslangic);
            prm[2] = new ReportParameter("TarihBitis", TarihBitis);
            prm[3] = new ReportParameter("SatisNakit", SatisNakit);
            prm[4] = new ReportParameter("SatisKart", SatisKart);
            prm[5] = new ReportParameter("İadeNakit", İadeNakit);
            prm[6] = new ReportParameter("İadeKart", İadeKart);
            prm[7] = new ReportParameter("GelirNakit", GelirNakit);
            prm[8] = new ReportParameter("GelirKart", GelirKart);
            prm[9] = new ReportParameter("GiderNakit", GiderNakit);
            prm[10] = new ReportParameter("GiderKart",GiderKart);
            prm[11] = new ReportParameter("KdvToplam", KdvToplam);
            prm[12] = new ReportParameter("KartKomisyon", KartKomisyon);
            frm.reportViewer1.LocalReport.SetParameters(prm);
            frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            frm.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        public static void StokRaporu(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Urunler> list = new List<Urunler>();
            list.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)

            {
                list.Add(new Urunler

                {
                    Barkod = dgv.Rows[i].Cells["Barkod"].Value.ToString(),
                    UrunAdi = dgv.Rows[i].Cells["Urunadi"].Value.ToString(),
                    UrunGrup = dgv.Rows[i].Cells["urungrup"].Value.ToString(),
                    Birim = dgv.Rows[i].Cells["Birim"].Value.ToString(),
                    SatisFiyati = islemler.DoubleYap(dgv.Rows[i].Cells["Satisfiyati"].Value.ToString()),
                    Miktar = islemler.DoubleYap(dgv.Rows[i].Cells["Miktar"].Value.ToString()),


                    Aciklama = dgv.Rows[i].Cells["Aciklama"].Value.ToString(),









                }); 



            }

            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsstokurun";
            rs.Value = list;
            frmraporgöster frm = new frmraporgöster();
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(rs);
            frm.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\rpstokurun.rdlc";
            ReportParameter[] prm = new ReportParameter[3];
            prm[0] = new ReportParameter("Baslik", Baslik);
            prm[1] = new ReportParameter("TarihBaslangic", TarihBaslangic);
            prm[2] = new ReportParameter("TarihBitis", TarihBitis);
           
            frm.reportViewer1.LocalReport.SetParameters(prm);
            frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            frm.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        public static void StokizlemeRaporu(DataGridView dgv)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<stokhareket> list = new List<stokhareket>();
            list.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)

            {
                list.Add(new stokhareket

                {
                    barkod = dgv.Rows[i].Cells["Barkod"].Value.ToString(),
                    urunadi = dgv.Rows[i].Cells["Urunadi"].Value.ToString(),
                    urungrup = dgv.Rows[i].Cells["urungrup"].Value.ToString(),
                    birim = dgv.Rows[i].Cells["Birim"].Value.ToString(),
                    miktar = islemler.DoubleYap(dgv.Rows[i].Cells["Miktar"].Value.ToString()),
                    kullanici=dgv.Rows[i].Cells["Kullanici"].Value.ToString(),
                    tarih=Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value.ToString())

                });



            }

            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsstokizleme";
            rs.Value = list;
            frmraporgöster frm = new frmraporgöster();
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(rs);
            frm.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\rpstokizleme.rdlc";
            ReportParameter[] prm = new ReportParameter[3];
            prm[0] = new ReportParameter("baslik", Baslik);
            prm[1] = new ReportParameter("tarihbaslangic", TarihBaslangic);
            prm[2] = new ReportParameter("tarihbitis", TarihBitis);

            frm.reportViewer1.LocalReport.SetParameters(prm);
            frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.reportViewer1.ZoomMode = ZoomMode.PageWidth;

            frm.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
    }
}
