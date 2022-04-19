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
    public partial class frmnakitkart : Form
    {
        public frmnakitkart()
        {
            InitializeComponent();
        }

        private void frmnakitkart_Load(object sender, EventArgs e)
        {

        }

        private void txtnakit_KeyDown(object sender, KeyEventArgs e)
        {
            if(txtnakit.Text!="")
            {
                if(e.KeyCode==Keys.Enter)
                {
                    Hesapla();
                }
            }
        }
        private void Hesapla()
        {
            frmsatis frm = (frmsatis)Application.OpenForms["frmsatis"];
            double nakit = islemler.DoubleYap(txtnakit.Text);
            double geneltoplam = islemler.DoubleYap(frm.txtgeneltoplam.Text);
            double kart = geneltoplam - nakit;
            frm.lnakit.Text = nakit.ToString("C2");
            frm.lkart.Text = kart.ToString("C2");
            frm.SatisYap("Kart-Nakit");
            this.Hide();
        }
        private void bnx_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text == ",")
            {
                int virgul = txtnakit.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    txtnakit.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (txtnakit.Text.Length > 0)
                {
                    txtnakit.Text = txtnakit.Text.Substring(0, txtnakit.Text.Length - 1);
                }
            }

            else
            {
                txtnakit.Text += b.Text;
            }


        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            if(txtnakit.Text!="")
            {
                Hesapla();
            }
                   
        }

        private void txtnakit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08)
            {
                e.Handled = true;
            }
        }
    }
}
