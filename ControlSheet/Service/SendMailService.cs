using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            mail.Body = Message;

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

        public void SendMailSinCred()
        {
            MailMessage mensaje = new MailMessage("Remitente del correo ", "milton.amado10@gmail.com");
            mensaje.IsBodyHtml = true;

            //mensaje.IsBodyHtml = True; //Para permitir el uso de código html en el cuerpo del correo
            mensaje.Subject = "Asunto del correo electronico";
            mensaje.Body = "Aquí ya podemos especificar el contenido del correo electronico";
            mensaje.BodyEncoding = System.Text.Encoding.GetEncoding(1252);
            SmtpClient cliente;
            cliente = new SmtpClient("direccion_del_servidor_smtp_para_envia r_el_correo");
            //enviamos el mensaje
            cliente.Send(mensaje);
        }


    }
}