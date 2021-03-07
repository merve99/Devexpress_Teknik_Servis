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
    public partial class FrmArizaDetay : Form
    {
        public FrmArizaDetay()
        {
            InitializeComponent();
        }

        private void pictureEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtSerino_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmArizaDetay_Load(object sender, EventArgs e)
        {

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            uruntakip u = new uruntakip();
            u.serino = TxtSerino.Text;
            u.tarih = DateTime.Parse(TxtTarih.Text);
            u.aciklama = richTextBox1.Text;
            db.uruntakip.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürün açıklaması başarıyla girilmiştir.");
        }
    }
}
