using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Utility
{
    public class send
    {

        public string SendMail(string ToEmail, string Token)
        {
            string FromEmail = "aa4468@srmist.edu.in";
            MailMessage Message = new MailMessage(FromEmail, ToEmail);
            string MailBody = "Token Generated : " + Token;
            Message.Subject = "Token Generated For Resetting Password";
            Message.Body = MailBody.ToString();
            Message.BodyEncoding = Encoding.UTF8;
            Message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential credential
                = new NetworkCredential(FromEmail, "ilvj tjax mezk cxdc");

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(Message);
            return ToEmail;
        }

    }
}
