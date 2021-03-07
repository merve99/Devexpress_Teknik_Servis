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
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.urunkabul
                           select new
                           {
                               ISLEM = x.id,
                               ÜRÜNSERİNO=x.urunserino,
                               CARİ = x.cari.ad +" "+ x.cari.soyad,
                               PERSONEL = x.personel.ad +" "+ x.personel.soyad,
                               GELİS=x.gelistarih,
                               ÇIKIŞ=x.cikistarih
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}