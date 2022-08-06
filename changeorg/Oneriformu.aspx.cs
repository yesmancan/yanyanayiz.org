using changeorg.Helpers;
using System;
using System.Net.Mail;
using System.Web.Services;
using System.Net;
using System.Configuration;
using System.Text;

namespace changeorg
{
    public partial class Oneriformu : System.Web.UI.Page
    {
        public static MailMessage ePosta = new MailMessage();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gonderbtn_Click(object sender, EventArgs e)
        {

            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "True" ? true : false);
            string name = hm.sqlSafe(hm.StripHTML(Request.Form["name"]) + ""),
                email = hm.sqlSafe(hm.StripHTML(Request.Form["email"]) + ""),
                icerik = hm.sqlSafe(hm.StripHTML(Request.Form["icerik"]) + "");
            //try
            //{
            if (IsCaptchaValid)
            {

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(icerik))
                {

                    string baslik = "Yanyanayiz - Öneri ve Destek Formu";
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new NetworkCredential("", "");

                    MailAddress gonderen = new MailAddress("", baslik);

                    MailAddressCollection adresses = new MailAddressCollection();

                    adresses.Add(new MailAddress(""));
                    adresses.Add(new MailAddress(""));

                    string body = "<table cellspacing='0' cellpadding='0' border='0' width='700px'>" +
                        "<tr><td align='left' valign='top' height='25px' width='75px'>Ad Soyad</td>" +
                        "<td align='center' valign='middle' width='15px'>:</td>" +
                        "<td align='left' valign='middle'>" + name + "</td>" +
                        "</tr>" +
                        "<tr><td align='left' valign='top' height='25px'>E-Mail</td>" +
                        "<td align='center' valign='middle'>:</td>" +
                        "<td align='left' valign='middle'>" + email + "</td></tr>" +
                        "<tr><td align='left' valign='top' height='25px'>Mesaj</td>" +
                        "<td align='center' valign='middle'>:</td>" +
                        "<td align='left' valign='middle'>" + icerik + "</td></tr>" +
                        "</table>";
                    smtp.Host = "relay-hosting.secureserver.net";
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = 25;//465;
                    smtp.ServicePoint.MaxIdleTime = 1;
                    //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

                    foreach (MailAddress alici in adresses)
                    {
                        MailMessage mesaj = new MailMessage(gonderen, alici);
                        mesaj.Priority = MailPriority.Normal;

                        mesaj.Subject = baslik;
                        mesaj.IsBodyHtml = true;
                        mesaj.Body = body;
                        smtp.Send(mesaj);
                    }

                    Response.Write("<script>alert('Mesajınız iletilmiştir.');document.location.href = '/Default.aspx';</script>");
                }
                else
                    lblmssg.Text = "Lütfen bütün alanları doldurunuz.";

            }
            else
                lblmssg.Text = "Lütfen reCAPTCHA'yi doldurunuz.";

            //}
            //catch (Exception ex)
            //{
            //    lblmssg.Text = "Bir Hata Oluştu" + ex.InnerException;
            //}
        }
    }
}