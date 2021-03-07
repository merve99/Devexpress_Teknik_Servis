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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        private void FrmYeniDepartman_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        teknikservisEntities db = new teknikservisEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            departman d = new departman();
            d.ad = TxtAd.Text;
            d.aciklama = textAciklama.Text;
            db.departman.Add(d);
            db.SaveChanges();
            MessageBox.Show("Departman Kaydedildi.");
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
