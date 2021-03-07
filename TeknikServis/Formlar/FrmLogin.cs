using DevExpress.XtraEditors;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }
        teknikservisEntities db = new teknikservisEntities();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.admin where x.kullaniciad == TxtKullaniciAdi.Text & x.sifre == TxtSifre.Text select x;
            if (sorgu.Any())//yani sorgunun içerisinde herhangi bişey varsa
            {
               Form1 frm=new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Giriş!");
            }
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void TxtKullaniciAdi_Click(object sender, EventArgs e)
        {
            TxtKullaniciAdi.Text = "";
        }
    }
}
