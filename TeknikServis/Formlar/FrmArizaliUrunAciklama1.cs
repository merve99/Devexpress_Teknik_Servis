using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaliUrunAciklama1 : Form
    {
        public FrmArizaliUrunAciklama1()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmArizaliUrunAciklama1_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.uruntakip
                                      select new
                                      {
                                          TAKİPID = x.id,
                                          SERİNO = x.serino,
                                          TARİH = x.tarih,
                                          AÇIKLAMA = x.aciklama
                                      }).ToList();

        }
    }
}
