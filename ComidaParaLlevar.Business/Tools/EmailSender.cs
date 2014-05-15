using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ComidaPaLlevar.Business.Tools
{
    public class EmailSender
    {
        public void SendMail(string HtmlBody, string EmailAddressTo, string EmailAddressFrom, string Subject)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mail = new MailMessage(EmailAddressFrom, EmailAddressTo);
            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.Body = HtmlBody;
            smtpClient.Send(mail);
        }
    }
}
