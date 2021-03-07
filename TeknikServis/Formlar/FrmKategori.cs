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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();

        private void BtnSil_Click(object sender, EventArgs e)
        {
            kategori k = new kategori();
            int id = int.Parse(TxtId.Text);
            var bul = db.kategori.Find(id);
            db.kategori.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        void metod1()
        {
            var degerler = from u in db.kategori
                           select new
                           {
                               u.id,
                               u.ad
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            metod1();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            kategori k = new kategori();
            k.ad = TxtKategoriAdi.Text;
            db.kategori.Add(k);
            db.SaveChanges();
            MessageBox.Show("Kategoriniz başarıyla oluşturulmuştur.");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            TxtKategoriAdi.Text = gridView1.GetFocusedRowCellValue("ad").ToString();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metod1();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.urun.Find(id);
            deger.ad = TxtKategoriAdi.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
