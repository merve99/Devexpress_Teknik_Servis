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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
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
            kategori k = new kategori();
            k.ad = TxtKategori.Text;
            db.kategori.Add(k);
            db.SaveChanges();
        }

        private void TxtKategori_Click(object sender, EventArgs e)
        {
            TxtKategori.Text = "";
            TxtKategori.Focus();
        }
    }
}
