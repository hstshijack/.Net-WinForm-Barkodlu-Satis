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
    public partial class frmurungrubuekle : Form
    {
        public frmurungrubuekle()
        {
            InitializeComponent();
        }
        barkodlusatisEntities db = new barkodlusatisEntities();
        private void frmurungrubuekle_Load(object sender, EventArgs e)
        {
            grupdoldur();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if(txturungrupadi.Text!="")
            {
                urungrup ug = new urungrup();
                ug.urungrupadi = txturungrupadi.Text;
                db.urungrup.Add(ug);
                db.SaveChanges();
                grupdoldur();
                txturungrupadi.Clear();
                MessageBox.Show("Ürün Grubu Eklenmiştir");
                frmurungiris frm = (frmurungiris)Application.OpenForms["frmurungiris"];
                if(frm!=null)
                {
                    frm.grupdoldur();
                }

             

            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyimiz");
            }


        }
        private void grupdoldur()
        {
            listurungrup.DisplayMember = "urungrupadi";
            listurungrup.ValueMember = "id";
            listurungrup.DataSource = db.urungrup.OrderBy(a => a.urungrupadi).ToList();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int grupid = Convert.ToInt32(listurungrup.SelectedValue.ToString());
            string grupad = listurungrup.Text;
            DialogResult onay = MessageBox.Show(grupad+"Grubunu silmek istiyor musunuz ?","Silme İşlemi",MessageBoxButtons.YesNo);

            if(onay==DialogResult.Yes)
            {
                var grup = db.urungrup.FirstOrDefault(x => x.id == grupid);
                db.urungrup.Remove(grup);
                db.SaveChanges();
                grupdoldur();
                txturungrupadi.Focus();
                MessageBox.Show(grupad + "Ürün Grubu Silindi");
                frmurungiris frm = (frmurungiris)Application.OpenForms["frmurungiris"];
                frm.grupdoldur();
           }

        }
    }
}
