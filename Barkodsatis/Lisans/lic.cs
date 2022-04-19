using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lisans
{
     public class lic
    {
        public string CpuNo()
        {
            string islemciid = "";
            ManagementObjectSearcher ara = new ManagementObjectSearcher("Select *From WIN32_Processor");
            ManagementObjectCollection obje = ara.Get();
            foreach (ManagementObject item in obje)
            {
                islemciid = item["ProcessorId"].ToString();

            }
            return islemciid;
        }
        public int CpuKarakterToplam()
        {
            int toplam = 0;
            foreach (char item in CpuNo().ToCharArray())
            {
                toplam += (int)item;

            }
            return toplam;
                 
        }
        public string gunkarakter = "WEIKDMFJSBNXHSHFDHGJERKSDNFNDSKEWIUHESMDNHSSDNSGBNGFSDNMDGNDSHET";
        public string aykarakter = "WEZKFNESTJSKAOETJEJSDSBGNDMFG";
        public string yilkarakter = "XMCNDKSLDJGERJTWEKTDSMSDHS";
        public bool TarihKontrol(DateTime baslangic,DateTime bitis)
        {
            return baslangic < DateTime.Now && DateTime.Now < bitis;
        }


        public int GirilenLisansiKontrolEt(string girilenlisansbilgisi)
        {
            Cursor.Current = Cursors.WaitCursor;
            double girilen = Convert.ToDouble(girilenlisansbilgisi);
            bool demomu = girilen == CpuKarakterToplam() * TarihFonksiyon() * 3;
            bool yillikmi = girilen == CpuKarakterToplam() * TarihFonksiyon() * 13;
            int durum = 0;

            if(demomu)
            {
                durum = 1;// demo kurulum için 1  döndürüyoruz
            }
           

           else if(yillikmi)
            {
                durum = 2; 
            }
            else
            {
                durum = 0;
            }
            Cursor.Current = Cursors.Default;
            return durum;


        }
        public DateTime DemoTarihOlustur()
        {
            DateTime tarih = DateTime.Now.AddDays(10);
            return tarih;
           
        }
        public DateTime yilliktariholustur()
        {
            DateTime tarih = DateTime.Now.AddYears(1);
            return tarih;
        }
        public long EkrandaGoster()
        {
            long gosterilecekno = CpuKarakterToplam()*TarihFonksiyon();
            return gosterilecekno;

        }
        public long TarihFonksiyon()
        {
            return (DateTime.Now.Day + DateTime.Now.Month) * DateTime.Now.Year;

        }

        public DateTime TarihCoz(string sifrelitarih)
        {
            string strgun = sifrelitarih.Substring(0, 2);
            string stray = sifrelitarih.Substring(2, 2);
            string stryil = sifrelitarih.Substring(4, 2);

            int gun = gunler().Where(x => x.Ad == strgun).FirstOrDefault().Numara;
            int ay = aylar().Where(x => x.Ad == stray).FirstOrDefault().Numara;
            int yil = yillar().Where(x => x.Ad == stryil).FirstOrDefault().Numara;
            DateTime tarih = new DateTime(yil, ay, gun);
            return tarih;
        }

        public string TarihSifrele(DateTime tarih)
        {
            int gun = tarih.Day;
            int ay = tarih.Month;
            int yil = tarih.Year;

            string strgun = gunler().Where(x => x.Numara == gun).FirstOrDefault().Ad;
            string stray = aylar().Where(x => x.Numara == ay).FirstOrDefault().Ad;
            string stryil = yillar().Where(x => x.Numara == yil).FirstOrDefault().Ad;

            string olusansifrelitarih = strgun + stray + stryil;
            return olusansifrelitarih;
        }

        public List<sablon> gunler()
        {
            List<sablon> ListGun = new List<sablon>();
            for (int i = 0; i <31; i++)
            {
                ListGun.Add(new sablon { Numara = i + 1, Ad = gunkarakter.ToString().Substring(i * 2, 2) });
            }
            return ListGun;
        }
        public List<sablon> aylar()
        {
            List<sablon> listay = new List<sablon>();
            for (int i = 0; i < 12; i++)
            {
                listay.Add(new sablon { Numara = i + 1, Ad = aykarakter.ToString().Substring(i * 2, 2) });

            }
            return listay;
        }

        public List<sablon> yillar()
        {
            List<sablon> listyil = new List<sablon>();
            int karakterayisi = 0;
            for (int i = 2021; i < 2030; i++)
            {
                listyil.Add(new sablon { Numara = i, Ad = yilkarakter.ToString().Substring(karakterayisi * 2, 2) });
                karakterayisi += 2;

            }
            return listyil;

        }
        
       public class sablon
        {
            public int Numara { get; set; }
            public string Ad { get; set; }

        }

    }
}
