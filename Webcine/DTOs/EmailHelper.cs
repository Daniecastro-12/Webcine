using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Webcine.DTOs
{
    public class EmailHelper
    {
        public static void EnviarCorreoConQR(
        string correoDestino,
        string asunto,
        string cuerpo,
        byte[] qrBytes)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("webcine12@gmail.com", "CineMax"); // Cambia el nombre si quieres
            mail.To.Add(correoDestino);  // El correo de destino (cliente)
            mail.Subject = asunto;
            mail.Body = cuerpo;

            // Adjunta el QR como imagen PNG
            mail.Attachments.Add(new Attachment(new MemoryStream(qrBytes), "qr.png", "image/png"));

            // Configura el servidor SMTP de Gmail
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("webcine12@gmail.com", "msry ztez lzik dgeo"); // Pega aquí tu contraseña de aplicación
            smtp.EnableSsl = true;

            // Envía el correo
            smtp.Send(mail);
        }
    }
}