using Lisans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barkodsatis
{
    public class kontrol
    {
        barkodlusatisEntities db = new barkodlusatisEntities();
        public bool KontrolYap()
        {
            bool durum = false;
            if(db.guvenlik.Count()==0)
            {
       
            }
            else
            {
                lic lic = new lic();
                var guvenlik = db.guvenlik.FirstOrDefault();

                if(lic.TarihCoz(guvenlik.baslangic)< DateTime.Now)
                {
                    guvenlik.baslangic = lic.TarihSifrele(DateTime.Now);
                    db.SaveChanges();
                    durum = true;


                }
                if (lic.TarihKontrol(lic.TarihCoz(guvenlik.baslangic), lic.TarihCoz(guvenlik.bitis)))
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                 
                }
               
            }
            return durum;
        }
    
    }
}
