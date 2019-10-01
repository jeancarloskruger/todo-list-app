using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TodoListApp.Core.Services
{
    public static class EmailService
    {
        public static void SendEmail(string email, string subject, string body)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;


                smtp.Credentials = new NetworkCredential("testeenviotodolist@gmail.com", "alsihdgjkakb312321");
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("notification@todolist.com");
                    mail.To.Add(new MailAddress(email));
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    smtp.Send(mail);
                }

            }
        }
    }
}
