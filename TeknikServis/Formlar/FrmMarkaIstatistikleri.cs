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
    public partial class FrmMarkaIstatistikleri : Form
    {
        public FrmMarkaIstatistikleri()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        private void FrmMarkaIstatistikleri_Load(object sender, EventArgs e)
        {
            var degerler = db.urun.OrderBy(x => x.marka).GroupBy(y => y.marka).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            }).ToList();
            gridControl1.DataSource = degerler;
            labelControl23.Text = db.kategori.Count().ToString();
            labelControl1.Text = (from x in db.urun select x.marka).Distinct().Count().ToString();
            labelControl5.Text = (from x in db.urun orderby x.satisfiyat descending select x.marka).FirstOrDefault();
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("Vestel", 3);
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Arzum", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("HP", 7);
            chartControl2.Series["Series 1"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Series 1"].Points.AddPoint("PC", 3);
            chartControl2.Series["Series 1"].Points.AddPoint("Ev Aletleri", 5);
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
