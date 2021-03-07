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
    public partial class FrmFaturaDetay : Form
    {
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtFaturaID.Text);
        
            var degerler = (from u in db.faturadetay
                           select new
                           {
                               FATURADETAYID = u.id,
                               ÜRÜN = u.urun,
                               ADET = u.adet,
                               FİYAT = u.fiyat,
                               TUTAR = u.tutar,
                               FATURAID = u.faturaId
                           }).Where(x=>x.FATURAID==id);
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
