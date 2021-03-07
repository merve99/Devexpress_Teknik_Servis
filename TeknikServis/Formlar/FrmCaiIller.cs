using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmCaiIller : Form
    {
        public FrmCaiIller()
        {
            InitializeComponent();
        }
        teknikservisEntities db = new teknikservisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-KIDPJQS4\SQLEXPRESS;Initial Catalog=teknikservis;Integrated Security=True");
        private void FrmCaiIller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 5);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 7);
            //chartControl1.Series["Series 1"].Points.AddPoint("Kahramanmaraş", 10);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select il,count(*) from cari group by il", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            gridControl1.DataSource = db.cari.OrderBy(x => x.il).GroupBy(y => y.il).Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();
        }
    }
}
