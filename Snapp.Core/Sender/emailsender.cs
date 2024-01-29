using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Snapp.Core.senders
{
   public static class emailsender
    {
        public static void send(string to,string subject,string body)
        {
            var password = "";
            var mymail = "";
            var mail = new MailMessage();
            var smtpserver = new SmtpClient("");
            mail.From = new MailAddress(mymail, "اسنپ");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            smtpserver.Port = 0;
            smtpserver.Credentials = new NetworkCredential(mymail, password);
            smtpserver.EnableSsl = false;
            smtpserver.Send(mail);
        }
    }
}
