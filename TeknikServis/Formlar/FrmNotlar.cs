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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = db.notlar.Where(x => x.durum == false).ToList();
            gridControl1.DataSource = db.notlar.Where(x => x.durum == true).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            notlar n = new notlar();
            n.baslik = TxtBaslik.Text;
            n.icerik = Txticerik.Text;
            n.durum = false;
            db.notlar.Add(n);
            db.SaveChanges();
            MessageBox.Show("Notunuz başarıyla kaydedilmiştir.");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             
        }
    }
}
