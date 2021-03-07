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
    public partial class FrmYeniCari : Form
    {
        public FrmYeniCari()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            cari c = new cari();
            c.ad = TxtAd.Text;
            c.soyad = TxtSoyad.Text;
            c.il = TxtIl.Text;
            c.ilce = TxtIlce.Text;
            db.cari.Add(c);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari başarıyla eklenmiştir.");
        }
    }
}
