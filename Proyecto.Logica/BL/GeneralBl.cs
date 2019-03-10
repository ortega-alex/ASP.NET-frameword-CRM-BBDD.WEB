using Proyecto.Logica.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Proyecto.Logica.BL
{
    public class GeneralBl
    {
        public void setEmail(Correo correo )
        {
            try
            {
                //objeto de correo
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(correo.From);
                mail.To.Add(correo.To);
                mail.Subject = correo.Asunto;
                mail.Body = correo.Mensaje;

                if (correo.Tipo == 0) mail.IsBodyHtml = false;
                else if (correo.Tipo == 1) mail.IsBodyHtml = true;

                if (correo.Prioridad == 2) mail.Priority = MailPriority.High;
                else if (correo.Prioridad == 1) mail.Priority = MailPriority.Low;
                else if (correo.Prioridad == 0) mail.Priority = MailPriority.Normal;

                //icrustra una image
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(correo.Mensaje, Encoding.UTF8 , MediaTypeNames.Text.Html);
                LinkedResource img = new LinkedResource(correo.Image, MediaTypeNames.Image.Gif);
                img.ContentId = correo.IdImage;
                htmlView.LinkedResources.Add(img);
                mail.AlternateViews.Add(htmlView);

                //cliente del servidor de correo
                SmtpClient smtp = new SmtpClient();
                smtp.Host = correo.Servidor;

                if (correo.Autenticacion) smtp.Credentials = new NetworkCredential(correo.Usuairo, correo.Password);
                if (correo.Puerto.Length > 0) smtp.Port = Convert.ToInt32(correo.Puerto);

                smtp.EnableSsl = correo.ConexionSegura;
                smtp.Send(mail);

            } catch (Exception ex) { throw ex; }
        }
    }
}
