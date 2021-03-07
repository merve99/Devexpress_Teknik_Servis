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
    public partial class FrmDepartmanListesi : Form
    {
        public FrmDepartmanListesi()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmDepartmanListesi_Load(object sender, EventArgs e)
        {
            var deger = from d in db.departman
                        select new
                        {
                            d.id,
                            d.ad,
                            d.aciklama
                        };
            gridControl1.DataSource = deger.ToList();
            labelControl23.Text = db.departman.Count().ToString();
            labelControl3.Text = db.personel.Count().ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            departman d = new departman();
            if(TxtAd.Text.Length<=50 && TxtAd.Text !="" && richTextBox1.Text.Length >= 1)
            {
                d.ad = TxtAd.Text;
                d.aciklama = richTextBox1.Text;
                db.departman.Add(d);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Departman Kaydedilemedi!");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("ad").ToString();
            richTextBox1.Text = gridView1.GetFocusedRowCellValue("aciklama").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.departman.Find(id);
            db.departman.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.departman.Find(id);
            deger.ad = TxtAd.Text;
            deger.aciklama = richTextBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla güncellenmiştir.");
        }
    }
}
