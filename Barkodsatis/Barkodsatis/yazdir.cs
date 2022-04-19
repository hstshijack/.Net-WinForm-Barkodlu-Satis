using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; 

namespace Barkodsatis
{
    class yazdir
    {
        public int? islemno { get; set; }
        public yazdir(int? islemNo)
        {
            islemno = islemNo;
            
        }
        PrintDocument pd = new PrintDocument();
        public void YazdirmayaBasla()
        {
            try
            {
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            barkodlusatisEntities db = new barkodlusatisEntities();
            var isyeri = db.sabit.FirstOrDefault();
            var liste = db.satis.Where(x => x.islemno == islemno).ToList();
            if(isyeri!=null && liste!=null)
            {
                int kagituzunluk = 120;
                for (int i = 0; i < liste.Count; i++)
                {

                }
                PaperSize ps58 = new PaperSize("58 mm Termal", 220, kagituzunluk + 120);
                pd.DefaultPageSettings.PaperSize = ps58;

                Font fontBaslik = new Font("Calibri", 10, FontStyle.Bold);
                Font fontbilgi = new Font("Calibri", 8, FontStyle.Bold);
                Font fonticerikbaslik = new Font("Calibri", 8, FontStyle.Underline);
                StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
                ortala.Alignment = StringAlignment.Center;
                RectangleF rcUnvanKonum = new RectangleF(0,20,220,20);
                e.Graphics.DrawString(isyeri.Unvan, fontBaslik, Brushes.Black, rcUnvanKonum,ortala);
                e.Graphics.DrawString("Telefon:" + isyeri.Telefon, fontbilgi, Brushes.Black, new Point(5, 45));
                e.Graphics.DrawString("İşlem No:" + islemno.ToString(), fontbilgi, Brushes.Black, new Point(5, 60));
                e.Graphics.DrawString("Tarih:" + DateTime.Now, fontbilgi, Brushes.Black, new Point(5, 75));
                e.Graphics.DrawString("---------------------------------------------------------", fontbilgi, Brushes.Black, new Point(5, 90));

                e.Graphics.DrawString("Ürün Adı", fonticerikbaslik, Brushes.Black, new Point(5, 105));
                e.Graphics.DrawString("Miktar", fonticerikbaslik, Brushes.Black, new Point(100,105));
                e.Graphics.DrawString("Fiyat", fonticerikbaslik, Brushes.Black, new Point(140, 105));
                e.Graphics.DrawString("Tutar", fonticerikbaslik, Brushes.Black, new Point(180, 105));
                e.Graphics.DrawString("---------------------------------------------------------", fontbilgi, Brushes.Black, new Point(5, 90));

                int yukseklik = 120;
                double geneltoplam = 0;

                foreach (var item in liste)
                {
                    e.Graphics.DrawString(item.urunadi, fontbilgi, Brushes.Black, new Point(5, yukseklik));
                    e.Graphics.DrawString(item.miktar.ToString(),fontbilgi,Brushes.Black,new Point(115,yukseklik));
                    e.Graphics.DrawString(Convert.ToDouble(item.satisfiyat).ToString("C2"), fontbilgi, Brushes.Black, new Point(140, yukseklik));
                    e.Graphics.DrawString(Convert.ToDouble(item.toplam).ToString("C2"),fontbilgi, Brushes.Black, new Point(180, yukseklik));
                    yukseklik += 15;
                    geneltoplam += Convert.ToDouble(item.toplam);
                }
                e.Graphics.DrawString("---------------------------------------------------------", fontbilgi, Brushes.Black, new Point(5, yukseklik));
                e.Graphics.DrawString("TOPLAM :"+geneltoplam.ToString("C2"),fontBaslik,Brushes.Black,new Point(5,yukseklik+20));
                e.Graphics.DrawString("---------------------------------------------------------", fontbilgi, Brushes.Black, new Point(5, yukseklik+40));
                e.Graphics.DrawString("(Mali Değeri Yoktur)", fontbilgi, Brushes.Black, new Point(5,yukseklik+60));

               



            }
        }
    }
}
