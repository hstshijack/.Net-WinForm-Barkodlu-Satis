using BorkodluSatis;
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
    public partial class frmhizlibtnurunekle : Form
    {
        public frmhizlibtnurunekle()
        {
            InitializeComponent();
        }
        barkodlusatisEntities db = new barkodlusatisEntities();
        private void txturunara_TextChanged(object sender, EventArgs e)
        {
            if(txturunara.Text!=null)
            { string urunad = txturunara.Text;
                var urunler = db.Urunler.Where(a => a.UrunAdi.Contains(urunad)).ToList();
                gridurunler.DataSource = urunler;
                islemler.GridDuzenle(gridurunler);
            }
        }

        private void gridurunler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gridurunler.Rows.Count>0)
            {
                string barkod = gridurunler.CurrentRow.Cells["Barkod"].Value.ToString();
                string urunad = gridurunler.CurrentRow.Cells["urunadi"].Value.ToString();
                double fiyat =Convert.ToDouble( gridurunler.CurrentRow.Cells["satisfiyati"].Value.ToString());
                int id = Convert.ToInt16(lblbutonid.Text);
                var guncellenecek = db.hizliurun.Find(id);
                guncellenecek.barkod = barkod;
                guncellenecek.urunadi = urunad;
                guncellenecek.fiyat = fiyat;
                db.SaveChanges();
                MessageBox.Show("Buton Tanımlanmıştır");
                frmsatis frm = (frmsatis)Application.OpenForms["frmsatis"];
                if (frm !=null)
                {
                    Button b = frm.Controls.Find("hbtn" + id, true).FirstOrDefault() as Button;
                    b.Text = urunad + "\n" + fiyat.ToString("C2");
                }
            }
        }

        private void chtumu_CheckedChanged(object sender, EventArgs e)
        {
            if (chtumu.Checked)
            {
                gridurunler.DataSource = db.Urunler.ToList();
                gridurunler.Columns["AlisFiyati"].Visible = false;
                gridurunler.Columns["SatisFiyati"].Visible = false;
                gridurunler.Columns["KdvOrani"].Visible = false;
                gridurunler.Columns["KdvTutari"].Visible = false;
                gridurunler.Columns["Miktar"].Visible = false;
                islemler.GridDuzenle(gridurunler);
            }
           
            else
            {
                gridurunler.DataSource = null;
            }
        }

        private void frmhizlibtnurunekle_Load(object sender, EventArgs e)
        {
            gridurunler.DataSource = db.Urunler.ToList();
            gridurunler.Columns["AlisFiyati"].Visible = false;
            gridurunler.Columns["SatisFiyati"].Visible = false;
            gridurunler.Columns["KdvOrani"].Visible = false;
            gridurunler.Columns["KdvTutari"].Visible = false;
            gridurunler.Columns["Miktar"].Visible = false;
            islemler.GridDuzenle(gridurunler);
        }
    }
}
