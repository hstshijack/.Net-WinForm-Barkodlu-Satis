using BorkodluSatis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodsatis
{
    public partial class frmbaslangic : Form
    {
        public frmbaslangic()
        {
            InitializeComponent();
        }

        private void btnsatisislemi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmsatis frm = new frmsatis();
            frm.lblkullanici.Text = lblkullanici.Text;
            
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btngenelrapor_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmrapor frm = new frmrapor();
            frm.lblkullanici.Text = lblkullanici.Text;
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnstoktakibi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmstok frm = new frmstok();
            frm.lblkullanici.Text = lblkullanici.Text;
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnurungiris_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmurungiris frm = new frmurungiris();
            frm.lblkullaniciurungiris.Text = lblkullanici.Text;
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void fiyatguncelle_Click(object sender, EventArgs e)
        {
            frmfiyatguncelle frm = new frmfiyatguncelle();
            frm.lblkullanici.Text = lblkullanici.Text;
            frm.ShowDialog();
        }

        private void btnayarlar_Click(object sender, EventArgs e)
        {
            frmayarlar frm = new frmayarlar();
            frm.lblkullanici.Text = lblkullanici.Text;
            frm.ShowDialog();
        }

        private void yedekleme_Click(object sender, EventArgs e)
        {
            islemler.Backup();

            



        }

        private void btnkullanicidegistir_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Hide();
        }
    }
}
