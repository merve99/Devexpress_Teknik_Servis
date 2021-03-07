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
    public partial class FrmYeniAriza : Form
    {
        public FrmYeniAriza()
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
            urunkabul u = new urunkabul();
            u.cariId = int.Parse(TxtMusteri.Text);
            u.personelId = int.Parse(TxtPersonel.Text);
            u.gelistarih = DateTime.Parse(TxtTarih.Text);
            u.urunserino = TxtSerino.Text;
            db.urunkabul.Add(u);
            db.SaveChanges();
            MessageBox.Show("Arızalı ürün başarıyla kaydedilmiştir.");
        }

        private void FrmYeniAriza_Load(object sender, EventArgs e)
        {

        }
    }
}
