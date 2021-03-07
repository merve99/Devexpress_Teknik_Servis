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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.urun
                                       select new
                                       {
                                           AD = x.ad,
                                           STOK = x.stok
                                       }).Where(x => x.STOK < 20).ToList();
            gridControl2.DataSource = (from x in db.cari
                                       select new
                                       {
                                           ADSOYAD = x.ad + " " + x.soyad,
                                           İL = x.il
                                       }).ToList();
            gridControl3.DataSource =db.urunkategori().ToList();
            DateTime bugun = DateTime.Today;
            var degerler = (from x in db.notlar.OrderBy(x => x.id)
                            where (x.tarih == bugun)
                            select new { BAŞLIK = x.baslik, İÇERİK = x.icerik });
            gridControl4.DataSource = degerler.ToList();
        }
    }
}
