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
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }
        public int id;
        teknikservisEntities db = new teknikservisEntities();
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            // label1.Text = id.ToString();
            gridControl1.DataSource = db.faturadetay.Where(x => x.faturaId == id).ToList();
           // gridControl1.DataSource = db.faturabilgi.Where(x => x.id == id).ToList();
        }
    }
}
