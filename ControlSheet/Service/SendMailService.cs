using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace ControlSheet.Service
{
    public class SendMailService
    {
        public void SendMail(string email, string title,string Message)
        {
            //IsEmail("milton.amado10@gmail.com");

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();

            mail.From = new MailAddress("urbanchampion10@gmail.com");
            mail.To.Add(email);
            mail.Subject = title;
            mail.Body = "Nueva Contraseña: " + Message;

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.Credentials = new System.Net.NetworkCredential("urbanchampion10@gmail.com", "urbanchampion");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public bool IsEmail(string inputEmail)
        {
            //inputEmail = NulltoString(inputEmail);
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

    }
}