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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.urunhareket
                           select new
                           {
                               ID = x.id,
                               URUN = x.urun.ad,
                               MUSTERİ = x.cari.ad+" " + x.cari.soyad,
                               PERSONEL = x.personel.ad+" " + x.personel.soyad,
                               TARİH = x.tarih,
                               ADET = x.adet,
                               FİYAT = x.fiyat,
                               SERİNO = x.urunserino
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
