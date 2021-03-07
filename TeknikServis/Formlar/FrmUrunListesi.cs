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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        void metod1()
        {
            var deger = from u in db.urun
                        select new
                        {
                            u.id,
                            u.ad,
                            u.marka,
                            Kategori =u.kategori.ad,
                            u.alisfiyat,
                            u.satisfiyat,
                            u.stok                            
                        };
            gridControl1.DataSource = deger.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            metod1();
            lookUpEdit1.Properties.DataSource = (from x in db.kategori
                                                 select new
                                                 {
                                                     x.id,
                                                     x.ad
                                                 }).ToList();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            urun u = new urun();
            u.ad = TxtUrunAdi.Text;
            u.alisfiyat = decimal.Parse(TxtAlisFiyati.Text);
            u.satisfiyat = decimal.Parse(TxtSatisFiyati.Text);
            u.marka = TxtMarka.Text;
            u.durum = false;
            u.stok = short.Parse(TxtStok.Text);
            u.kategoriId=byte.Parse(lookUpEdit1.EditValue.ToString());
            db.urun.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ürününüz başarıyla eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metod1();
            lookUpEdit1.Properties.DataSource = db.kategori.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            TxtUrunAdi.Text = gridView1.GetFocusedRowCellValue("ad").ToString();
            TxtMarka.Text = gridView1.GetFocusedRowCellValue("marka").ToString();
            TxtAlisFiyati.Text = gridView1.GetFocusedRowCellValue("alisfiyat").ToString();
            TxtSatisFiyati.Text = gridView1.GetFocusedRowCellValue("satisfiyat").ToString();
            TxtStok.Text = gridView1.GetFocusedRowCellValue("stok").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(TxtId.Text);
            var deger = db.urun.Find(Id);
            db.urun.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.urun.Find(id);
            deger.ad = TxtUrunAdi.Text;
            deger.marka = TxtMarka.Text;
            deger.stok = short.Parse(TxtStok.Text);
            deger.satisfiyat = decimal.Parse(TxtSatisFiyati.Text);
            deger.alisfiyat = decimal.Parse(TxtAlisFiyati.Text);
            deger.kategoriId = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
