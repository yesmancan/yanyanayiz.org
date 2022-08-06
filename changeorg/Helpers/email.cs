using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;

namespace changeorg.Helpers
{
    public class email
    {
        public enum MailAddressType
        {
            From = 1,
            Bcc
        }

        private static MailAddress _from = null;

        public static void SendEmail(string to, string subject, string body)
        {
            SendEmail(to, subject, body, From, string.Empty);
        }

        public static void SendEmail(string to, string subject, string body, string from)
        {
            SendEmail(to, subject, body, from, MailAddressType.From);
        }

        public static void SendEmail(string to, string subject, string body, string addresses, MailAddressType addressType)
        {
            MailAddress from = From;
            string bcc = string.Empty;

            if (MailAddressType.From == addressType)
            {
                from = new MailAddress(addresses);
            }
            else
            {
                bcc = addresses;
            }

            SendEmail(to, subject, body, from, bcc);
        }

        private static void SendEmail(string to, string subject, string body, MailAddress from, string bcc)
        {
            MailMessage message = new MailMessage();
            message.From = From;
            message.To.Add(to);
            if (!string.IsNullOrEmpty(bcc))
            {
                message.Bcc.Add(bcc);
            }
            message.ReplyTo = from;
            message.Subject = subject;
            message.Body = HttpContext.Current.Server.HtmlEncode(body);
            SmtpClient smtp = new SmtpClient();
            smtp.Send(message);
        }

        public static MailAddress From
        {
            get
            {
                if (null == _from)
                {
                    SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                    string address = section.From;
                    string displayName = ConfigurationManager.AppSettings["fromEmailDisplayName"];
                    _from = new MailAddress(address, displayName);
                }
                return _from;
            }
        }
    }
}