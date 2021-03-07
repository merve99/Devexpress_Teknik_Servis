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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
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
            urunhareket u = new urunhareket();
            u.urunId = int.Parse(lookUpEdit1.EditValue.ToString());
            u.musteri = int.Parse(lookUpEdit2.EditValue.ToString());
            u.personelId = int.Parse(lookUpEdit3.EditValue.ToString());
            u.tarih = DateTime.Parse(TxtTarih.Text);
            u.adet = short.Parse(TxtAdet.Text);
            u.fiyat = decimal.Parse(TxtFiyat.Text);
            u.urunserino = TxtSerino.Text;
            db.urunhareket.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürün satış işlemi başarıyla gerçekleştirilmiştir.");
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.urun
                                                 select new
                                                 {
                                                     x.id,
                                                     x.ad
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.cari
                                                 select new
                                                 {
                                                     x.id,
                                                     ad = x.ad + " " + x.soyad
                                                 }).ToList();
            lookUpEdit3.Properties.DataSource = (from x in db.personel
                                                 select new
                                                 {
                                                     x.id,
                                                     ad = x.ad + " " + x.soyad
                                                 }).ToList();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
