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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.faturadetay
                           select new
                           {
                               FATURADETAYID = u.id,
                               ÜRÜN = u.urun,
                               ADET = u.adet,
                               FİYAT = u.fiyat,
                               TUTAR = u.tutar,
                               FATURAID = u.faturaId
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            faturadetay f = new faturadetay();
            f.urun = TxtUrun.Text;
            f.adet = short.Parse(TxtAdet.Text);
            f.fiyat = decimal.Parse(TxtFiyat.Text);
            f.tutar = decimal.Parse(TxtTutar.Text);
            f.faturaId = int.Parse(TxtFaturaId.Text);
            db.faturadetay.Add(f);
            db.SaveChanges();
            MessageBox.Show("Fatura kalem bilgileri kaydedilmiştir.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.faturadetay
                           select new
                           {
                               FATURADETAYID = u.id,
                               ÜRÜN = u.urun,
                               ADET = u.adet,
                               FİYAT = u.fiyat,
                               TUTAR = u.tutar,
                               FATURAID = u.faturaId
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
