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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.faturabilgi
                           select new
                           {
                               ID = u.id,
                               SERİNO = u.seri,
                               SIRANO = u.sirano,
                               TARİH = u.tarih,
                               SAAT = u.saat,
                               VERGİDAİRESİ = u.vergidaire,
                               CARİ = u.cari.ad + " " + u.cari.soyad,
                               PERSONEL = u.personel1.ad + " " + u.personel1.soyad
                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.cari
                                                 select new
                                                 {
                                                     x.id,
                                                     ad = x.ad + " " + x.soyad
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.personel
                                                 select new
                                                 {
                                                     x.id,
                                                     ad = x.ad + " " + x.soyad
                                                 }).ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.faturabilgi
                           select new
                           {
                               ID = u.id,
                               SERİNO = u.seri,
                               SIRANO = u.sirano,
                               TARİH = u.tarih,
                               SAAT = u.saat,
                               VERGİDAİRESİ = u.vergidaire,
                               CARİ = u.cari.ad + " " + u.cari.soyad,
                               PERSONEL = u.personel1.ad + " " + u.personel1.soyad
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            faturabilgi t = new faturabilgi();
            t.seri = TxtSeri.Text;
            t.sirano = TxtSiraNo.Text;
            t.tarih = Convert.ToDateTime(TxtTarih.Text);
            t.saat = TxtSaat.Text;
            t.vergidaire = TxtVergiDairesi.Text;
            t.cariId = int.Parse(lookUpEdit1.EditValue.ToString());
            t.personel = int.Parse(lookUpEdit2.EditValue.ToString());
            db.faturabilgi.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura sisteme kaydedilmiştir.Kalem girişi yapabilirsiniz.");
        }
 
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("id").ToString());
            fr.Show();
        }
    }
}
