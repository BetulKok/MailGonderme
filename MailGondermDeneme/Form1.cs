using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Mail;
using System.IO;

namespace MailGondermDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Gonder_Click(object sender, EventArgs e)
        {
            GonderMail("deneme yapıyoruz.", richTextBox1.Text);
        }
        

        private bool GonderMail(string konu, string icerik)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("keepfitTeam1@outlook.com", sifreoku());
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;

            MailMessage ePosta = new MailMessage();
            ePosta.To.Add("keepfitTeam1@outlook.com");
            ePosta.From = new MailAddress("keepfitTeam1@outlook.com");
            ePosta.IsBodyHtml = true;
            ePosta.Subject = konu;
            ePosta.Body = $"<h1>{icerik}</h1>" ;

            object userState = ePosta;
            bool kontrol = true;

            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
                MessageBox.Show("Mail gondemr başarılı");

            }
            catch (SmtpException ex)
            {

                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message , "Başarısız oldu.");
            }

            return kontrol;
            
        }

        private string sifreoku()
        {
            return File.ReadAllText(@"C:\Users\betul\source\repos\MailGondermDeneme\sifre.txt");

        }
    }
}
