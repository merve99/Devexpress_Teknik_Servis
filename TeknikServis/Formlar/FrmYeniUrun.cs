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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {

        }
        teknikservisEntities db = new teknikservisEntities();
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            urun u = new urun();
            u.ad = TxtUrunAd.Text;
            u.marka = TxtMarka.Text;
            u.kategoriId = byte.Parse(TxtKategori.Text);
            u.alisfiyat = decimal.Parse(TxtAlisFiyat.Text);
            u.satisfiyat = decimal.Parse(TxtSatisFiyat.Text);
            u.stok = short.Parse(TxtStok.Text);
            u.durum = false;
            db.urun.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla kaydedilmiştir.");
        }
    }
}
