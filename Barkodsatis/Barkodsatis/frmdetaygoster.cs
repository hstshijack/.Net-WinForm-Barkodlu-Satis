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
    public partial class frmdetaygoster : Form
    {
        public frmdetaygoster()
        {
            InitializeComponent();
        }
        public int islemno { get; set; }
        private void frmdetaygoster_Load(object sender, EventArgs e)
        {
            //lblislemno.Text = "İşlem No :" + islemno.ToString();
            using (var db=new barkodlusatisEntities())
            {
                gridliste.DataSource = db.satis.Select(s=> new {s.islemno,s.urunadi,s.urungrup,s.miktar,s.toplam}).Where(x => x.islemno == islemno).ToList();
                islemler.GridDuzenle(gridliste);
            }
        }
    }
}
