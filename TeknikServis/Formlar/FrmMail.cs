using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmMail : Form
    {
        public FrmMail()
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
            MailMessage mail = new MailMessage();
            string frommail = "mervetopaktas99@gmail.com";
            string sifre = "30Merve77.";
            string alici = TxtAlici.Text;
            string konu = TxtKonu.Text;
            string icerik = Txticerik.Text;
            mail.From = new MailAddress(frommail);
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(frommail, sifre);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            MessageBox.Show("Mail Gönderildi.");
        }
    }
}
